using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace FormatadorDeArquivoDePagamento.Core
{
    public interface IFormatadorService
    {
        List<LinhaDoArquivoDePagamento> FormatarLinhasDoArquivoDePagamento(string caminho);
        void CriarArquivoDePagamentoFormatado(string caminho, List<LinhaDoArquivoDePagamento> linhas);
    }

    public class FormatadorDoArquivoDePagamento : IFormatadorService
    {
        public List<LinhaDoArquivoDePagamento> FormatarLinhasDoArquivoDePagamento(string caminho)
        {
            if (!ArquivoEhValido(caminho))
            {
                Console.WriteLine("Arquivo inválido.");
                return null;
            }

            string[] linhas = File.ReadAllLines(caminho, Encoding.GetEncoding("Windows-1252"));

            List<LinhaDoArquivoDePagamento> linhasFormatadas = new List<LinhaDoArquivoDePagamento>();

            foreach (var item in linhas)
            {
                LinhaDoArquivoDePagamento linhaDoArquivo = PopularLinhaDoArquivo(item);

                linhasFormatadas.Add(linhaDoArquivo);
            }

            return linhasFormatadas;
        }

        public void CriarArquivoDePagamentoFormatado(string caminho, List<LinhaDoArquivoDePagamento> linhas)
        {
            if (linhas == null)
                return;

            using (var workbook = new XLWorkbook())
            {
                var planilhaDeTrabalho = workbook.Worksheets.Add("Econsig TJTO");

                var cabecalhos = new List<string>
                {
                    "Matrícula",
                    "CPF",
                    "Nome",
                    "N1",
                    "N2",
                    "Código",
                    "Quantidade",
                    "Valor",
                    "Competência",
                    "Tipo"
                };

                foreach (var cabecalho in cabecalhos.Select((value, index) => new { value, index }))
                {
                    planilhaDeTrabalho.Cell(1, cabecalho.index + 1).Value = cabecalho.value;
                }

                foreach (var linha in linhas.Select((value, index) => new { value, index }))
                {
                    planilhaDeTrabalho.Cell(linha.index + 2, 1).Value = linha.value.Matricula;
                    planilhaDeTrabalho.Cell(linha.index + 2, 2).Value = linha.value.CPF;
                    planilhaDeTrabalho.Cell(linha.index + 2, 3).Value = linha.value.Nome.Normalize(NormalizationForm.FormD);
                    planilhaDeTrabalho.Cell(linha.index + 2, 4).Value = linha.value.N1;
                    planilhaDeTrabalho.Cell(linha.index + 2, 5).Value = linha.value.N2;
                    planilhaDeTrabalho.Cell(linha.index + 2, 6).Value = linha.value.Codigo;
                    planilhaDeTrabalho.Cell(linha.index + 2, 7).Value = linha.value.Quantidade;
                    planilhaDeTrabalho.Cell(linha.index + 2, 8).Value = linha.value.Valor;
                    planilhaDeTrabalho.Cell(linha.index + 2, 9).Value = linha.value.Competencia.ToDateTime(TimeOnly.MinValue);
                    planilhaDeTrabalho.Cell(linha.index + 2, 10).Value = linha.value.Tipo;
                }

                workbook.SaveAs(caminho + "ArquivoEconsigTJTO.xlsx");
            }
        }

        private bool ArquivoEhValido(string caminho)
        {
            if (string.IsNullOrEmpty(File.ReadAllText(caminho)))
                return false;

            return true;
        }

        private LinhaDoArquivoDePagamento PopularLinhaDoArquivo(string item)
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
                Tipo = item.Substring(110, 1)
            };
        }
    }
}
