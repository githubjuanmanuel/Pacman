using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    public  class Dot:ObjetoGrafico
    {

        public Dot() { }
        public Dot(int x, int y) : base(x, y, "dot", 16, 16)
        {
        }
    }
}
