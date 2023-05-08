using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PacmanGame
{
    public class ObjetoGrafico
    {
        private PictureBox imagenObj;
        int posx;
        int posy;
        protected string nombreRecurso;
         public ObjetoGrafico()
        {

        }
        public ObjetoGrafico(int x, int y, string nombre,
            int w,int h)
        {
            nombreRecurso = nombre;
            posx = x;
            posy = y;   

            imagenObj = new PictureBox();
            imagenObj.Width = w;
            imagenObj.Height = h;
            imagenObj.Location = new Point(x, y);
            imagenObj.Image = (Image)(Properties.
                Resources.ResourceManager.GetObject(nombre));
            imagenObj.SizeMode = PictureBoxSizeMode.StretchImage;
            imagenObj.BackColor = Color.Transparent;

        }

        public int Posx { get => posx; set => posx = value; }
        public int Posy { get => posy; set => posy = value; }
        public PictureBox ImagenObj { get => imagenObj; set => imagenObj = value; }

        public void SetPos(int x, int y)
        {
            this.posx = x;
            this.posy = y;
            imagenObj.Location= new Point(x, y);
        }

        public Rectangle GetRectangle()
        {
            return imagenObj.Bounds;
        }
    }
}
