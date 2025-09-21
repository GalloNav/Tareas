using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


namespace Bisección_y_Regla_Falsa
{
    /// <summary>
    /// Implementa métodos para encontrar raíces por Bisección y Regla Falsa.
    /// Mantiene el número de iteraciones en la última ejecución.
    /// </summary>
    public class RootFinder
    {
        /// <summary>
        /// Número de iteraciones usadas en el último cálculo.
        /// </summary>
        public int Iteraciones { get; private set; }

        /// <summary>
        /// Última tabla de iteraciones (opcional, para mostrar en UI).
        /// Columnas: i, xi, xf, xr, fxi, fxf, fxr, ea(%)
        /// </summary>
        public System.Collections.Generic.List<(int i, double xi, double xf, double xr, double fxi, double fxf, double fxr, double ea)> Tabla
            = new();

        /// <summary>
        /// Bisección: devuelve la raíz aproximada en el intervalo [xi, xf].
        /// eamax en porcentaje (ej. 0.0001 = 0.01% si así lo deseas; aquí se interpreta como 0.0001% si lo pasas “tal cual”).
        /// Recomendación: pasa eamax en porcentaje, por ejemplo 0.1 para 0.1%.
        /// </summary>
        public double Biseccion(Func<double, double> f, double xi, double xf, double eamaxPercent, int iterMax = 1000)
        {
            Tabla.Clear();
            Iteraciones = 0;

            double fxi = f(xi);
            double fxf = f(xf);
            if (double.IsNaN(fxi) || double.IsNaN(fxf)) throw new ArgumentException("La función regresó NaN.");
            if (fxi * fxf > 0) throw new ArgumentException("El intervalo no encierra una raíz (no hay cambio de signo).");

            double xr = xi;
            double xrold = xr;
            double ea = double.PositiveInfinity;

            for (int i = 1; i <= iterMax; i++)
            {
                xrold = xr;
                xr = (xi + xf) / 2.0;
                double fxr = f(xr);

                // Error relativo aproximado (en %)
                if (i > 1 && xr != 0.0)
                    ea = Math.Abs((xr - xrold) / xr) * 100.0;

                Iteraciones = i;
                Tabla.Add((i, xi, xf, xr, fxi, fxf, fxr, (i > 1 ? ea : double.NaN)));

                // Criterios de paro
                if (fxr == 0.0 || (i > 1 && ea <= eamaxPercent)) break;

                // Ajuste de intervalo
                if (fxi * fxr < 0)
                {
                    xf = xr;
                    fxf = fxr;
                }
                else
                {
                    xi = xr;
                    fxi = fxr;
                }
            }

            return xr;
        }

        /// <summary>
        /// Regla Falsa (False Position): devuelve la raíz aproximada en [xi, xf].
        /// eamaxPercent en porcentaje (ej. 0.1 significa 0.1%).
        /// </summary>
        public double ReglaFalsa(Func<double, double> f, double xi, double xf, double eamaxPercent, int iterMax = 1000)
        {
            Tabla.Clear();
            Iteraciones = 0;

            double fxi = f(xi);
            double fxf = f(xf);
            if (double.IsNaN(fxi) || double.IsNaN(fxf)) throw new ArgumentException("La función regresó NaN.");
            if (fxi * fxf > 0) throw new ArgumentException("El intervalo no encierra una raíz (no hay cambio de signo).");

            double xr = xi;
            double xrold = xr;
            double ea = double.PositiveInfinity;

            for (int i = 1; i <= iterMax; i++)
            {
                xrold = xr;

                // Fórmula de Regla Falsa:
                xr = xf - fxf * (xi - xf) / (fxi - fxf);

                double fxr = f(xr);

                if (i > 1 && xr != 0.0)
                    ea = Math.Abs((xr - xrold) / xr) * 100.0;

                Iteraciones = i;
                Tabla.Add((i, xi, xf, xr, fxi, fxf, fxr, (i > 1 ? ea : double.NaN)));

                if (fxr == 0.0 || (i > 1 && ea <= eamaxPercent)) break;

                if (fxi * fxr < 0)
                {
                    xf = xr;
                    fxf = fxr;
                }
                else
                {
                    xi = xr;
                    fxi = fxr;
                }
            }

            return xr;
        }

        public double NewtonRaphson(Func<double, double> f, Func<double, double> df,
                            double x0, double eamaxPercent, int iterMax = 100)
        {
            Tabla.Clear();
            Iteraciones = 0;

            double xPrev = x0;
            double xCurr = xPrev;          // solo para inicializar
            double xrold = xPrev;
            double ea = double.PositiveInfinity;

            for (int i = 1; i <= iterMax; i++)
            {
                xrold = xPrev;

                double d = df(xPrev);
                if (Math.Abs(d) < 1e-12)
                    throw new Exception("Derivada muy cercana a cero; Newton se detiene.");

                xCurr = xPrev - f(xPrev) / d;

                if (i > 1 && xCurr != 0.0)
                    ea = Math.Abs((xCurr - xrold) / xCurr) * 100.0;

                Iteraciones = i;

                // f(xi)=f(xPrev), f(xf)=NaN, f(xr)=f(xCurr)
                Tabla.Add((
                    i: i,
                    xi: xPrev,
                    xf: double.NaN,
                    xr: xCurr,
                    fxi: f(xPrev),
                    fxf: double.NaN,
                    fxr: f(xCurr),
                    ea: (i > 1 ? ea : double.NaN)
                ));

                if ((i > 1 && ea <= eamaxPercent) || f(xCurr) == 0.0)
                    break;

                xPrev = xCurr;
            }

            return xCurr;
        }


        public double Secante(Func<double, double> f, double x0, double x1,
                      double eamaxPercent, int iterMax = 100)
        {
            Tabla.Clear();
            Iteraciones = 0;

            double xPrev = x0;
            double xCurr = x1;
            double xNext = xCurr;
            double ea = double.PositiveInfinity;

            for (int i = 1; i <= iterMax; i++)
            {
                double fxPrev = f(xPrev);
                double fxCurr = f(xCurr);
                double denom = fxCurr - fxPrev;

                if (Math.Abs(denom) < 1e-12)
                    throw new Exception("División por valor muy pequeño en Secante.");

                xNext = xCurr - fxCurr * (xCurr - xPrev) / denom;

                if (xNext != 0.0)
                    ea = Math.Abs((xNext - xCurr) / xNext) * 100.0;

                Iteraciones = i;

                Tabla.Add((
                    i: i,
                    xi: xPrev,
                    xf: xCurr,
                    xr: xNext,
                    fxi: fxPrev,
                    fxf: fxCurr,
                    fxr: f(xNext),
                    ea: ea
                ));

                if (ea <= eamaxPercent || f(xNext) == 0.0)
                    break;

                xPrev = xCurr;
                xCurr = xNext;
            }

            return xNext;
        }

    }
}