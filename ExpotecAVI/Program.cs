using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpotecAVI
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm());
        }

        /// <summary>
        /// Return an integer corresponding to the number of a pressed Numpad key
        /// </summary>
        public static int GetKeyNum(Keys key)
        {
            switch (key)
            {
                default:
                    return -1;
                case Keys.NumPad1:
                    return 1;
                case Keys.NumPad2:
                    return 2;
                case Keys.NumPad3:
                    return 3;
                case Keys.NumPad4:
                    return 4;
                case Keys.NumPad5:
                    return 5;
                case Keys.NumPad6:
                    return 6;
                case Keys.NumPad7:
                    return 7;
                case Keys.NumPad8:
                    return 8;
                case Keys.NumPad9:
                    return 9;
                case Keys.NumPad0:
                    return 0;
            }
        }
    }
}
