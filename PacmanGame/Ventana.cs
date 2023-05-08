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

    public partial class Ventana : Form
    {

        int estado = 1;
        public Ventana()
        {
            InitializeComponent();
        }

        public int Estado { get => estado; set => estado = value; }

        private void tbnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ventana_Load(object sender, EventArgs e)
        {
            if (estado == 1)
            {
                pictureBox1.Image = Properties.Resources.GameOver;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.you_win;
            }
        }
    }
}
