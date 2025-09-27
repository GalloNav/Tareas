using System.Globalization;
using Microsoft.VisualBasic;
using System.Linq;   


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
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.Font = new Font("Segoe UI", 9F);

            ConfigurarBoton(btnBiseccion, Color.FromArgb(59, 130, 246));
            ConfigurarBoton(btnReglaFalsa, Color.FromArgb(16, 185, 129));
            ConfigurarBoton(btnNewton, Color.FromArgb(99, 102, 241));
            ConfigurarBoton(btnSecante, Color.FromArgb(234, 179, 8));
            ConfigurarBoton(btnMostrarMetodos, Color.FromArgb(15, 118, 110));
            ConfigurarBoton(btnLimpiar, Color.FromArgb(239, 68, 68));

            ConfigurarDataGridView();
        }

        private void ConfigurarBoton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = AjustarBrillo(color, -0.1f);
            btn.FlatAppearance.MouseDownBackColor = AjustarBrillo(color, -0.2f);
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private static Color AjustarBrillo(Color c, float factor)
        {
            int r = Math.Max(0, Math.Min(255, (int)(c.R * (1 + factor))));
            int g = Math.Max(0, Math.Min(255, (int)(c.G * (1 + factor))));
            int b = Math.Max(0, Math.Min(255, (int)(c.B * (1 + factor))));
            return Color.FromArgb(r, g, b);
        }

        private void ConfigurarDataGridView()
        {
            gridIter.ReadOnly = true;
            gridIter.AllowUserToAddRows = false;
            gridIter.AllowUserToDeleteRows = false;
            gridIter.RowHeadersVisible = false;
            gridIter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            gridIter.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
            gridIter.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridIter.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn col in gridIter.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        // ===============================
        // Eventos
        // ===============================
        private void HookEvents()
        {
            btnBiseccion.Click += (s, e) => Ejecutar("biseccion");
            btnReglaFalsa.Click += (s, e) => Ejecutar("reglaFalsa");
            btnNewton.Click += (s, e) => Ejecutar("newton");
            btnSecante.Click += (s, e) => Ejecutar("secante");

            btnMostrarMetodos.Click += (s, e) => MostrarComparativa();

            btnLimpiar.Click += (s, e) => { gridIter.Rows.Clear(); gridIter.Refresh(); };

            // llenar combo al cambiar selección con valores sugeridos
            cmbFuncion.SelectedIndexChanged += (s, e) => CargarSugerencias();
        }

        private void ValoresIniciales()
        {
            // Cargar funciones desde la biblioteca de 5 funciones
            cmbFuncion.Items.Clear();
            foreach (var def in FunctionLibrary.ListFunction)
                cmbFuncion.Items.Add(def); // ToString() devuelve Name

            cmbFuncion.SelectedIndex = 0;
            txtEamax.Text = "0.1";  // 0.1%

            CargarSugerencias();
        }

        private void CargarSugerencias()
        {
            if (cmbFuncion.SelectedItem is FunctionDef def && def.Bracket is not null)
            {
                txtXi.Text = def.Bracket.Value.xi.ToString("0.####", CultureInfo.InvariantCulture);
                txtXf.Text = def.Bracket.Value.xf.ToString("0.####", CultureInfo.InvariantCulture);
            }
        }

        // ===============================
        // Lógica de ejecución
        // ===============================
        private void Ejecutar(string metodo)
        {
            try
            {
                if (!ValidarEntradas(out double xi, out double xf, out double eamax))
                    return;

                this.Cursor = Cursors.WaitCursor;

                var (f, df, _) = SeleccionarFuncion();
                double raiz;

                switch (metodo)
                {
                    case "biseccion":
                        raiz = _rf.Biseccion(f, xi, xf, eamax);
                        break;
                    case "reglaFalsa":
                        raiz = _rf.ReglaFalsa(f, xi, xf, eamax);
                        break;
                    case "newton":
                        if (df is null) throw new Exception("La función no tiene derivada disponible para Newton.");
                        raiz = _rf.NewtonRaphson(f, df, xi, eamax); // xi = x0
                        break;
                    case "secante":
                        raiz = _rf.Secante(f, xi, xf, eamax); // xi=x0, xf=x1
                        break;
                    default:
                        throw new NotSupportedException();
                }

                LlenarGrid();
                MostrarResultado(raiz, metodo, f);
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

        private (Func<double, double> f, Func<double, double>? df, string nombre) SeleccionarFuncion()
        {
            var def = (FunctionDef)cmbFuncion.SelectedItem!;
            return (def.f, def.df, def.Name);
        }

        private bool ValidarEntradas(out double xi, out double xf, out double eamax)

        {
            xi = xf = eamax = 0;

            if (!TryParseDouble(txtXi.Text, out xi))
            { txtXi.BackColor = Color.FromArgb(254, 226, 226); txtXi.Focus(); return false; }
            txtXi.BackColor = Color.White;

            if (!TryParseDouble(txtXf.Text, out xf))
            { txtXf.BackColor = Color.FromArgb(254, 226, 226); txtXf.Focus(); return false; }
            txtXf.BackColor = Color.White;

            if (!TryParseDouble(txtEamax.Text, out eamax))
            { txtEamax.BackColor = Color.FromArgb(254, 226, 226); txtEamax.Focus(); return false; }
            txtEamax.BackColor = Color.White;

            return true;
        }

        private void LlenarGrid()
        {
            gridIter.Rows.Clear();

            foreach (var r in _rf.Tabla)
            {
                gridIter.Rows.Add(
                    r.i.ToString(),
                    double.IsNaN(r.xi) ? "—" : r.xi.ToString("F6"),
                    double.IsNaN(r.xf) ? "—" : r.xf.ToString("F6"),
                    r.xr.ToString("F6"),
                    double.IsNaN(r.fxi) ? "—" : r.fxi.ToString("F6"),
                    double.IsNaN(r.fxf) ? "—" : r.fxf.ToString("F6"),
                    r.fxr.ToString("F6"),
                    double.IsNaN(r.ea) ? "—" : r.ea.ToString("F4")
                );
            }

            AgregarFilaResumen();
            gridIter.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void AgregarFilaResumen()
        {
            if (_rf.Tabla != null && _rf.Tabla.Count > 0)
            {
                double raiz = _rf.Tabla[^1].xr;
                var (f, _, _) = SeleccionarFuncion();
                double fRaiz = f(raiz);

                int filaSep = gridIter.Rows.Add("━━━", "━━━━━━", "━━━━━━", "━━━━━━", "━━━━━━", "━━━━━━", "━━━━━━", "━━━━━━");
                gridIter.Rows[filaSep].DefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
                gridIter.Rows[filaSep].DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184);

                int filaFinal = gridIter.Rows.Add("FINAL", "—", "—", raiz.ToString("F6"), "—", "—",
                                                  fRaiz.ToString("F6"), $"{_rf.Iteraciones} iter.");
                gridIter.Rows[filaFinal].DefaultCellStyle.BackColor = Color.FromArgb(34, 197, 94);
                gridIter.Rows[filaFinal].DefaultCellStyle.ForeColor = Color.White;
                gridIter.Rows[filaFinal].DefaultCellStyle.Font = new Font("Consolas", 9F, FontStyle.Bold);
            }
        }

        private void MostrarResultado(double raiz, string metodo, Func<double, double> f)
        {
            string nombreMetodo = metodo switch
            {
                "biseccion" => "Bisección",
                "reglaFalsa" => "Regla Falsa",
                "newton" => "Newton–Raphson",
                "secante" => "Secante",
                _ => metodo
            };

            MessageBox.Show(
                $"✓ {nombreMetodo}\nRaíz: {raiz:F6}\nf(raíz): {f(raiz):F6}\nIteraciones: {_rf.Iteraciones}",
                "Cálculo completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarComparativa()
        {
            if (!ValidarEntradas(out double xi, out double xf, out double eamax)) return;

            var (f, df, _) = SeleccionarFuncion();
            var rows = new List<(string metodo, int it, double raiz, double y, double ea)>();

            // Bisección
            double rB = _rf.Biseccion(f, xi, xf, eamax); double eaB = CalcEaFromTabla(_rf.Tabla);
            rows.Add(("Bisección", _rf.Iteraciones, rB, f(rB), eaB));

            // Regla Falsa
            double rF = _rf.ReglaFalsa(f, xi, xf, eamax); double eaF = CalcEaFromTabla(_rf.Tabla);
            rows.Add(("Regla falsa", _rf.Iteraciones, rF, f(rF), eaF));

            // Newton
            if (df is not null)
            {
                double rN = _rf.NewtonRaphson(f, df, xi, eamax); double eaN = CalcEaFromTabla(_rf.Tabla);
                rows.Add(("Newton - Raphson", _rf.Iteraciones, rN, f(rN), eaN));
            }
            else rows.Add(("Newton - Raphson", 0, double.NaN, double.NaN, double.NaN));

            // Secante
            double rS = _rf.Secante(f, xi, xf, eamax); double eaS = CalcEaFromTabla(_rf.Tabla);
            rows.Add(("Secante", _rf.Iteraciones, rS, f(rS), eaS));

            using var dlg = new Form
            {
                Text = "Comparación de métodos",
                Size = new Size(720, 320),
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false
            };
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            grid.DataSource = rows.Select(r => new
            {
                Método = r.metodo,
                Iteraciones = r.it,
                Raíz = double.IsNaN(r.raiz) ? "—" : r.raiz.ToString("0.0000"),
                Y_raíz = double.IsNaN(r.y) ? "—" : r.y.ToString("0.0000"),
                Error_aprox = double.IsNaN(r.ea) ? "—" : r.ea.ToString("0.0000")
            }).ToList();

            dlg.Controls.Add(grid);
            dlg.ShowDialog(this);
        }

        private static double CalcEaFromTabla(
            List<(int i, double xi, double xf, double xr, double fxi, double fxf, double fxr, double ea)> tabla)
        {
            if (tabla == null || tabla.Count == 0) return double.NaN;
            var last = tabla[^1];          // última fila
            return double.IsNaN(last.ea) ? 0.0 : last.ea;
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

        private void btnReglaFalsa_Click(object sender, EventArgs e)
        {

        }
    }
}