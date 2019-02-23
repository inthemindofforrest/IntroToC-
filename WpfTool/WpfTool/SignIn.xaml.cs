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
    }
}
