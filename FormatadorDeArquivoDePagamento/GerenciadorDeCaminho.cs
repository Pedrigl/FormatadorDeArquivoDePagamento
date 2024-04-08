using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatadorDeArquivoDePagamento
{
    public class GerenciadorDeCaminho
    {
        private static bool CaminhoValido(string caminho)
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

        public static string ObterCaminho()
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
    }
}
