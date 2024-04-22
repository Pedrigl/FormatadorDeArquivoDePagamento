using System;
using System.IO;

namespace FormatadorDeArquivoDePagamento
{
    public interface ICaminhoService
    {
        string ObterCaminho();
    }

    public class GerenciadorDeCaminho : ICaminhoService
    {
        public string ObterCaminho()
        {
            string caminho = string.Empty;

            do
            {
                Console.WriteLine("Informe o caminho do arquivo:");
                caminho = Console.ReadLine();
            }
            while (!CaminhoValido(caminho));

            return caminho;
        }

        private bool CaminhoValido(string caminho)
        {
            if (string.IsNullOrEmpty(caminho))
            {
                Console.WriteLine("Caminho vazio. Tente novamente.");
                return false;
            }

            if (!caminho.EndsWith(".txt"))
            {
                Console.WriteLine("Arquivo inválido. Tente novamente com um arquivo TXT.");
                return false;
            }

            if (!File.Exists(caminho))
            {
                Console.WriteLine("Arquivo não encontrado. Tente novamente.");
                return false;
            }

            return true;
        }
    }
}
