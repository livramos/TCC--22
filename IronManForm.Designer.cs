namespace ProjectHeroQuestVS2017
{
    partial class IronManForm
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
            this.temporizadorPrincipal = new System.Windows.Forms.Timer(this.components);
            this.background = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DropMuni = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // temporizadorPrincipal
            // 
            this.temporizadorPrincipal.Enabled = true;
            this.temporizadorPrincipal.Interval = 50;
            this.temporizadorPrincipal.Tick += new System.EventHandler(this.temporizadorPrincipal_Tick);
            // 
            // background
            // 
            this.background.Image = global::ProjetoDudas.Properties.Resources.NewYorkStage1;
            this.background.Location = new System.Drawing.Point(-4, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(988, 463);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Enabled = false;
            this.checkBox1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(437, 440);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 20);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "pause";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // DropMuni
            // 
            this.DropMuni.Interval = 10000;
            // 
            // IronManForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.background);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "IronManForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IronManForm";
            this.Load += new System.EventHandler(this.IronManForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IronManForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IronManForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer temporizadorPrincipal;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer DropMuni;
    }
}