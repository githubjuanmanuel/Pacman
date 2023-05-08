using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Security.Policy;

namespace PacmanGame
{
    public class Audio
    {
        SoundPlayer player;

        public Audio() { }
        public void SeleccionarAudio(int tipoAudio)
        { 
            if(tipoAudio==1)
            {
                player = new SoundPlayer(Properties.Resources.pacman_beginning);
                player.Play();
            }
            else if(tipoAudio==2)
            {
                player = new SoundPlayer(Properties.Resources.waka);
                player.Play();
            }
            else if(tipoAudio==3)
            {
                player = new SoundPlayer(Properties.Resources.pacman_death);
                player.Play();
            }
        }

    }
}
