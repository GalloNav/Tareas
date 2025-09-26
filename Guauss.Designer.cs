namespace Bisección_y_Regla_Falsa
{
    partial class Guauss
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nudN = new NumericUpDown();
            btnCrear = new Button();
            btnGauss = new Button();
            btnGaussJordan = new Button();
            grid = new DataGridView();
            chkPivot = new CheckBox();
            txtSol = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // nudN
            // 
            nudN.Location = new Point(38, 44);
            nudN.Name = "nudN";
            nudN.Size = new Size(150, 29);
            nudN.TabIndex = 0;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(38, 117);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(131, 29);
            btnCrear.TabIndex = 1;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            // 
            // btnGauss
            // 
            btnGauss.Location = new Point(38, 218);
            btnGauss.Name = "btnGauss";
            btnGauss.Size = new Size(131, 29);
            btnGauss.TabIndex = 2;
            btnGauss.Text = "Gauss";
            btnGauss.UseVisualStyleBackColor = true;
            // 
            // btnGaussJordan
            // 
            btnGaussJordan.Location = new Point(38, 278);
            btnGaussJordan.Name = "btnGaussJordan";
            btnGaussJordan.Size = new Size(131, 29);
            btnGaussJordan.TabIndex = 3;
            btnGaussJordan.Text = "Gauss-Jordan";
            btnGaussJordan.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(352, 61);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersWidth = 51;
            grid.Size = new Size(689, 488);
            grid.TabIndex = 4;
            // 
            // chkPivot
            // 
            chkPivot.AutoSize = true;
            chkPivot.Checked = true;
            chkPivot.CheckState = CheckState.Checked;
            chkPivot.Location = new Point(57, 467);
            chkPivot.Name = "chkPivot";
            chkPivot.Size = new Size(84, 25);
            chkPivot.TabIndex = 5;
            chkPivot.Text = "Pivoteo";
            chkPivot.UseVisualStyleBackColor = true;
            // 
            // txtSol
            // 
            txtSol.Location = new Point(38, 531);
            txtSol.Name = "txtSol";
            txtSol.Size = new Size(267, 29);
            txtSol.TabIndex = 6;
            // 
            // Guauss
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 653);
            Controls.Add(txtSol);
            Controls.Add(chkPivot);
            Controls.Add(grid);
            Controls.Add(btnGaussJordan);
            Controls.Add(btnGauss);
            Controls.Add(btnCrear);
            Controls.Add(nudN);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Guauss";
            Text = "Metodo de Gauss y Gauss Jordan";
            ((System.ComponentModel.ISupportInitialize)nudN).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudN;
        private Button btnCrear;
        private Button btnGauss;
        private Button btnGaussJordan;
        private DataGridView grid;
        private CheckBox chkPivot;
        private TextBox txtSol;
    }
}