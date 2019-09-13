using System;
using System.Globalization;
using AtuandoComArquivos.Entidades;
using System.IO;

namespace AtuandoComArquivos
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Digite o caminho completo do arquivo: ");
            string origemArquivo = Console.ReadLine();

            try
            {
                string[] linhas = File.ReadAllLines(origemArquivo);

                string pastaOrigem = Path.GetDirectoryName(origemArquivo);
                string pastaDestino = pastaOrigem + @"\out";
                string arquivoDestino = pastaDestino + @"\summary.csv";

                Directory.CreateDirectory(pastaDestino);

                using (StreamWriter sw = File.AppendText(arquivoDestino))
                {
                    foreach (string linha in linhas)
                    {

                        string[] campos = linha.Split(',');
                        string nome = campos[0];
                        double preco = double.Parse(campos[1], CultureInfo.InvariantCulture);
                        int quantidade = int.Parse(campos[2]);

                        Produtos prod = new Produtos(nome, preco, quantidade);

                        sw.WriteLine(prod.Nome + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
