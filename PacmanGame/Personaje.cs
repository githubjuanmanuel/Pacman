using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PacmanGame
{
    public class Personaje: ObjetoGrafico
    {
        //atributos
        int velocidad;
        string direccion;
        int estado;

        public Personaje()
        {
            velocidad = 3;
            direccion = "right";
            estado = 1;
        }

        public Personaje(int x, int y, string nombre, int w, int h)
            : base(x, y, nombre, w, h)
        {
            velocidad = 3;
            direccion = "right";
            estado = 1;
        }
        public void Animacion()
        {
            string nombre_rec = "";
            switch(estado) { 
            case 1:
                    nombre_rec = this.nombreRecurso + '_' + estado + '_' + direccion;
                    estado = 2;
                    break;
             case 2:
                    nombre_rec= this.nombreRecurso + '_' + estado + '_' + direccion;
                    estado = 1;
                    break;
            }

            this.ImagenObj.Image =(Image)Properties.
                Resources.ResourceManager.GetObject(nombre_rec);
        }

        public void MoverUp()
        {
            direccion = "up";
            Posy -= velocidad;
            SetPos(Posx, Posy);
        }

        public void MoverDown()
        {
            direccion = "down";
            Posy += velocidad;
            SetPos(Posx, Posy);
        }
        public void MoverLeft()
        {
            direccion = "left";
            Posx -= velocidad;
            SetPos(Posx, Posy);
        }

        public void MoverRight()
        {
            direccion = "right";
            Posx += velocidad;
            SetPos(Posx, Posy);
        }

        public bool EvaluarColision(List<ObjetoGrafico> objetos)
        {
            for(int i=0;i<objetos.Count; i++)
            {
                if(this.GetRectangle().IntersectsWith(objetos[i].GetRectangle()))
                  return true;
            }
            return false;   
        }

        public bool EvaluarColision(ObjetoGrafico objeto)
        {
             if (this.GetRectangle().IntersectsWith(objeto.GetRectangle()))
                    return true;
            
            return false;
        }
        public void Rebote(int vel)
        {
            switch(direccion)
            {
                case "up":
                    this.Posy += vel;
                    direccion = "down";
                    break;
                case "down":
                    this.Posy -= vel;
                    direccion = "up";
                    break;
                case "left":
                    this.Posx += vel;
                    direccion = "right";
                    break;
                case "right":
                    this.Posx -= vel;
                    direccion = "left";
                    break;

            }
            SetPos(Posx, Posy); 
        }
    }
}
