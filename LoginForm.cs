using MySql.Data.MySqlClient;
using Mysqlx;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WendyMonahanC969.Database;
using WendyMonahanC969;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using WendyMonahanC969.Classes;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;

namespace WendyMonahanC969
{
    public partial class loginScreen : Form
    {
        public static loginScreen instance;
        public string dbUserName = "";
        public string dbPassword = "";
        public int dbUserID = 0;
        public string localTimeZone = TimeZoneInfo.Local.Id;
        string currentLanguage = "English";

        public loginScreen()
        {
            InitializeComponent();
            timezoneText2.Text = localTimeZone;
        }

        private void englishRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            currentLanguage = "English";
            this.Text = "Login Screen";
            loginTitle.Text = "Login";
            timezoneText.Text = "Timezone:";
            timezoneText2.Text = localTimeZone;
            usernameText.Text = "Username";
            passwordText.Text = "Password";
            loginBtn.Text = "Login";
            exitBtn.Text = "Exit";
        }

        private void espanolRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            currentLanguage = "Espanol";
            this.Text = "Pantalla Acceso";
            loginTitle.Text = "Acceso";
            timezoneText.Text = "Zona Horaria - ";
            timezoneText2.Text = localTimeZone;
            usernameText.Text = "Nombre de Usuario";
            passwordText.Text = "Contraseña";
            loginBtn.Text = "Acceso";
            exitBtn.Text = "Salida";
        }

        

        private void loginBtn_Click(object sender, EventArgs e)
        {
            dbUserName = DBConnection.singleStringQuery("userName", "user", "userName", usernameTextBox.Text);
            dbPassword = DBConnection.singleStringQuery("password", "user", "userName", usernameTextBox.Text);
            dbUserID = DBConnection.singleIntQuery("userId", "user", "userName", usernameTextBox.Text);



            if (dbUserName == "" || dbUserName != usernameTextBox.Text || dbPassword == "" || dbPassword != passwordTextBox.Text)
            {
                if (currentLanguage == "English")
                {
                    MessageBox.Show("Invalid Username or Password");
                }
                else if (currentLanguage == "Espanol")
                {
                    MessageBox.Show("Usuario o contraseña invalido");
                }
            }
            else
            {
                DBConnection.currentUser.setDBUserInfo(dbUserID, dbUserName);

                string filePath = @"..\..\Login_History.txt";
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();
                lines.Add($"User ID# {DBConnection.currentUser.currentUserID} / UserName: \"{DBConnection.currentUser.currentUserName}\" logged in at {DateTime.UtcNow} UTC");
                File.WriteAllLines(filePath, lines);

                this.Hide();
                new MainScreen(localTimeZone).ShowDialog();
                Close();
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }
    }
}
