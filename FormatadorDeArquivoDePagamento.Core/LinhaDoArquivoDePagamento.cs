﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatadorDeArquivoDePagamento.Core
{
    public class LinhaDoArquivoDePagamento
    {
        public int Matricula { get; set; }
        public long CPF { get; set; }
        public string Nome { get; set; }
        public string N1 { get; set; }
        public string N2 { get; set; }
        public int Codigo { get; set; }
        public double Quantidade { get; set; }
        public double Valor { get; set; }
        public DateOnly Competencia { get; set; }
        public string Tipo { get; set; }
    }
}
