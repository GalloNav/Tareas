using System.Globalization;

namespace Bisección_y_Regla_Falsa
{
    public partial class Form1 : Form
    {
        private Button btnBiseccion;
        private Button btnReglaFalsa;
        private Button btnLimpiar;
        private DataGridView gridIter;
        private readonly RootFinder _rf = new RootFinder();

        public Form1()
        {
            InitializeComponent();
            ConfigurarEstilos();
            HookEvents();
            ValoresIniciales();
        }

        private void ConfigurarEstilos()
        {
            // Configuración general del formulario
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            // Estilo de botones
            ConfigurarBoton(btnBiseccion, Color.FromArgb(59, 130, 246), "Método de Bisección");
            ConfigurarBoton(btnReglaFalsa, Color.FromArgb(16, 185, 129), "Método de Regla Falsa");
            ConfigurarBoton(btnLimpiar, Color.FromArgb(239, 68, 68), "Limpiar Tabla");

            // Estilo del DataGridView
            ConfigurarDataGridView();

            // Estilo de los TextBox y Labels
            ConfigurarControlesEntrada();

            // Estilo del ComboBox
            ConfigurarComboBox();
        }

        private void ConfigurarBoton(Button btn, Color colorFondo, string tooltip = "")
        {
            btn.BackColor = colorFondo;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = AjustarBrillo(colorFondo, -0.1f);
            btn.FlatAppearance.MouseDownBackColor = AjustarBrillo(colorFondo, -0.2f);
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 35;

            // Agregar efecto hover
            btn.MouseEnter += (s, e) => {
                btn.BackColor = AjustarBrillo(colorFondo, -0.1f);
            };
            btn.MouseLeave += (s, e) => {
                btn.BackColor = colorFondo;
            };

            if (!string.IsNullOrEmpty(tooltip))
            {
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(btn, tooltip);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Estilo general
            gridIter.BackgroundColor = Color.White;
            gridIter.BorderStyle = BorderStyle.None;
            gridIter.CellBorderStyle = DataGridViewCellBorderStyle.None;
            gridIter.EnableHeadersVisualStyles = false;
            gridIter.GridColor = Color.FromArgb(226, 232, 240);
            gridIter.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridIter.MultiSelect = false;
            gridIter.ReadOnly = true;
            gridIter.AllowUserToAddRows = false;
            gridIter.AllowUserToDeleteRows = false;
            gridIter.AllowUserToResizeRows = false;
            gridIter.RowHeadersVisible = false;

            // Estilo de encabezados
            gridIter.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            gridIter.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridIter.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridIter.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIter.ColumnHeadersHeight = 40;

            // Estilo de celdas
            gridIter.DefaultCellStyle.BackColor = Color.White;
            gridIter.DefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            gridIter.DefaultCellStyle.Font = new Font("Consolas", 9F);
            gridIter.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIter.DefaultCellStyle.Padding = new Padding(5);
            gridIter.RowTemplate.Height = 30;

            // Estilo de filas alternadas
            gridIter.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            // Estilo de selección
            gridIter.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246);
            gridIter.DefaultCellStyle.SelectionForeColor = Color.White;

            // Configurar columnas si existen
            if (gridIter.Columns.Count > 0)
            {
                foreach (DataGridViewColumn col in gridIter.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void ConfigurarControlesEntrada()
        {
            // Buscar todos los TextBox y Labels en el formulario
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt)
                {
                    ConfigurarTextBox(txt);
                }
                else if (control is Label lbl)
                {
                    ConfigurarLabel(lbl);
                }

                // Buscar en contenedores anidados (GroupBox, Panel, etc.)
                ConfigurarControlesEnContenedor(control);
            }
        }

        private void ConfigurarControlesEnContenedor(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is TextBox txt)
                {
                    ConfigurarTextBox(txt);
                }
                else if (control is Label lbl)
                {
                    ConfigurarLabel(lbl);
                }
                else if (control.HasChildren)
                {
                    ConfigurarControlesEnContenedor(control);
                }
            }
        }

        private void ConfigurarTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.ForeColor = Color.FromArgb(51, 65, 85);
            txt.Font = new Font("Segoe UI", 9F);
            txt.Height = 25;

            // Agregar efectos de focus
            txt.Enter += (s, e) => {
                txt.BackColor = Color.FromArgb(239, 246, 255);
            };
            txt.Leave += (s, e) => {
                txt.BackColor = Color.White;
            };
        }

        private void ConfigurarLabel(Label lbl)
        {
            lbl.ForeColor = Color.FromArgb(71, 85, 105);
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        private void ConfigurarComboBox()
        {
            // Buscar el ComboBox en el formulario
            var cmb = this.Controls.OfType<ComboBox>().FirstOrDefault();
            if (cmb == null)
            {
                // Buscar en contenedores anidados
                cmb = BuscarComboBoxEnContenedores(this);
            }

            if (cmb != null)
            {
                cmb.FlatStyle = FlatStyle.Flat;
                cmb.BackColor = Color.White;
                cmb.ForeColor = Color.FromArgb(51, 65, 85);
                cmb.Font = new Font("Segoe UI", 9F);
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private ComboBox BuscarComboBoxEnContenedores(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is ComboBox cmb)
                    return cmb;

                if (control.HasChildren)
                {
                    var resultado = BuscarComboBoxEnContenedores(control);
                    if (resultado != null)
                        return resultado;
                }
            }
            return null;
        }

        private Color AjustarBrillo(Color color, float factor)
        {
            int r = Math.Max(0, Math.Min(255, (int)(color.R * (1 + factor))));
            int g = Math.Max(0, Math.Min(255, (int)(color.G * (1 + factor))));
            int b = Math.Max(0, Math.Min(255, (int)(color.B * (1 + factor))));
            return Color.FromArgb(r, g, b);
        }

        private void HookEvents()
        {
            btnBiseccion.Click += (s, e) => Ejecutar("biseccion");
            btnReglaFalsa.Click += (s, e) => Ejecutar("reglaFalsa");
            btnLimpiar.Click += (s, e) => {
                gridIter.Rows.Clear();
                // Agregar animación de limpieza
                this.Refresh();
            };
        }

        private void ValoresIniciales()
        {
            txtXi.Text = "0.0";
            txtXf.Text = "1.0";
            txtEamax.Text = "0.1"; // 0.1% (en porcentaje)
        }

        private void Ejecutar(string metodo)
        {
            try
            {
                // Validar entrada con mejor feedback visual
                if (!ValidarEntradas(out double xi, out double xf, out double eamax))
                {
                    return;
                }

                // Mostrar indicador de carga
                this.Cursor = Cursors.WaitCursor;

                var f = SeleccionarFuncion();
                double raiz = (metodo == "biseccion")
                    ? _rf.Biseccion(f, xi, xf, eamax)
                    : _rf.ReglaFalsa(f, xi, xf, eamax);

                LlenarGrid();

                // Mostrar mensaje de éxito
                MostrarResultado(raiz, metodo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en el cálculo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private bool ValidarEntradas(out double xi, out double xf, out double eamax)
        {
            xi = xf = eamax = 0;

            var textBoxes = new[] {
                (txtXi, "Valor inicial Xi"),
                (txtXf, "Valor final Xf"),
                (txtEamax, "Error máximo")
            };

            foreach (var (txt, nombre) in textBoxes)
            {
                if (!TryParseDouble(txt.Text, out double valor))
                {
                    txt.BackColor = Color.FromArgb(254, 226, 226); // Rojo claro
                    MessageBox.Show($"El valor de {nombre} no es válido.", "Datos inválidos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt.Focus();
                    return false;
                }
                txt.BackColor = Color.White;
            }

            if (!TryParseDouble(txtXi.Text, out xi) ||
                !TryParseDouble(txtXf.Text, out xf) ||
                !TryParseDouble(txtEamax.Text, out eamax))
            {
                return false;
            }

            return true;
        }

        private void MostrarResultado(double raiz, string metodo)
        {
            string nombreMetodo = metodo == "biseccion" ? "Bisección" : "Regla Falsa";
            string mensaje = $"✓ {nombreMetodo} completado\n" +
                           $"Raíz encontrada: {raiz:F6}\n" +
                           $"Iteraciones: {_rf.Iteraciones}\n";
                           //$"Error final: {(_rf.Tabla.LastOrDefault()?.ea ?? 0):F6}%";

            MessageBox.Show(mensaje, "Cálculo completado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Func<double, double> SeleccionarFuncion()
        {
            Func<double, double> f = (x) => 4 * Math.Pow(x, 3) - 6 * Math.Pow(x, 2) + 7 * x - 2.3;
            Func<double, double> g = (x) => Math.Pow(x, 2) * Math.Sqrt(Math.Abs(Math.Cos(x))) - 5;
            return cmbFuncion.SelectedIndex == 0 ? f : g;
        }

        private void LlenarGrid()
        {
            gridIter.Rows.Clear();

            foreach (var r in _rf.Tabla)
            {
                var fila = gridIter.Rows.Add(
                    r.i.ToString(),
                    r.xi.ToString("F6"),
                    r.xf.ToString("F6"),
                    r.xr.ToString("F6"),
                    r.fxi.ToString("F6"),
                    r.fxf.ToString("F6"),
                    r.fxr.ToString("F6"),
                    double.IsNaN(r.ea) ? "—" : r.ea.ToString("F2") + "%"
                );
            }

            // Agregar fila de resumen con estilo especial
            AgregarFilaResumen();

            // Auto-ajustar columnas
            gridIter.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void AgregarFilaResumen()
        {
            if (_rf.Tabla != null && _rf.Tabla.Count > 0)
            {
                double raiz = _rf.Tabla[_rf.Tabla.Count - 1].xr;
                double fRaiz = SeleccionarFuncion()(raiz);

                // Agregar línea separadora
                var filaSeparadora = gridIter.Rows.Add("━━━", "━━━━━━", "━━━━━━", "━━━━━━", "━━━━━━", "━━━━━━", "━━━━━━", "━━━━━━");
                gridIter.Rows[filaSeparadora].DefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
                gridIter.Rows[filaSeparadora].DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184);

                // Agregar fila de resultado final
                var filaFinal = gridIter.Rows.Add("FINAL", "—", "—", raiz.ToString("F6"), "—", "—",
                                                  fRaiz.ToString("F6"), $"{_rf.Iteraciones} iter.");

                // Estilo especial para la fila final
                gridIter.Rows[filaFinal].DefaultCellStyle.BackColor = Color.FromArgb(34, 197, 94);
                gridIter.Rows[filaFinal].DefaultCellStyle.ForeColor = Color.White;
                gridIter.Rows[filaFinal].DefaultCellStyle.Font = new Font("Consolas", 9F, FontStyle.Bold);
            }
        }

        private bool TryParseDouble(string s, out double value)
        {
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out value))
                return true;
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return true;
            return false;
        }

        private void lblXf_Click(object sender, EventArgs e)
        {
            // Método vacío mantenido para compatibilidad
        }
    }
}