using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExpotecAVI
{
    public partial class HomeForm : Form
    {
        int currentPageIndex;
        List<List<AulaItem>> Pages;
        const string DefaultFileEnding = ".valpk";
        const string DefaultLookupDirectory = "aulas";
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            Cursor = new Cursor("HiddenMouse.cur");
            Form back = new Form()
            {
                BackColor = Color.Black,
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                Text = "EXPOTEC AVI",
                Cursor = this.Cursor
            };
            back.GotFocus += DenyBackgroundFocus;
            this.MouseMove += DenyMouseMovement;
            back.MouseMove += DenyMouseMovement;
            back.Show();
            DenyMouseMovement(back,new MouseEventArgs(MouseButtons.None,0,0,0,0));
            this.Focus();
            if (Properties.Settings.Default.firstTime)
            {
                Sobre about = new Sobre();
                about.ShowDialog();
                Properties.Settings.Default.firstTime = false;
                Properties.Settings.Default.Save();
            }
            LoadAulas();
        }

        private void DenyMouseMovement(object sender, MouseEventArgs e)
        {
            Cursor.Position = new Point(Screen.FromControl(sender as Form).Bounds.Right, Screen.FromControl(sender as Form).Bounds.Right);
        }

        private void DenyBackgroundFocus(object sender, EventArgs e)
        {
            Focus();
        }

        #region Classes Browser mode
        private void PrepareClassesBrowsingMode(bool showPage = true)
        {
            itemsView.KeyDown -= MoreOptionsMode_KeyDownEvent;

            subTitleLabel.Text = "Selecione um vídeo abaixo para assistir";
            captionLabel.Text = "Pressione: [1 - 8] para acessar os vídeos de 1 a 8, [9] para mostrar mais e [0] para acessar mais opções";
            itemsView.LargeImageList = mainImageList;
            itemsView.View = View.LargeIcon;
            if (showPage)
            {
                ShowPage(currentPageIndex);
            }
            itemsView.KeyDown += AulaBrowsingMode_KeyDownEvent;
        }

        private void LoadAulas(string Path = DefaultLookupDirectory)
        {
            //Reset variables
            Pages = new List<List<AulaItem>>();
            currentPageIndex = 0;

            //Enumerate files
            string[] classes = Directory.EnumerateFiles(Path).ToArray();
            List<string> aulas = new List<string>();
            foreach (string class_ in classes)
            {
                if (class_.EndsWith(DefaultFileEnding))
                {
                    aulas.Add(class_);
                }
            }

            List<AulaItem> aulaPage = new List<AulaItem>(); //Create new page
            int count = 0;
            foreach (string aula in classes)
            {
                if (count == 8)
                {
                    //If items count has reached 8, add page to Pages and reset it
                    Pages.Add(aulaPage); 
                    aulaPage = new List<AulaItem>();
                    count = 0;
                }
                //Add item to page
                aulaPage.Add(GetListViewItem(aula));
                count++;
            }
            Pages.Add(aulaPage); //Add the last <=8 items page

            //Switch to the first page (currentPageIndex is 0 at start)
            ShowPage(currentPageIndex);
        }

        private void SwitchPage()
        {
            currentPageIndex++;
            if (currentPageIndex >= Pages.Count)
            {
                currentPageIndex = 0;
            }
            ShowPage(currentPageIndex);
        }

        private void ShowPage(int pgIndex)
        {
            itemsView.Items.Clear();
            List<AulaItem> page = Pages[pgIndex];
            foreach (AulaItem item in page)
            {
                itemsView.Items.Add(item);
            }
        }
        
        private AulaItem GetListViewItem(string path)
        {
            return new AulaItem()
            {
                Text = path.Substring(6,path.Length - (12)),
                ImageIndex = 0,
                FilePath = path,
            };
        }        

        private class AulaItem : ListViewItem
        {
            public string FilePath { get; set; }
        }

        private void AulaBrowsingMode_KeyDownEvent(object sender, KeyEventArgs e)
        {
            int input = Program.GetKeyNum(e.KeyCode);
            switch (input)
            {
                default:
                    AulaItem item;
                    try
                    {
                        item = itemsView.Items[input - 1] as AulaItem;
                    }
                    catch
                    {
                        return;
                    }
                    string initText = captionLabel.Text;
                    captionLabel.Text = "Carregando...";
                    captionLabel.Update();
                    AulaPlayer player = new AulaPlayer(item.FilePath)
                    {
                        Cursor = this.Cursor
                    };
                    Hide();
                    player.ShowDialog();
                    captionLabel.Text = initText;
                    Show();
                    break;
                case 9:
                    SwitchPage();
                    break;
                case 0:
                    PrepareMoreOptionsMode();
                    break;
            }

            if (input != -1)
            {
                if (input != 0 || input != 9)
                {
                    
                }
            }
            
        }

        #endregion

        #region More Options mode
        private void PrepareMoreOptionsMode()
        {
            itemsView.KeyDown -= AulaBrowsingMode_KeyDownEvent;
            subTitleLabel.Text = "Selecione uma opção abaixo";
            captionLabel.Text = "Digite a opção correspondente no teclado numérico";
            
            itemsView.Items.Clear();
            itemsView.SmallImageList = optionsImageList;
            itemsView.View = View.SmallIcon;
            AddMoreOptionsItems();

            itemsView.KeyDown += MoreOptionsMode_KeyDownEvent;
        }

        private void AddMoreOptionsItems()
        {
            string[] itemTexts = { "[1] Voltar ao menu inicial", "[2] Sobre o programa", "[3] Atualizar videoaulas", "[0] Sair do programa" };
            for (int i = 0; i < itemTexts.Length; i++)
            {
                itemsView.Items.Add(new ListViewItem()
                {
                    Text = itemTexts[i],
                    ImageIndex = i
                });
            }
        }

        private void MoreOptionsMode_KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (Program.GetKeyNum(e.KeyCode))
            {
                case 2:
                    new Sobre() { Cursor = this.Cursor }.ShowDialog();
                    goto case 1;
                case 3:
                    PrepareClassesBrowsingMode(false);
                    LoadAulas();
                    break;
                case 0:
                    MessageBox.Show("Obrigado por utilizar o EXPOTEC AVI!\n\nPressione [ENTER] para sair", "Saindo do programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Position = new Point(Screen.FromControl(this).Bounds.Right / 2, Screen.FromControl(this).Bounds.Bottom / 2);
                    Application.Exit();
                    break;
                case 1:
                    PrepareClassesBrowsingMode();
                    break;
            }
        }

        #endregion 
    }
}
