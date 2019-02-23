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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        bool IsAlreadyName = false;
        public NewUser()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            
        }
        void CancelApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        void Submit(object sender, RoutedEventArgs e)
        {
            if (CheckForUserNameValitity())
            {

                string SaveFileLocation = @"SaveFile.txt";//Location where the save file is stored

                List<string> NewUserCreation = new List<string>();
                NewUserCreation.Add("#" + UsernameField.Text);
                NewUserCreation.Add(Controller.CurrentUser.EncryptPW(FirstPWField.Text));
                NewUserCreation.Add("@" + FirstNameField.Text + "," + LastNameField.Text);
                NewUserCreation.Add("$" + DateTime.Now.ToString());
                NewUserCreation.Add("&" + Controller.CurrentUser.ProfileImage);
                NewUserCreation.Add("^" + (int)Controller.CurrentUser.PlayerSettings.CurrentTheme);

                NewUserCreation.Add("[end]");

                if (FirstPWField.Text.Length > 8 && FirstPWField.Text == SecondPWField.Text)
                    if (!IsAlreadyName)
                        if (FirstNameField.Text.Length > 0 && LastNameField.Text.Length > 0)
                        {
                            System.IO.File.AppendAllLines(SaveFileLocation, NewUserCreation);
                            this.Close();
                        }
            }
        }

        private bool CheckForUserNameValitity()
        { 
            Controller.CurrentUser.Name = UsernameField.Text;

            for(int i = 0; i < Controller.CurrentUser.Name.Length; i++)
                if(Controller.CurrentUser.Name[i] >= 48 && Controller.CurrentUser.Name[i] <= 57 ||
                   Controller.CurrentUser.Name[i] >= 65 && Controller.CurrentUser.Name[i] <= 90 ||
                   Controller.CurrentUser.Name[i] >= 97 && Controller.CurrentUser.Name[i] <= 122)
                {
                    //Good!!!!!
                }
                else
                {
                    ErrorMessage.Text = "Cannot use symbols.";
                    Controller.CurrentUser.Name = "Guest";
                    return false;
                }

            string SaveFileLocation = @"SaveFile.txt";//Location where the save file is stored

            string[] Lines = System.IO.File.ReadAllLines(SaveFileLocation);//Retrieve the lines from the text file

           

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].ToLower().CompareTo("#" + Controller.CurrentUser.Name.ToLower()) == 0)
                {
                    //Report Username already taken
                    IsAlreadyName = true;
                    ErrorMessage.Text = "Username is already taken.";
                    Controller.CurrentUser.Name = "Guest";
                    return false;
                }

                //Report Username Not taken
                IsAlreadyName = false;
                ErrorMessage.Text = "";
            }
            return true;
        }
    }
}
