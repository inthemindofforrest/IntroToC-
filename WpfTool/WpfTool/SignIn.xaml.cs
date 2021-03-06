﻿using System;
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
            //SetWindowTheme();
        }
        void AttemptLogin(object sender, RoutedEventArgs e)
        {
            string SaveFileLocation = @"SaveFile.txt";//Location where the save file is stored


            string[] Lines = System.IO.File.ReadAllLines(SaveFileLocation);//Retrieve the lines from the text file


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
                    if (Password.Password.CompareTo(CorrectPass) == 0 || (Controller.CurrentUser.RecoverPass != "" && Password.Password.CompareTo(Controller.CurrentUser.RecoverPass) == 0))//If the password entered is the password of the user
                    {
                        string temp = Controller.CurrentUser.RecoverPass;
                        Controller.CurrentUser = new User(1);
                        Controller.CurrentUser.RecoverPass = temp;
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
            string EmailPassword = "facebook13";
            #endregion
            #region EmailNonsense
            string Greeting = ((DateTime.Now.Hour < 12) ? "Good Morning " : (DateTime.Now.Hour < 16 ? "Good Afternoon " : "Good Evening "));
            string Name = GetInfo().Split(',')[0];
            string Email = GetInfo().Split(',')[1];
            Controller.CurrentUser.RecoverPass = "";

            List<char> UseableChars = new List<char>();
            for (int i = 65; i < 91; i++)
                UseableChars.Add((char)i);
            for (int i = 48; i < 58; i++)
                UseableChars.Add((char)i);
            for (int i = 97; i < 122; i++)
                UseableChars.Add((char)i);

            Random rand = new Random(DateTime.Now.Millisecond);
            int NewPass = rand.Next(8, 16);
            for (int i = 0; i < NewPass; i++)
                Controller.CurrentUser.RecoverPass += UseableChars[rand.Next(0,UseableChars.Count)];
            #endregion

            #region MailSection
            MailMessage Msg = new MailMessage("inthemindofforrest@outlook.com", Email);//Sender, Reciever
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);//Outlooks host, port

            client.DeliveryMethod = SmtpDeliveryMethod.Network;//Sent over the network
            client.UseDefaultCredentials = false;//
            client.Credentials = new NetworkCredential("inthemindofforrest@outlook.com", EmailPassword);//Senders email and pw
            client.EnableSsl = true;//Ssl needs to be enabled for Outlook

            Msg.IsBodyHtml = true;//takes html input for body
            Msg.Subject = ("Account Recovery from Mindful");//Subject of email
            //Body of the email
            Msg.Body = (Greeting + Name + ",\n\n");
            Msg.Body += ("<p>We have been notified that you have forgotten your password. In this case we have generated a code for you to use to change your password with.</p><br>");
            Msg.Body += ("<b>" + Controller.CurrentUser.RecoverPass + "</b><br><br>");
            Msg.Body += ("<p>Thanks for contacting Mindful,<br> Mindful Squad</p>");


            try { client.Send(Msg); }//trys and sends it 
            catch//if it fails, notify user
            {
                Controller.CurrentUser.errorMessage = "Email could not be sent";
                Window Errrrrr = new ErrorWindow();
                Errrrrr.ShowDialog();
            }
            #endregion
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

        private void Unhidden_LostFocus(object sender, RoutedEventArgs e)
        {
            Password.Password = Unhidden.Text;
        }
    }
}
