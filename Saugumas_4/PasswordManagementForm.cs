using Saugumas_4.Models;
using Saugumas_4.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Saugumas_4
{
    public partial class PasswordManagementForm : Saugumas_4.PasswordBaseForm
    {
        private PasswordEntry passwordEntry;
        public PasswordManagementForm()
        {
            InitializeComponent();
        }

        public PasswordManagementForm(User user) : base(user)
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                passwordEntry = user.GetPasswordEntry(titleTextBox.Text);
                if (passwordEntry == null)
                    throw new Exception("Nepavyko rasti tokio slaptažodžio");

                passwordTextBox.Text = passwordEntry.Password;
                urlTextBox.Text = passwordEntry.Url;
                commentTextBox.Text = passwordEntry.Comment;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("Hello, clipboard");
        }

        private void generationButton_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = EncryptionTool.GeneratePassword();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            PasswordEntry pe = new PasswordEntry(
                    titleTextBox.Text, passwordTextBox.Text, urlTextBox.Text, commentTextBox.Text);
        }

        private void showButton_MouseEnter(object sender, EventArgs e)
        {
            if (passwordEntry == null)
                return;

            if (passwordEntry.Password != passwordTextBox.Text)
                return;

            passwordTextBox.Text = "placeholder";
        }

        private void showButton_MouseLeave(object sender, EventArgs e)
        {
            if (passwordEntry == null)
                return;

            if (passwordEntry.Password != passwordTextBox.Text)
                return;

            passwordTextBox.Text = passwordEntry.Password;
        }

    }
}
