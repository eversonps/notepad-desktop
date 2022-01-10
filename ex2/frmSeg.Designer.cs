namespace ex2
{
    partial class frmSeg
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
            this.rchNotepad = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rchNotepad
            // 
            this.rchNotepad.Location = new System.Drawing.Point(0, 0);
            this.rchNotepad.Name = "rchNotepad";
            this.rchNotepad.Size = new System.Drawing.Size(1365, 1000);
            this.rchNotepad.TabIndex = 0;
            this.rchNotepad.Text = "";
            // 
            // frmSeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 383);
            this.Controls.Add(this.rchNotepad);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Name = "frmSeg";
            this.Text = "Sem Título";
            this.Load += new System.EventHandler(this.frmSeg_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rchNotepad;
    }
}