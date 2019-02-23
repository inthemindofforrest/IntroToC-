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
using System.IO;

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
            AddToListOfExe();//Update the Listbox with the correct data
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

                SaveUser();

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
            string Location = "";
            if (ListOfExe.SelectedItem != null)//Makes sure something is selected
            {
                FileName = ListOfExe.SelectedItem.ToString();//Gets the Exe name of what app you want to run
                Location = Controller.CurrentUser.ExeFileLocations[ListOfExe.SelectedIndex];//Gets the location of the file above
            }
                if (!System.IO.File.Exists(Location + "\\" + FileName))//Checks if the file even exists (More just stupid proof of this system)
                {
                    Controller.CurrentUser.errorMessage = FileName + " could not be opened. File location was not found.";//Change an error message
                    Window errorWindow = new ErrorWindow();//Create the error window
                    errorWindow.ShowDialog();//Show the window
                    return;//Close the function early
                }

            
            if (FileName != "")//As long as the file name is not blank
            {
                ProcessStartInfo info = new ProcessStartInfo();//Create a proccess
                info.FileName = FileName;//Set the apps name here
                info.WorkingDirectory = Location;//Sets the apps directory here
                Process.Start(info);//Start the app
            }
        }

        private void SubmitApplication(object sender, RoutedEventArgs e)
        {
            if (!System.IO.File.Exists(NewPath.Text + "\\" + NewExe.Text))//If this file that is being added does not exist
            {
                Controller.CurrentUser.errorMessage = "This path does not exist.";//Create the error message
                Window ErrorWindowNew = new ErrorWindow();//Open a new error window
                ErrorWindowNew.ShowDialog();//Display the error window
                return;//Close the function early
            }

            string SaveFileLocation = @"SaveFile.txt";//Location where the save file is stored
            string[] Lines = System.IO.File.ReadAllLines(SaveFileLocation);//Retrieve the lines from the text file



            for (int j = 0; j < Controller.CurrentUser.ExeNames.Count; j++)
                if (Controller.CurrentUser.ExeNames[j].ToLower().CompareTo(NewExe.Text.ToLower()) == 0)
                    goto Finish;

            Controller.CurrentUser.ExeFileLocations.Add(NewPath.Text);//Adds a new file directory
            Controller.CurrentUser.ExeNames.Add(NewExe.Text);//adds a new file name

            AddToListOfExe();//Updates the listbox 


        Finish:
            return;
        }

        public void AddToListOfExe()
        {
            ListOfExe.Items.Clear();//Clears all the items
            ListOfExe.ItemsSource = null;//Also clears all the items
                                         //if (Controller.CurrentUser != null)
            for (int i = 0; i < Controller.CurrentUser.ExeNames.Count; i++)//Cycle through each exe name 
                ListOfExe.Items.Add(Controller.CurrentUser.ExeNames[i]);//And populate the list with them
        }


        public bool SaveUser()
        {
            string SaveFileLocation = @"SaveFile.txt";//Location where the save file is stored

            if (!System.IO.File.Exists(SaveFileLocation))
                return false;//return false if the data for the user could not be read
                             //Instruct the user to either continue with corrupted data and overide it when it is saved
                             //Or try to find the user data again
            else
                System.IO.File.Decrypt(SaveFileLocation);//DECRYPTS it so it can quickly read it


            string[] Lines = System.IO.File.ReadAllLines(SaveFileLocation);//Retrieve the lines from the text file
            List<string> MasterLines = new List<string>();


            for(int i = 0; i < Lines.Length; i++)//goes through each line is the original save file
            {
                MasterLines.Add(Lines[i]);//Add each line to the MasterList
                if (Lines[i].ToLower().CompareTo("#" + Controller.CurrentUser.Name.ToLower()) == 0)//If it hits the name of the current account
                {
                    MasterLines.Add(Lines[++i]);//add the password line
                    MasterLines.Add("@" + Controller.CurrentUser.FirstName + "," + Controller.CurrentUser.LastName);//add the users name
                    i++;
                    MasterLines.Add(Lines[++i]);//add the join date
                    MasterLines.Add("&" + Controller.CurrentUser.ProfileImage);//add Profiles image
                    i++;
                    MasterLines.Add("^" + (int)Controller.CurrentUser.PlayerSettings.CurrentTheme);//add current theme
                    i++;
                    for (int j = 0; j < Controller.CurrentUser.ExeFileLocations.Count; j++)//itterates through each
                    {
                        MasterLines.Add(Controller.CurrentUser.ExeFileLocations[j] + "," + Controller.CurrentUser.ExeNames[j]);
                        i++;
                    }
                    MasterLines.Add("[end]");
                    i++;
                }
            }

            File.WriteAllLines(SaveFileLocation, MasterLines);
            return true;
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveUser();
        }

        private void FileSelection(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".exe";
            dlg.Filter = "Anal Files (*.exe)|*.exe";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                string fileDirectory = dlg.FileName;

                string[] Parsed = fileDirectory.Split('\\');

                NewPath.Text = "";

                NewExe.Text = Parsed[Parsed.Length - 1];
                for (int i = 0; i < Parsed.Length - 1; i++)
                {
                    NewPath.Text += Parsed[i];
                    if (i < Parsed.Length - 2)
                        NewPath.Text += "\\";
                }
            }
        }

        private void ClearText(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = "";
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

        public string errorMessage = "";

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
        public User(int i)
        {
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
                if ((!Guest && Lines[i].ToLower().CompareTo("#" + (this.Name).ToLower()) == 0))
                {
                    if (!Guest)
                    {
                        IndexNumber = i;
                        Age = 0;
                    }
                    //Check if the line is not the end of the account
                    while (Lines[++i].CompareTo("[end]") != 0)
                    {
                        if (Lines[i].Length > 0)
                            //Checks for password line
                            if (Lines[i][0].CompareTo('*') == 0)//Skips the password of the user
                            {
                                PEaNsCsRwYoPrTdED = Lines[i];
                                continue;
                            }
                            //Checks for Full Player Name
                            else if (Lines[i][0].CompareTo('@') == 0)//Skips the password of the user
                            {
                                FirstName = Lines[i].Split('@', ',')[1];
                                LastName = Lines[i].Split('@', ',')[2];
                                continue;
                            }
                            //Checks for the StartDate
                            else if (Lines[i][0].CompareTo('$') == 0)//Skips the password of the user
                            {
                                DateTime.TryParse(Lines[i].Split('$')[1], out CreationDate);
                                continue;
                            }
                            //Checks for the ProfilePicture
                            else if (Lines[i][0].CompareTo('&') == 0)//Skips the password of the user
                            {
                                ProfileImage = "";
                                for (int j = 1; j < Lines[i].Length; j++)
                                    ProfileImage += Lines[i][j];
                                continue;
                            }
                            //Checks for What theme to make the window
                            else if (Lines[i][0].CompareTo('^') == 0)//Skips the password of the user
                            {
                                string Number = "";//Create an empty string
                                for(int j = 1; j<Lines[i].Length; j++)//Itterate through the rest of the line skipping the first char
                                {
                                    Number += Lines[i][j];//Add each char to the end of the string
                                }
                                int.TryParse(Number, out int ActualNumber);//Try and convert the stupid string to a string
                                PlayerSettings.CurrentTheme = (Settings.Theme)ActualNumber;//Convert and set the new int to a settings theme
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
            for (int i = 0; i < Lines.Length; i++)
                if (Lines[i].ToLower().CompareTo("!guest") == 0)
                    while (Lines[++i].CompareTo("[end]") != 0)
                    {
                        int j = 0;
                        for (; j < ExeNames.Count; j++)
                            if (ExeNames[j].ToLower().CompareTo(Lines[i].ToLower()) == 0)
                                goto Repeat;

                        this.ExeFileLocations.Add(Directory.GetCurrentDirectory() + "\\Applications\\");
                        this.ExeNames.Add(Lines[i]);
                    Repeat:
                        continue;
                    }

            System.IO.File.Encrypt(SaveFileLocation);//Keeps the file ENCRYPTED and safe
            //Lines[this.IndexNumber + 1] = EncryptPW(Lines[this.IndexNumber + 1]);
            //Lines[this.IndexNumber + 1] = DecryptPW(Lines[this.IndexNumber + 1]);

            return true;
        }

        public string EncryptPW(string CurrentForm)
        {
            string newstring = "*";//Starts a string with the password character
            for (int i = 0; i < CurrentForm.Length; i++)//Loops through the password
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
