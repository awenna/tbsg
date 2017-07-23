namespace TBSG.View
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.fieldPanel = new FieldPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            KeyPreview = true;
            PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(GameWindowForm_PreviewKeyDown);
            KeyDown += new System.Windows.Forms.KeyEventHandler(GameWindowForm_KeyPress);

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += new System.EventHandler(timer_Tick);
            timer.Start();
            // 
            // fieldPanel
            // 
            this.fieldPanel.Location = new System.Drawing.Point(0, 0);
            this.fieldPanel.Name = "fieldPanel";
            this.fieldPanel.Size = new System.Drawing.Size(
                mConfigurationProvider.GetValue<int>("FieldPanelSizeX"),
                mConfigurationProvider.GetValue<int>("FieldPanelSizeY"));
            this.fieldPanel.TabIndex = 1;
            this.fieldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.field_Paint);
            // 
            // GameWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(
                mConfigurationProvider.GetValue<int>("WindowSizeX"),
                mConfigurationProvider.GetValue<int>("WindowSizeY"));
            this.Controls.Add(this.fieldPanel);
            this.Controls.Add(this.panel1);
            this.Name = "GameWindowForm";
            this.Text = "GameWindowForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private FieldPanel fieldPanel;
    }
}

