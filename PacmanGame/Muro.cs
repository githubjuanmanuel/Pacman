using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    public class Muro: ObjetoGrafico
    {
        public Muro() { }
        public Muro(int x, int y) : base(x, y, "muro", 18, 18)
        {
       
        }

    }
}
