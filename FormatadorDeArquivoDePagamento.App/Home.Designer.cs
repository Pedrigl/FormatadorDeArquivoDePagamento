namespace FormatadorDeArquivoDePagamento.App
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FileOpenBtn = new Button();
            SuspendLayout();
            // 
            // FileOpenBtn
            // 
            FileOpenBtn.Location = new Point(295, 202);
            FileOpenBtn.Name = "FileOpenBtn";
            FileOpenBtn.Size = new Size(201, 23);
            FileOpenBtn.TabIndex = 0;
            FileOpenBtn.Text = "Escolha o arquivo de pagamento";
            FileOpenBtn.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(FileOpenBtn);
            Name = "Home";
            Text = "Formatador De Arquivo De Pagamento";
            ResumeLayout(false);
        }

        #endregion

        private Button FileOpenBtn;
    }
}
