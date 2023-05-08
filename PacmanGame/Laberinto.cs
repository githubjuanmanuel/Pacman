using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGame
{
    public partial class Laberinto : Form
    {
        List<ObjetoGrafico>Muros = new List<ObjetoGrafico>();
        List<ObjetoGrafico> Dots = new List<ObjetoGrafico>();
        List<ObjetoGrafico>Fantasmas = new List<ObjetoGrafico>();
        List<ObjetoGrafico> Vidas = new List<ObjetoGrafico>();
        Pacman pacman;
        int tiempo = 0;
        Audio audio= new Audio();
        Ventana ventana;

        public Laberinto()
        {
            InitializeComponent();
          

        }

        private void Laberinto_Load(object sender, EventArgs e)
        {
            audio.SeleccionarAudio(1);
            CargarMuros();
        
            pacman = new Pacman(70,70);
            this.Controls.Add(pacman.ImagenObj);
            Fantasma fantasma1 = new Fantasma("pinky", 370, 230, 1);
            Fantasmas.Add(fantasma1);
            this.Controls.Add(fantasma1.ImagenObj);
            Fantasma fantasma2 = new Fantasma("inky", 410, 250, 2);
            Fantasmas.Add(fantasma2);         
            this.Controls.Add(fantasma2.ImagenObj);

            Fantasma fantasma3 = new Fantasma("blinky", 290, 240, 3);
            Fantasmas.Add(fantasma3);
            this.Controls.Add(fantasma3.ImagenObj);

            Fantasma fantasma4 = new Fantasma("clyde", 290, 200, 4);
            Fantasmas.Add(fantasma4);
            this.Controls.Add(fantasma4.ImagenObj);
            CargarDots();
            int X_ = 480;
            for (int i = 0; i < 4; i++)
            {
                Vidas.Add(new ObjetoGrafico(X_, 10, "bonus_life1", 15, 15));
                this.Controls.Add(Vidas.Last().ImagenObj);
                X_ += 30;
            }

        }
        public void CargarMuros()
        {
            int x, y;
            string[] strCor;
            var coor = Properties.Resources.coordenadas;
            string[] stringsCoor= coor.Split('\r');
            for (int i = 0; i < stringsCoor.Length-1; i++)
            {
                stringsCoor[i] = stringsCoor[i].Trim('\n');
                strCor = stringsCoor[i].Split(';');
                x = int.Parse(strCor[0]);
                y = int.Parse(strCor[1]);
                Muro muro = new Muro(x, y);
                this.Controls.Add(muro.ImagenObj);
                Muros.Add(muro);
            }
        }

        public void CargarDots()
        {
            int x, y;
            string[] strCor;
            var coor = Properties.Resources.dotCoor;
            string[] stringsCoor = coor.Split('\r');
            for (int i = 0; i < stringsCoor.Length; i++)
            {
                stringsCoor[i] = stringsCoor[i].Trim('\n');
                strCor = stringsCoor[i].Split(';');
                x = int.Parse(strCor[0]);
                y = int.Parse(strCor[1]);
                Dot dot = new Dot(x, y);
                this.Controls.Add(dot.ImagenObj);
                Dots.Add(dot);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pacman.Animacion();
            foreach (Fantasma fan in Fantasmas)
            {
                fan.Animacion();
                fan.Mover(Fantasmas,Muros);
            }


            int id=pacman.ComerDot(Dots);
            if(id>=0)
            {
                this.Controls.Remove(Dots.ElementAt(id).ImagenObj);
                Dots.RemoveAt(id);
                lblPuntaje.Text = "Puntaje : " + pacman.Puntaje;
                audio.SeleccionarAudio(2);
            }
            if(Dots.Count>0 && tiempo>=90)
            {
                terminarJuego(1);
            }
            if(Dots.Count==0)
            {
                terminarJuego(2);
            }

            id = pacman.Perder(Fantasmas);
            if (id >= 0)
            {
                pacman.SetPos(60, 60);
                //lblVidas.Text = "Vidas : " + pacman.Vidas;
                if (Vidas.Count > 0)
                {
                    var objVida = Vidas.Count - 1;
                    this.Controls.Remove(Vidas[objVida].ImagenObj);
                    Vidas.RemoveAt(objVida);
                }
                audio.SeleccionarAudio(3);
                if (pacman.Vidas==0)
                {
                    terminarJuego(1);
                }
            }

        }


        void terminarJuego(int estado)
        {
            ventana = new Ventana();
            ventana.Estado = estado;
            ventana.Show();
            timer1.Enabled = false;
            tiempoJuego.Enabled = false;
        }
        private void tiempoJuego_Tick(object sender, EventArgs e)
        {
            tiempo++;
            lbltiempo.Text = "Tiempo : " + tiempo;
            
        }

        private void Laberinto_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            c=char.ToUpper(c);

            if(c=='W')
            {
                if (!pacman.EvaluarColision(Muros))
                    pacman.MoverUp();
                else
                      
                    pacman.Rebote(5);
            }
            else if (c == 'S')
            {
                if (pacman.EvaluarColision(Muros))
                   pacman.Rebote(5);
                else
                  pacman.MoverDown();
            }

            else if (c == 'D')
            {
                if (pacman.EvaluarColision(Muros))
                    pacman.Rebote(5);
                else
                    pacman.MoverRight();
            }
            else if (c == 'A')
            {
                if (pacman.EvaluarColision(Muros))
                    pacman.Rebote(5);
                else
                    pacman.MoverLeft();
            }








        }
    }
}
