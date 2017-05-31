namespace Client
{
    partial class Items
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
            this.Itembox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Itembox
            // 
            this.Itembox.FormattingEnabled = true;
            this.Itembox.ItemHeight = 16;
            this.Itembox.Location = new System.Drawing.Point(363, 149);
            this.Itembox.Name = "Itembox";
            this.Itembox.Size = new System.Drawing.Size(117, 148);
            this.Itembox.TabIndex = 0;
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 402);
            this.Controls.Add(this.Itembox);
            this.Name = "Items";
            this.Text = "Items";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Itembox;
    }
}