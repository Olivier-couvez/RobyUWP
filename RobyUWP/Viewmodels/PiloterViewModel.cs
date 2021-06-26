using RobyUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RobyUWP.Viewmodels
{
    class PiloterViewModel
    {
        private Robot Robot1;
        private Byte[] CommandeAEnvoyer;

        public string serveurIP;
        public int serveurPort;

        Timer timer1 = new Timer();

        byte valeurHexaAvantG;
        byte valeurHexaAvantD;
        int valeurIntAvantG = 96;
        int valeurIntAvantD = 96;

        byte valeurHexaArriereG;
        byte valeurHexaArriereD;
        int valeurIntArriereG = 32;
        int valeurIntArriereD = 32;

        byte valeurHexaGaucheG;
        byte valeurHexaGaucheD;
        int valeurIntGaucheG = 16;
        int valeurIntGaucheD = 0;

        byte valeurHexaDroiteG;
        byte valeurHexaDroiteD;
        int valeurIntDroiteG = 0;
        int valeurIntDroiteD = 16;

        byte valeurHexaStopG;
        byte valeurHexaStopD;
        int valeurIntStopG = 0;
        int valeurIntStopD = 0;

        int controleVitesse = 0;
        int controleav = 64;
        int controlear = 0;


    }
}
