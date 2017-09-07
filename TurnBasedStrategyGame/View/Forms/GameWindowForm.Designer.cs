namespace TBSG.View.Forms
{
    partial class GameWindowForm
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.FieldPanel = new System.Windows.Forms.PictureBox();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.ObjectName = new System.Windows.Forms.Label();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.Minimap = new System.Windows.Forms.PictureBox();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FieldPanel)).BeginInit();
            this.InfoPanel.SuspendLayout();
            this.SidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Minimap)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.FieldPanel);
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(727, 378);
            this.TopPanel.TabIndex = 0;
            // 
            // FieldPanel
            // 
            this.FieldPanel.Location = new System.Drawing.Point(0, 0);
            this.FieldPanel.Name = "FieldPanel";
            this.FieldPanel.Size = new System.Drawing.Size(600, 375);
            this.FieldPanel.TabIndex = 0;
            this.FieldPanel.TabStop = false;
            // 
            // InfoPanel
            // 
            this.InfoPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.InfoPanel.Controls.Add(this.ObjectName);
            this.InfoPanel.Location = new System.Drawing.Point(0, 375);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(726, 122);
            this.InfoPanel.TabIndex = 1;
            // 
            // ObjectName
            // 
            this.ObjectName.AutoSize = true;
            this.ObjectName.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObjectName.Location = new System.Drawing.Point(115, 18);
            this.ObjectName.Name = "ObjectName";
            this.ObjectName.Size = new System.Drawing.Size(164, 26);
            this.ObjectName.TabIndex = 0;
            this.ObjectName.Text = "Object name here";
            // 
            // SidePanel
            // 
            this.SidePanel.Controls.Add(this.Minimap);
            this.SidePanel.Location = new System.Drawing.Point(599, 1);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(128, 374);
            this.SidePanel.TabIndex = 2;
            // 
            // Minimap
            // 
            this.Minimap.Location = new System.Drawing.Point(0, 0);
            this.Minimap.Name = "Minimap";
            this.Minimap.Size = new System.Drawing.Size(128, 123);
            this.Minimap.TabIndex = 0;
            this.Minimap.TabStop = false;
            // 
            // GameWindowForm
            // 
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(727, 497);
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "GameWindowForm";
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FieldPanel)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.SidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Minimap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.PictureBox FieldPanel;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label ObjectName;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.PictureBox Minimap;
    }
}

