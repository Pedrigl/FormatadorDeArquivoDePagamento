using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatadorDeArquivoDePagamento
{
    public class FormatadorDoArquivoDePagamento
    {
        private static bool ArquivoEhValido(string caminho)
        {
            if(!caminho.EndsWith(".txt"))
                return false;

            if(string.IsNullOrEmpty(File.ReadAllText(caminho)))
                return false;

            return true;
        }

        public static List<LinhaDoArquivoDePagamento> FormatarLinhasDoArquivoDePagamento(string caminho)
        {
            if (!ArquivoEhValido(caminho))
            {
                Console.WriteLine("Arquivo inválido.");
                return null;
            }

            string[] linhas = File.ReadAllLines(caminho);

            List<LinhaDoArquivoDePagamento> linhasFormatadas = new List<LinhaDoArquivoDePagamento>();

            foreach (var item in linhas)
            {
                LinhaDoArquivoDePagamento linhaDoArquivo = PopularLinhaDoArquivo(item);

                linhasFormatadas.Add(linhaDoArquivo);
            }

            return linhasFormatadas;
        }

        private static LinhaDoArquivoDePagamento PopularLinhaDoArquivo(string item)
        {
            return new LinhaDoArquivoDePagamento
            {
                Matricula = int.Parse(item.Substring(0, 10)),
                CPF = long.Parse(item.Substring(10, 11)),
                Nome = item.Substring(21, 50),
                N1 = item.Substring(71, 3),
                N2 = item.Substring(74, 3),
                Codigo = int.Parse(item.Substring(77, 5)),
                Quantidade = double.Parse(item.Substring(82, 13), CultureInfo.InvariantCulture),
                Valor = double.Parse(item.Substring(95, 7), CultureInfo.InvariantCulture),
                Competencia = DateOnly.ParseExact(item.Substring(102, 8), "ddMMyyyy", CultureInfo.InvariantCulture),
                Tipo = char.Parse(item.Substring(110, 1))
            };
        }
    }
}
