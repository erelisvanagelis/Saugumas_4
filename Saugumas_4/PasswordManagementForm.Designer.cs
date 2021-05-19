
namespace Saugumas_4
{
    partial class PasswordManagementForm
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
            this.copyButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 13);
            // 
            // textBox3
            // 
            this.urlTextBox.Location = new System.Drawing.Point(121, 144);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(69, 147);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 176);
            // 
            // richTextBox1
            // 
            this.commentTextBox.Location = new System.Drawing.Point(121, 173);
            this.commentTextBox.Size = new System.Drawing.Size(276, 81);
            // 
            // generationButton
            // 
            this.generationButton.Location = new System.Drawing.Point(274, 109);
            this.generationButton.Size = new System.Drawing.Size(123, 29);
            this.generationButton.Text = "Generuoti";
            this.generationButton.Click += new System.EventHandler(this.generationButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 80);
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Visible = false;
            // 
            // textBox2
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(121, 77);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(145, 109);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(123, 29);
            this.copyButton.TabIndex = 12;
            this.copyButton.Text = "Kopijuoti";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(16, 42);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(381, 29);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Ieškoti";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 260);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(187, 29);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "Trinti";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(210, 260);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(187, 29);
            this.updateButton.TabIndex = 15;
            this.updateButton.Text = "Atnaujinti";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(16, 109);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(123, 29);
            this.showButton.TabIndex = 16;
            this.showButton.Text = "Rodyti";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // PasswordManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(409, 297);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.copyButton);
            this.Name = "PasswordManagementForm";
            this.Controls.SetChildIndex(this.titleTextBox, 0);
            this.Controls.SetChildIndex(this.passwordTextBox, 0);
            this.Controls.SetChildIndex(this.addButton, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.urlTextBox, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.commentTextBox, 0);
            this.Controls.SetChildIndex(this.generationButton, 0);
            this.Controls.SetChildIndex(this.copyButton, 0);
            this.Controls.SetChildIndex(this.searchButton, 0);
            this.Controls.SetChildIndex(this.deleteButton, 0);
            this.Controls.SetChildIndex(this.updateButton, 0);
            this.Controls.SetChildIndex(this.showButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button showButton;
    }
}
