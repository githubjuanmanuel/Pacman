using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    public class Pacman: Personaje
    {
        //atributos
        int puntaje=0;
        int vidas;

        public Pacman()
        {
            vidas = 4;


        }
        public Pacman(int x, int y)
            :base(x,y,"pacman",30,30)
        {
            vidas = 4;
        }

        public int Puntaje { get => puntaje;}
        public int Vidas { get => vidas;}

        public int ComerDot(List<ObjetoGrafico> objetos )
        {
            int id = -1;
            for (int i = 0; i < objetos.Count; i++)
            {
                if (this.EvaluarColision(objetos[i]))
                {
                    id = i;
                    puntaje++;
                }    
            }
            return id;
        }

        public int Perder(List<ObjetoGrafico> fantasmas)
        {
            int id = -1;
            for (int i = 0; i < fantasmas.Count; i++)
            {
                if (this.EvaluarColision(fantasmas[i]))
                {
                    id = i;
                    if (vidas > 0)
                        vidas--;
                    break;
                }
            }
            return id;
        }


    }
}
