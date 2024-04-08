using FormatadorDeArquivoDePagamento;
using System.Diagnostics;
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

Console.WriteLine("Bem vindo ao Formatador de Arquivo de Pagamento!");

ICaminhoService gerenciadorDeCaminho = new GerenciadorDeCaminho();
string caminho = gerenciadorDeCaminho.ObterCaminho();

IFormatadorService formatadorDoArquivoDePagamento = new FormatadorDoArquivoDePagamento();
var linhasFormatadas = formatadorDoArquivoDePagamento.FormatarLinhasDoArquivoDePagamento(caminho);

Console.WriteLine("Informe o caminho para salvar o arquivo formatado:");
var caminhoPraSalvarArquivo = Console.ReadLine();

formatadorDoArquivoDePagamento.CriarArquivoDePagamentoFormatado(caminhoPraSalvarArquivo, linhasFormatadas);

Console.WriteLine("Arquivo formatado criado com sucesso!");

Process.Start(new ProcessStartInfo(caminhoPraSalvarArquivo + "ArquivoEconsigTJTO.xlsx") { UseShellExecute = true});

Environment.Exit(0);