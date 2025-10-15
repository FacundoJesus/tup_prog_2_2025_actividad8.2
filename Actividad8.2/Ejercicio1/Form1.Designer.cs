namespace Ejercicio1
{
    partial class Form1
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
            dtpVencimiento = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnConfirmar = new Button();
            tbPatente = new TextBox();
            tbImporte = new TextBox();
            lsbResultado = new ListBox();
            btnActualizar = new Button();
            btnImportar = new Button();
            btnExportar = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Location = new Point(154, 59);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(200, 23);
            dtpVencimiento.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 19);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 1;
            label1.Text = "Patente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 59);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 2;
            label2.Text = "Vencimiento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 99);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 3;
            label3.Text = "Importe:";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(392, 54);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(75, 37);
            btnConfirmar.TabIndex = 4;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // tbPatente
            // 
            tbPatente.Location = new Point(154, 12);
            tbPatente.Name = "tbPatente";
            tbPatente.Size = new Size(200, 23);
            tbPatente.TabIndex = 5;
            // 
            // tbImporte
            // 
            tbImporte.Location = new Point(154, 96);
            tbImporte.Name = "tbImporte";
            tbImporte.Size = new Size(200, 23);
            tbImporte.TabIndex = 6;
            // 
            // lsbResultado
            // 
            lsbResultado.FormattingEnabled = true;
            lsbResultado.ItemHeight = 15;
            lsbResultado.Location = new Point(23, 159);
            lsbResultado.Name = "lsbResultado";
            lsbResultado.ScrollAlwaysVisible = true;
            lsbResultado.Size = new Size(331, 169);
            lsbResultado.TabIndex = 7;
            lsbResultado.SelectedValueChanged += lsbResultado_SelectedValueChanged;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(392, 168);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 37);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(392, 221);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(75, 37);
            btnImportar.TabIndex = 9;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(392, 275);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(75, 37);
            btnExportar.TabIndex = 10;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 355);
            Controls.Add(btnExportar);
            Controls.Add(btnImportar);
            Controls.Add(btnActualizar);
            Controls.Add(lsbResultado);
            Controls.Add(tbImporte);
            Controls.Add(tbPatente);
            Controls.Add(btnConfirmar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpVencimiento);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ejercicio 1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpVencimiento;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnConfirmar;
        private TextBox tbPatente;
        private TextBox tbImporte;
        private ListBox lsbResultado;
        private Button btnActualizar;
        private Button btnImportar;
        private Button btnExportar;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
