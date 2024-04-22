namespace FormatadorDeArquivoDePagamento.App
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        
        private void FileOpenBtn_Click()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt";
            openFileDialog.Title = "Escolha o arquivo de pagamento";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);
                string formattedFileContent = FormatFileContent(fileContent);
                SaveFile(formattedFileContent);
            }
        }
    }
}
