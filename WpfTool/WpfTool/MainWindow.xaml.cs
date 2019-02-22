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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace WpfTool
{
    public static class Controller
    {
        public static User CurrentUser = new User();
    }


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;//Makes the window not resizable
        }
        private void SignInOut_Click(object sender, RoutedEventArgs e)
        {
            if (Controller.CurrentUser.Age == -1)//Sign in
            {
                Window SignInWindow = new SignIn();//Creates a new window

                SignInWindow.ShowDialog();//Makes the new window visible AND will resume here when window is closed

                if (Controller.CurrentUser.Age != -1)//If not a guest
                {
                    SignInOut.Content = "Sign Out";//Make the button be a Signout
                    NameField.Text = Controller.CurrentUser.Name;//Sets the display name to the users name
                    UserImage.Source = new BitmapImage(new Uri(Controller.CurrentUser.ProfileImage + ".png", UriKind.Relative));//Image stuff.... not sure if it works yet
                }

                ListOfExe.Items.Clear();//Clears all the items
                ListOfExe.ItemsSource = null;//Also clears all the items
                for(int i = 0; i < Controller.CurrentUser.ExeNames.Count; i++)//Cycle through each exe name 
                    ListOfExe.Items.Add(Controller.CurrentUser.ExeNames[i]);//And populate the list with them
            }
            else//Sign Out
            {
                SignInOut.Content = "Sign In";//Sets the button to display sign in
                NameField.Text = "GUEST";//Sets the display name to guest
                //Save User

                //Sign the account out
                Controller.CurrentUser = new User();//Resets the user
                ListOfExe.Items.Clear();//Clears out the items
                ListOfExe.ItemsSource = null;//Again
                for (int i = 0; i < Controller.CurrentUser.ExeNames.Count; i++)//Cycle through the guest accounts apps
                    ListOfExe.Items.Add(Controller.CurrentUser.ExeNames[i]);//Populate the list with the guest apps
            }
        }

        private void RunApplication(object sender, RoutedEventArgs e)
        {
            string FileName = "";//Name of the exe
            if(ListOfExe.SelectedItem != null)//Makes sure something is selected
                FileName = ListOfExe.SelectedItem.ToString();//
            string[] Splitted = Controller.CurrentUser.ExeFileLocations[0].Split(',');
            if (FileName != "")
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = FileName;
                info.WorkingDirectory = Splitted[0];
                Process.Start(info);
            }
        }

        public void AddToListOfExe(string exeName)
        {
            ListOfExe.DataContext += exeName;
        }

    }
    public class User
    {
        public string Name;//Username
        string PEaNsCsRwYoPrTdED;
        public string ProfileImage;//Selects from the different profile pictures


        public string FirstName;//Users first name
        public string LastName;//Users Last Name
        public int Age = new int();//Current User's age, Allows certain games to be blocked

        public List<string> ExeFileLocations = new List<string>();//All of the exe files that the user has put under their belt
        public List<string> ExeNames = new List<string>();

        public Settings PlayerSettings = new Settings();//Settings set to this player

        public int IndexNumber = new int();//Number to retrieve the Username and Password


        public System.DateTime CreationDate = new System.DateTime();//Date in which the user created this account
        //public System.DateTime AccountCreationDate { get { return CreationDate; } }//Allows you to get the creation date, but cannot set it

        //INITILIZER:
        public User()
        {
            //Starts the user on a guest account
            Name = "Guest";
            ProfileImage = "Blue";//Default profile image
            Age = -1;//Sets the age to -1 to bypass the age restriction
            CreationDate = System.DateTime.Now;//Sets the CreationDate to now
            LoadData(true);//Loads the data using Guest
        }

        //FUNCTIONS:


        public bool LoadData(bool Guest)
        {
            string SaveFileLocation = @"SaveFile.txt";//Location where the save file is stored
            
            if (!System.IO.File.Exists(SaveFileLocation))
                return false;//return false if the data for the user could not be read
                             //Instruct the user to either continue with corrupted data and overide it when it is saved
                             //Or try to find the user data again
            else
                System.IO.File.Decrypt(SaveFileLocation);//DECRYPTS it so it can quickly read it


            string[] Lines = System.IO.File.ReadAllLines(SaveFileLocation);//Retrieve the lines from the text file

            //Load data and then return true
            for (int i = 0; i < Lines.Length; i++)
            {
                //Check to see if the account being loaded is a guest account
                if ((!Guest && Lines[i].ToLower().CompareTo("#" + (this.Name).ToLower()) == 0) || (Guest && Lines[i].CompareTo("!Guest") == 0))
                {
                    if (!Guest)
                    {
                        IndexNumber = i;
                        Age = 0;
                    }
                    //Check if the line is not the end of the account
                    while (Lines[++i].CompareTo("[end]") != 0)
                    {
                        //Checks for password line
                        if (Lines[i][0].CompareTo('*') == 0)//Skips the password of the user
                        {
                            PEaNsCsRwYoPrTdED = Lines[i];
                            continue;
                        }
                        //Checks for Full Player Name
                        if (Lines[i][0].CompareTo('@') == 0)//Skips the password of the user
                        {
                            FirstName = Lines[i].Split('@', ',')[1];
                            LastName = Lines[i].Split('@', ',')[2];
                            continue;
                        }
                        //Checks for the StartDate
                        if (Lines[i][0].CompareTo('$') == 0)//Skips the password of the user
                        {
                            DateTime.TryParse(Lines[i].Split('$')[1], out CreationDate);
                            continue;
                        }
                        //Checks for the ProfilePicture
                        if (Lines[i][0].CompareTo('&') == 0)//Skips the password of the user
                        {
                            for (int j = 1; j < Lines[i].Length; j++)
                                ProfileImage += Lines[i][j]; 
                            continue;
                        }

                        //Adds the data to the ExeFileLocations
                        this.ExeFileLocations.Add(Lines[i].Split(',')[0]);//Adds the Location
                        this.ExeNames.Add(Lines[i].Split(',')[1]);//Adds the exe name
                    }

                    //Once it is the end, Escape
                    break;
                }
                else if(i == Lines.Length - 1)
                {
                    //Cannot find the players account info
                    if (Guest)
                    {
                        //BAD, PANICK..... SOMETHING FUCKED UP!!!
                    }
                    else
                    {
                        //Don't panick. I promise. You will just load the guest account and override the users settings
                        if (Lines[i].CompareTo("!Guest") == 0)
                        {

                            //Check if the line is not the end of the account
                            while (Lines[++i].CompareTo("[END]") != 0)
                            {
                                //Adds the data to the ExeFileLocations
                                this.ExeFileLocations.Add(Lines[i].Split(',')[0]);//Adds the Location
                                this.ExeNames.Add(Lines[i].Split(',')[1]);//Adds the exe name
                            }

                            //Once it is the end, Escape
                            break;
                        }
                    }
                }
                
            }
            System.IO.File.Encrypt(SaveFileLocation);//Keeps the file ENCRYPTED and safe
            Lines[this.IndexNumber + 1] = EncryptPW(Lines[this.IndexNumber + 1]);
            //Lines[this.IndexNumber + 1] = DecryptPW(Lines[this.IndexNumber + 1]);

            return true;
        }

        public string EncryptPW(string CurrentForm)
        {
            string newstring = "*";//Starts a string with the password character
            for (int i = 1; i < CurrentForm.Length; i++)//Loops through the password
                newstring += (char)((int)CurrentForm[i] + this.IndexNumber + 1 /*Offset*/ /*- this.CreationDate.Second*/);//Adds the encryption
            return newstring;//Returns the new string which is the password
        }
        public string DecryptPW(string CurrentForm)
        {
            string newstring = "*";//Starts a string with the password character
            for (int i = 1; i < CurrentForm.Length; i++)//Loops through the password
                newstring += (char)((int)CurrentForm[i] - (this.IndexNumber + 1 /*Offset*/ /*- this.CreationDate.Second)*/));//Reverses the encryption
            return newstring;//Returns the new string which is the password
        }
    }
    public class Settings
    {
        public enum Theme { Dark, Light, Blue};
        public Theme CurrentTheme;
    }
}
