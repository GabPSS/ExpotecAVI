using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace ExpotecAVI
{
    public partial class AulaPlayer : Form
    {
        public enum OperationMode { AulaPlayer, QuestionPlayer}
        public OperationMode OpMode { get; set; }
        VideoAulaPackage pack;
        int CurrentVideo = -1;
        private readonly string filePath;

        public AulaPlayer(string aulaPath, OperationMode mode = OperationMode.AulaPlayer)
        {
            InitializeComponent();

            OpMode = mode;
            filePath = aulaPath;
            if (OpMode == OperationMode.AulaPlayer)
            {
                try
                {
                    pack = new VideoAulaPackage(aulaPath);
                    Text = pack.PackageTitle;
                }
                catch
                {
                    MessageBox.Show("ERRO ao tentar carregar a videoaula especificada!\n\nCaminho: " + aulaPath + "\nVerifique se o programa pode acessar o arquivo especificado. Caso não funcione, tente reinstalar o programa\n\nPressione [ENTER] para voltar à tela inicial", "Erro ao carregar videoaula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            switch (OpMode)
            {
                case OperationMode.AulaPlayer:
                    SwitchAula();
                    break;
                case OperationMode.QuestionPlayer:
                    axWindowsMediaPlayer2.URL = filePath;
                    break;
            }
            this.KeyDown += Playback_Event;
            axWindowsMediaPlayer2.Ctlcontrols.play();
            playbackTimer.Start();
        }

        private bool SwitchAula()
        {
            CurrentVideo++;
            if (CurrentVideo >= pack.VideoAulas.Length)
            {
                Close();
                return false;
            }
            label1.Text = pack.VideoAulas[CurrentVideo].Title;
            axWindowsMediaPlayer2.URL = pack.GetVideoPathByIndex(CurrentVideo);
            return true;
        }

        /// <summary>
        /// Handles keypresses when current mode is playback
        /// </summary>
        private void Playback_Event(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                default:
                    break;
                case Keys.NumPad5:
                    if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPaused)
                    {
                        axWindowsMediaPlayer2.Ctlcontrols.play();
                    }
                    else
                    {
                        axWindowsMediaPlayer2.Ctlcontrols.pause();
                    }
                    break;
                case Keys.NumPad4:
                    axWindowsMediaPlayer2.Ctlcontrols.currentPosition -= 10;
                    break;
                case Keys.NumPad6:
                    axWindowsMediaPlayer2.Ctlcontrols.currentPosition += 10;
                    break;
                case Keys.NumPad0:
                    Close();
                    break;
            }

        }

        /// <summary>
        /// Handles keypresses when current mode is duvidas waiting time
        /// </summary>
        private void Duvidas_Event(object sender, KeyEventArgs e)
        {
            questionTimer.Stop();
            progressBar1.Value = progressBar1.Maximum;
            Perguntas pg = new Perguntas(pack, CurrentVideo) { Cursor = this.Cursor };
            pg.ShowDialog();
            questionTimer.Start();
        }

        /// <summary>
        /// Redirects key events when media player is focused
        /// </summary>
        private void axWindowsMediaPlayer2_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            OnKeyDown(new KeyEventArgs(ConvertWMPKeyCode(e.nKeyCode)));
        }


        private void playbackTimer_Tick(object sender, System.EventArgs e)
        {
            if (axWindowsMediaPlayer2.IsDisposed)
            {
                return;
            }
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                switch (OpMode)
                {
                    case OperationMode.AulaPlayer:
                        //Begin Duvidas mode ================

                        //Switch keypress events
                        this.KeyDown -= Playback_Event;
                        this.KeyDown += Duvidas_Event;

                        //Visual changes
                        label1.Text = "Pressione QUALQUER TECLA para fazer uma pergunta";
                        label1.Height = 20;
                        progressBar1.Show();
                
                        //Switch timers
                        playbackTimer.Stop();
                        questionTimer.Start();
                        break;
                    case OperationMode.QuestionPlayer:
                        Close();
                        break;
                }
            }
        }

        //int startDuration = 50;
        //int counter = 0;
        private void questionTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                progressBar1.Value = 0;
                progressBar1.Hide();
                label1.Height = 41;

                questionTimer.Stop();
                KeyDown -= Duvidas_Event;
                if (SwitchAula())
                {
                    KeyDown += Playback_Event;
                    playbackTimer.Start();
                }
            }
        }

        /// <summary>
        /// Closes the form safely
        /// </summary>
        private void AulaPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            playbackTimer.Stop();
            questionTimer.Stop();
            axWindowsMediaPlayer2.Ctlcontrols.stop();
            axWindowsMediaPlayer2.Update();
            axWindowsMediaPlayer2.Dispose();
            if (OpMode == OperationMode.AulaPlayer)
            {
                pack.Dispose();
            }
        }

        
        private static Keys ConvertWMPKeyCode(short nKeyCode)
        {
            if (nKeyCode >= 96 && nKeyCode <= 105)
            {
                return (Keys)nKeyCode;
            }
            else
            {
                return Keys.Back;
            }
        }
    }
}