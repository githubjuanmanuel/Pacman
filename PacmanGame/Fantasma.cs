using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    public class Fantasma: Personaje
    {
        //atributos
        bool buscarDireccion=true;
        int dir;
        int id;

        public int Id { get => id; }
        public Fantasma() { }
        public Fantasma(string nombre,int x,int y, int id) : base(x,y,nombre,30,30)
        {        
           this.id = id;      
        }

        public void Mover( List<ObjetoGrafico>Fantasmas,List<ObjetoGrafico>Muros)
        {
            if (buscarDireccion)
            {
                var seed = Environment.TickCount;
                Random random = new Random(seed);
                for (int i = 0; i < 10; i++)
                {
                    dir = random.Next(1, 5);
                }
                buscarDireccion = false;
            }
            else
            {
                if (!this.EvaluarColision(Muros))
                {
                    switch (dir)
                   {
                    case 1:
                            this.MoverUp();
                        break; 
                    case 2:
                            this.MoverRight();
                            break;
                    case 3: 
                                this.MoverDown();
                            break;  
                     case 4:
                                this.MoverLeft();
                            break;
                    default:
                        break;
                  }
                }
                else { 
                      buscarDireccion=true;
                       this.Rebote(10);
                
                }
            }

            if (ColisionFantasma(Fantasmas)){
                buscarDireccion = true;
            }
             
        }

        private bool ColisionFantasma(List<ObjetoGrafico>Fantasmas)
        {
            bool estado=false;
            foreach (Fantasma fan in Fantasmas)
            {   
                if(this.id!=fan.id)
                {
                    if(this.EvaluarColision(fan))
                    {
                        estado=true;
                        fan.Rebote(10);
                        this.Rebote(10);
                    }
                }
            }
            return estado;
        }
       
    }
}
