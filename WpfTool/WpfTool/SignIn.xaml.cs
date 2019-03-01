using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Net;

namespace WpfTool
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            Unhidden.Visibility = Visibility.Hidden;
            SetWindowTheme();
        }
        void AttemptLogin(object sender, RoutedEventArgs e)
        {
            string SaveFileLocation = @"SaveFile.txt";//Location where the save file is stored


            string[] Lines = System.IO.File.ReadAllLines(SaveFileLocation);//Retrieve the lines from the text file

            Password.Password = Unhidden.Text;


            //Using the username cycle through the save of the users accounts
            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].ToLower().CompareTo("#" + Username.Text.ToLower()) == 0)//If the username entered is a username
                {

                    for (int j = i; j < Lines.Length; j++)
                        if (Lines[j].Length != 0 && Lines[j][0] == '$')
                            DateTime.TryParse(Lines[j].Split('$')[1], out Controller.CurrentUser.CreationDate);


                    string Pass = Controller.CurrentUser.DecryptPW(Lines[i + 1]);//Decrypted PW but with the * char
                    string CorrectPass = "";//Decrypted PW but WITHOUT the * char
                    for (int j = 1; j < Pass.Length; j++)//Copy over the pw
                        CorrectPass += Pass[j];

                    
                    //If the password matches the encrypted user password, Load data
                    if (Password.Password.CompareTo(CorrectPass) == 0)//If the password entered is the password of the user
                    {
                        Controller.CurrentUser = new User(1);
                        for (int j = i; j < Lines.Length; j++)
                            if (Lines[j].Length != 0 && Lines[j][0] == '$')
                                DateTime.TryParse(Lines[j].Split('$')[1], out Controller.CurrentUser.CreationDate);
                        Controller.CurrentUser.Name = "";//Reset the users name
                        for (int j = 1; j < Lines[i].Length; j++)//Change the users name to be the name of the user
                            Controller.CurrentUser.Name += Lines[i][j];
                        Controller.CurrentUser.LoadData(false);//Load the userdate without guest rights
                        
                        this.Close();
                    }
                    //If not instruct the user that the password entered was incorrect
                    else
                    {
                        ErrorMessage.Text = "Username or Password is incorrect.";
                    }
                }
            }
            

            
        }
        void CancelApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        void NewUser(object sender, RoutedEventArgs e)
        {
            Window NewUserWindow = new NewUser();
            NewUserWindow.ShowDialog();
        }

        private void ClearError(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = "";
        }
        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            Unhidden.Text = Password.Password;
            Unhidden.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Hidden;
        }
        private void HidePassword(object sender, RoutedEventArgs e)
        {
            Password.Password = Unhidden.Text;
            Unhidden.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Visible;
        }
        private void ForgotPassword(object sender, RoutedEventArgs e)
        {
            #region Password
            string EmailPassword = /*"D8K@eM39v$By5C"*/ "Reddog05";
            #endregion
            while (true)
            {
                #region EmailNonsense
                string Greeting = ((DateTime.Now.Hour < 12) ? "Good Morning " : (DateTime.Now.Hour < 16 ? "Good Afternoon " : "Good Evening "));
                string Name = GetInfo().Split(',')[0];
                string Email = GetInfo().Split(',')[1];
                string newPassword = "";

                Random rand = new Random();
                int NewPass = rand.Next(8, 16);
                for (int i = 0; i < NewPass; i++)
                    newPassword += (char)rand.Next(65, 90);
                #endregion

                MailMessage Msg = new MailMessage("mccarthy_forrest@outlook.com", Email);
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("mccarthy_forrest@outlook.com", EmailPassword);
                client.EnableSsl = true;

                Msg.Subject = ("Account Recovery from Mindful");
                Msg.Body = (Greeting + Name + ",\n\n");
                Msg.Body += ("\tWe have been notified that you have forgotten your password. In this case we have generated a new password for you to use.\n\n");
                Msg.Body += ("\t\t<b>" + newPassword + "</b>\n\n");
                Msg.Body += ("Thanks for contacting Mindful,\n Mindful Squad");


                try { client.Send(Msg); }
                catch
                {
                    Controller.CurrentUser.errorMessage = "Email could not be sent";
                    Window Errrrrr = new ErrorWindow();
                    Errrrrr.ShowDialog();
                }
            }
        }

        string GetInfo()
        {
            string SaveFileLocation = @"SaveFile.txt";//Location where the save file is stored
            string[] Lines = System.IO.File.ReadAllLines(SaveFileLocation);//Retrieve the lines from the text file

            string Info = "";
            for(int i = 0; i < Lines.Length; i++)
                if(Lines[i].ToLower().CompareTo("#" + Username.Text.ToLower()) == 0)
                {
                    while(Lines[++i] != "[end]")
                    {
                        if (Lines[i][0].CompareTo('@') == 0)
                            for (int j = 1; j < Lines[i].Length; j++)
                                if (Lines[i][j].CompareTo(',') != 0)
                                    Info += Lines[i][j];
                                else
                                {
                                    Info += ",";
                                    break;
                                }
                        
                        if (Lines[i][0].CompareTo('%') == 0)
                            for (int j = 1; j < Lines[i].Length; j++)
                                    Info += Lines[i][j];
                    }
                }

            return Info;
        }
        void SetWindowTheme()
        {

        }
    }
}
