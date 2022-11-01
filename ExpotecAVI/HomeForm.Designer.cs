namespace ExpotecAVI
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subTitleLabel = new System.Windows.Forms.Label();
            this.itemsView = new System.Windows.Forms.ListView();
            this.mainImageList = new System.Windows.Forms.ImageList(this.components);
            this.captionLabel = new System.Windows.Forms.Label();
            this.optionsImageList = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.subTitleLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.itemsView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.captionLabel, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(719, 402);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(262, 18);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(195, 31);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "EXPOTEC AVI";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // subTitleLabel
            // 
            this.subTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.subTitleLabel.AutoSize = true;
            this.subTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTitleLabel.Location = new System.Drawing.Point(217, 52);
            this.subTitleLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.subTitleLabel.Name = "subTitleLabel";
            this.subTitleLabel.Size = new System.Drawing.Size(285, 20);
            this.subTitleLabel.TabIndex = 1;
            this.subTitleLabel.Text = "Selecione um vídeo abaixo para assistir";
            this.subTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemsView
            // 
            this.itemsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsView.HideSelection = false;
            this.itemsView.LargeImageList = this.mainImageList;
            this.itemsView.Location = new System.Drawing.Point(10, 84);
            this.itemsView.Margin = new System.Windows.Forms.Padding(10);
            this.itemsView.Name = "itemsView";
            this.itemsView.Size = new System.Drawing.Size(699, 270);
            this.itemsView.TabIndex = 2;
            this.itemsView.UseCompatibleStateImageBehavior = false;
            this.itemsView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AulaBrowsingMode_KeyDownEvent);
            // 
            // mainImageList
            // 
            this.mainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainImageList.ImageStream")));
            this.mainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mainImageList.Images.SetKeyName(0, "default.png");
            // 
            // captionLabel
            // 
            this.captionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.captionLabel.AutoSize = true;
            this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captionLabel.Location = new System.Drawing.Point(12, 374);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(695, 18);
            this.captionLabel.TabIndex = 3;
            this.captionLabel.Text = "Pressione: [1 - 8] para acessar os vídeos de 1 a 8, [9] para mostrar mais e [0] p" +
    "ara acessar mais opções";
            // 
            // optionsImageList
            // 
            this.optionsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("optionsImageList.ImageStream")));
            this.optionsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.optionsImageList.Images.SetKeyName(0, "home_FILL0_wght400_GRAD0_opsz48.png");
            this.optionsImageList.Images.SetKeyName(1, "info_FILL0_wght400_GRAD0_opsz48.png");
            this.optionsImageList.Images.SetKeyName(2, "sync_FILL0_wght400_GRAD0_opsz48.png");
            this.optionsImageList.Images.SetKeyName(3, "logout_FILL0_wght400_GRAD0_opsz48.png");
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(719, 402);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HomeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXPOTEC AVI";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subTitleLabel;
        private System.Windows.Forms.ListView itemsView;
        private System.Windows.Forms.ImageList mainImageList;
        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.ImageList optionsImageList;
    }
}