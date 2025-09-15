namespace Bisección_y_Regla_Falsa
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
            btnLimpiar = new Button();
            lblFuncion = new Label();
            lblXi = new Label();
            lblXf = new Label();
            lblEa = new Label();
            cmbFuncion = new ComboBox();
            txtXi = new TextBox();
            txtXf = new TextBox();
            txtEamax = new TextBox();
            btnBiseccion = new Button();
            btnReglaFalsa = new Button();
            gridIter = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridIter).BeginInit();
            SuspendLayout();
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(49, 454);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(214, 45);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            // 
            // lblFuncion
            // 
            lblFuncion.Location = new Point(49, 25);
            lblFuncion.Name = "lblFuncion";
            lblFuncion.Size = new Size(100, 23);
            lblFuncion.TabIndex = 1;
            lblFuncion.Text = "Funcion";
            // 
            // lblXi
            // 
            lblXi.Location = new Point(49, 92);
            lblXi.Name = "lblXi";
            lblXi.Size = new Size(100, 23);
            lblXi.TabIndex = 3;
            lblXi.Text = "X Inicial";
            // 
            // lblXf
            // 
            lblXf.Location = new Point(49, 171);
            lblXf.Name = "lblXf";
            lblXf.Size = new Size(100, 23);
            lblXf.TabIndex = 5;
            lblXf.Text = "X Final";
            lblXf.Click += lblXf_Click;
            // 
            // lblEa
            // 
            lblEa.Location = new Point(49, 238);
            lblEa.Name = "lblEa";
            lblEa.Size = new Size(100, 23);
            lblEa.TabIndex = 7;
            lblEa.Text = "EaMax";
            // 
            // cmbFuncion
            // 
            cmbFuncion.Items.AddRange(new object[] { "f(x) = 4x^3 - 6x^2 + 7x - 2.3", "g(x) = x^2 * sqrt(|cos x|) - 5" });
            cmbFuncion.Location = new Point(49, 51);
            cmbFuncion.Name = "cmbFuncion";
            cmbFuncion.Size = new Size(214, 28);
            cmbFuncion.TabIndex = 2;
            // 
            // txtXi
            // 
            txtXi.Location = new Point(49, 118);
            txtXi.Name = "txtXi";
            txtXi.Size = new Size(214, 27);
            txtXi.TabIndex = 4;
            // 
            // txtXf
            // 
            txtXf.Location = new Point(49, 197);
            txtXf.Name = "txtXf";
            txtXf.Size = new Size(214, 27);
            txtXf.TabIndex = 6;
            // 
            // txtEamax
            // 
            txtEamax.Location = new Point(49, 264);
            txtEamax.Name = "txtEamax";
            txtEamax.Size = new Size(214, 27);
            txtEamax.TabIndex = 8;
            // 
            // btnBiseccion
            // 
            btnBiseccion.Location = new Point(49, 326);
            btnBiseccion.Name = "btnBiseccion";
            btnBiseccion.Size = new Size(214, 39);
            btnBiseccion.TabIndex = 9;
            btnBiseccion.Text = "Biseccion";
            // 
            // btnReglaFalsa
            // 
            btnReglaFalsa.Location = new Point(49, 391);
            btnReglaFalsa.Name = "btnReglaFalsa";
            btnReglaFalsa.Size = new Size(214, 44);
            btnReglaFalsa.TabIndex = 10;
            btnReglaFalsa.Text = "Regla Falsa";
            // 
            // gridIter
            // 
            gridIter.ColumnHeadersHeight = 29;
            gridIter.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            gridIter.Location = new Point(300, 51);
            gridIter.Name = "gridIter";
            gridIter.RowHeadersWidth = 51;
            gridIter.Size = new Size(644, 524);
            gridIter.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "i";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "xi";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "xf";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "xr";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "f(xi)";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "f(xf)";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "f(xr)";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "ea (%)";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.Width = 125;
            // 
            // Form1
            // 
            ClientSize = new Size(1055, 600);
            Controls.Add(gridIter);
            Controls.Add(lblFuncion);
            Controls.Add(cmbFuncion);
            Controls.Add(lblXi);
            Controls.Add(txtXi);
            Controls.Add(lblXf);
            Controls.Add(txtXf);
            Controls.Add(lblEa);
            Controls.Add(txtEamax);
            Controls.Add(btnBiseccion);
            Controls.Add(btnReglaFalsa);
            Controls.Add(btnLimpiar);
            MinimumSize = new Size(900, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Raíces (Bisección y Regla Falsa)";
            ((System.ComponentModel.ISupportInitialize)gridIter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private ComboBox cmbFuncion;
        private TextBox txtXi;
        private TextBox txtXf;
        private TextBox txtEamax;
        private Label lblFuncion;
        private Label lblXi;
        private Label lblXf;
        private Label lblEa;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}
