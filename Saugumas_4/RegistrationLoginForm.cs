using Saugumas_4.Models;
using Saugumas_4.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saugumas_4
{
    public partial class RegistrationLoginForm : Form
    {
        private User user;
        public RegistrationLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User(nameTextBox.Text, passwordTextBox.Text);
                user.SetAccountPassword(BCrypt.Net.BCrypt.HashPassword(passwordTextBox.Text));
                Console.WriteLine(user.ToString());

                FileManager fileManager = new FileManager();
                fileManager.WriteAFile(StupidNaming.GetPathTxt(user.GetNickname()), user.ToString());
                FileEncryptionTool.EncryptCombo(StupidNaming.GetPathTxt(user.GetNickname()));

                MessageBox.Show("Pavyko prisiregistruoti");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                MessageBox.Show(exc.Message);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileManager fileManager = new FileManager();
                FileEncryptionTool.DecryptCombo(StupidNaming.GetPathAes(nameTextBox.Text));
                string[] data = fileManager.ReadFile(StupidNaming.GetPathTxt(nameTextBox.Text));
                user = UserStringConverter.GetStringToUser(data);

                if (!BCrypt.Net.BCrypt.Verify(passwordTextBox.Text, user.GetAccountPassword()))
                    throw new Exception("Slaptazodziai nesutampa");

                Form form = new ManagementForm(user);
                form.ShowDialog();
            }
            catch (Exception exc)
            {
                if (user != null)
                    FileEncryptionTool.EncryptCombo(StupidNaming.GetPathTxt(user.GetNickname()));
                MessageBox.Show(exc.Message);
            }
        }
    }
}
