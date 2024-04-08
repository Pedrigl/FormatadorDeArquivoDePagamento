using FormatadorDeArquivoDePagamento;
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

Console.WriteLine("Bem vindo ao Formatador de Arquivo de Pagamento!");

string caminho = GerenciadorDeCaminho.ObterCaminho();

var linhasFormatadas = FormatadorDoArquivoDePagamento.FormatarLinhasDoArquivoDePagamento(caminho);

Console.WriteLine("Informe o caminho para salvar o arquivo formatado:");
var caminhoPraSalvarArquivo = Console.ReadLine();

FormatadorDoArquivoDePagamento.CriarArquivoDePagamentoFormatado(caminhoPraSalvarArquivo, linhasFormatadas);
