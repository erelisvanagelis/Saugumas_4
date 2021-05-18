
namespace Saugumas_4
{
    partial class MainForm
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
            this.registationButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registationButton
            // 
            this.registationButton.Location = new System.Drawing.Point(13, 13);
            this.registationButton.Name = "registationButton";
            this.registationButton.Size = new System.Drawing.Size(110, 29);
            this.registationButton.TabIndex = 0;
            this.registationButton.Text = "Registracija";
            this.registationButton.UseVisualStyleBackColor = true;
            this.registationButton.Click += new System.EventHandler(this.registationButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(129, 12);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(110, 29);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Prisijungimas";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 53);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.registationButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registacija - prisijungimas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button registationButton;
        private System.Windows.Forms.Button loginButton;
    }
}

