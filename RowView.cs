using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisección_y_Regla_Falsa
{
    class RowView
    {
        public string Método { get; set; } = "";
        public int Iteraciones { get; set; }
        public double Raíz { get; set; }
        public double Y_raíz { get; set; }
        public double Error_aprox { get; set; }
    }
}
