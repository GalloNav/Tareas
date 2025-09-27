using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bisección_y_Regla_Falsa
{
    public class FunctionDef
    {
        public string Name { get; init; } = "";
        public Func<double, double> f { get; init; } = x => 0;
        public Func<double, double>? df { get; init; }   // derivada (Newton)
        public (double xi, double xf)? Bracket { get; init; }   // sugerencias [a,b]
        public (double x0, double x1)? OpenGuess { get; init; } // sugerencias x0,x1

        public override string ToString() => Name;
    }

    public static class FunctionLibrary
    {
        public static readonly List<FunctionDef> ListFunction = new()
        {
            new FunctionDef{
                Name = "f1(x)=4x^3-6x^2+7x-2.3",
                f = x => 4*Math.Pow(x,3)-6*Math.Pow(x,2)+7*x-2.3,
                df = x => 12*Math.Pow(x,2)-12*x+7,
                Bracket = (0,1), OpenGuess=(0.0,0.2)
            },
            new FunctionDef{
                Name = "f2(x)=x^2*sqrt(|cos x|)-5",
                f = x => Math.Pow(x,2)*Math.Sqrt(Math.Abs(Math.Cos(x))) - 5,
                // derivada numérica central (para Newton)
                df = x => {
                    double h=1e-6;
                    double fp = Math.Pow(x+h,2)*Math.Sqrt(Math.Abs(Math.Cos(x+h))) - 5;
                    double fm = Math.Pow(x-h,2)*Math.Sqrt(Math.Abs(Math.Cos(x-h))) - 5;
                    return (fp - fm)/(2*h);
                },
                Bracket = (1,3), OpenGuess=(2.0,2.2)
            },
            new FunctionDef{
                Name = "f3(x)=e^{-x}-x",
                f = x => Math.Exp(-x) - x,
                df = x => -Math.Exp(-x) - 1,
                Bracket = (0,1), OpenGuess=(0.5,0.6)
            },
            new FunctionDef{
                Name = "f4(x)=x^3-x-1",
                f = x => Math.Pow(x,3) - x - 1,
                df = x => 3*Math.Pow(x,2) - 1,
                Bracket = (1,2), OpenGuess=(1.0,1.2)
            },
            new FunctionDef{
                Name = "f5(x)=ln(x+1)+x-2",
                f = x => Math.Log(x+1) + x - 2,
                df = x => 1.0/(x+1) + 1,
                Bracket = (0,2), OpenGuess=(0.5,1.0)
            }
        };
    }
}
