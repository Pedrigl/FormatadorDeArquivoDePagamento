using System;
using System.Collections.Generic;
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

        public static LinhaDoArquivoDePagamento[] FormatarLinhasDoArquivoDePagamento(string caminho)
        {
            if (!ArquivoEhValido(caminho))
            {
                Console.WriteLine("Arquivo inválido.");
                return null;
            }

            string[] linhas = File.ReadAllLines(caminho);

            LinhaDoArquivoDePagamento[] linhasFormatadas = new LinhaDoArquivoDePagamento[linhas.Length];

            foreach (var item in linhas)
            {
                var linhaDoArquivo = new LinhaDoArquivoDePagamento
                {
                    Matricula = int.Parse(item.Substring(0, 10)),
                    CPF = long.Parse(item.Substring(10, 11)),
                    Nome = item.Substring(21, 50),
                    N1 = item.Substring(71, 3),
                    N2 = item.Substring(74, 3),
                    Codigo = int.Parse(item.Substring(77, 5)),
                    Quantidade = int.Parse(item.Substring(82, 13)),
                    Valor = double.Parse(item.Substring(95, 7)),
                    Competencia = DateOnly.ParseExact(item.Substring(102, 8), "ddMMyyyy"),
                    Tipo = char.Parse(item.Substring(110, 1))
                };

                linhasFormatadas.Append(linhaDoArquivo);
            }

        }
    }
}
