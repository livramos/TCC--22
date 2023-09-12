using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoHerosQuest
{
    class vida : ProgressBar
    {
        int index = 5;


        public vida()
        {

        }

        public void alterarvida(int vd)
        {
            index = vd;
        }

        public int perdevida()
        {
            if (index == 0)
                index--;
            return index;
        }



        public void location()
        {
            int X = Location.X;
            int Y = Location.Y;
        }



    }
}