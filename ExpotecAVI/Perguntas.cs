using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpotecAVI
{
    public partial class Perguntas : Form
    {
        private VideoAulaPackage Pack;
        private int CurrentAulaIndex;

        public Perguntas(VideoAulaPackage pack, int index)
        {
            InitializeComponent();
            Pack = pack;
            AddItems(pack.VideoAulas[index].Duvidas);
            CurrentAulaIndex = index;
        }

        private void AddItems(string[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                listBox1.Items.Add("[" + (i + 1) + "] " + items[i]);
            }
            listBox1.Items.Add("-----------------");
            listBox1.Items.Add("[0] Sem dúvidas");
        }

        private void Perguntas_KeyDown(object sender, KeyEventArgs e)
        {
            int input = Program.GetKeyNum(e.KeyCode);
            switch (input)
            {
                case 0:
                    Close();
                    break;
                case -1:
                    break;
                default:
                    if (input <= Pack.VideoAulas[CurrentAulaIndex].Duvidas.Length)
                    {
                        AulaPlayer player = new AulaPlayer(Pack.GetDuvidaVideoPathByIndexes(CurrentAulaIndex,input - 1), AulaPlayer.OperationMode.QuestionPlayer) { Cursor = this.Cursor };
                        player.label1.Text = Pack.VideoAulas[CurrentAulaIndex].Duvidas[input - 1];
                        player.Text = "Resolução de dúvidas";
                        player.ShowDialog();
                    }
                    break;
            }
        }
    }
}
