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
        #region PageCode
        List<List<UIElement>> Pages = new List<List<UIElement>>();
        enum PageNames { MainPage, SettingsPage };

        bool GetMainPage()
        {
            List<UIElement> Page = new List<UIElement>();

            #region PageContents

            Page.Add(NameField);
            Page.Add(NameText);

            Page.Add(ImageBorder);
            Page.Add(UserImage);

            Page.Add(FileNameText);
            Page.Add(PathText);

            Page.Add(NewExe);
            Page.Add(NewPath);

            Page.Add(AddProgramBorder);
            Page.Add(AddProgramButton);
            Page.Add(AddprogramText);

            Page.Add(ConfirmNewButton);

            Page.Add(ListOfExe);
            Page.Add(ListOfExeBorder);

            Page.Add(PlayButton);
            Page.Add(RemoveButton);
            Page.Add(SignInOut);
            Page.Add(SettingsButton);

            #endregion

            Pages.Add(Page);
            return (Page.Count > 0);
        }
        bool GetSettingsPage()
        {
            List<UIElement> Page = new List<UIElement>();//Creates a list of UIElements

            #region PageContents

            Page.Add(NameField);
            Page.Add(NameText);
            Page.Add(ImageBorder);
            Page.Add(UserImage);

            Page.Add(BackButton);

            Page.Add(ChangePasswordText);

            Page.Add(CurrentPasswordField);
            Page.Add(CurrentPasswordText);

            Page.Add(NewPasswordAgainField);
            Page.Add(NewPasswordAgainText);

            Page.Add(NewPasswordField);
            Page.Add(NewPasswordText);

            Page.Add(EncryptedPWCurrent);
            Page.Add(EncryptedPWNewFirst);
            Page.Add(EncryptedPWNewSecond);

            Page.Add(ShowPasswords);

            Page.Add(ThemeText);
            Page.Add(BlackTheme);
            Page.Add(WhiteTheme);
            Page.Add(BlueTheme);

            Page.Add(SubmitButton);
            Page.Add(PasswordChangedText);

            Page.Add(BlackButton);
            Page.Add(BlueButton);
            Page.Add(GreenButton);
            Page.Add(RedButton);
            Page.Add(WhiteButton);

            Page.Add(BlackImage);
            Page.Add(BlueImage);
            Page.Add(GreenImage);
            Page.Add(RedImage);
            Page.Add(WhiteImage);

            Page.Add(ProfilePicText);

            #endregion

            Pages.Add(Page);//Adds the page to the list of Pages
            return (Page.Count > 0);//Returns status of the page
        }

        bool GetAllPages()
        {
            Pages.Clear();
            return (GetMainPage() && GetSettingsPage());//Gets all the pages into the pages
        }

        void PageVisibility(Visibility VisibilityLevel, PageNames PageNumber)
        {
            if (Pages[(int)PageNumber] != null)//If the page number exists
                foreach (UIElement element in Pages[(int)PageNumber])//For every Uielement in the page
                    element.Visibility = VisibilityLevel;//Set the visibility to the wanted visibility
        }
        void PageVisibility(PageNames ExceptThis)
        {
            List<UIElement> page = new List<UIElement>();//Make a temp page
            if (GetAllPages())//As long as wanted hide all pages, and pages are loaded
            {
                for (int i = 0; i < Pages.Count; i++)//Go through all the pages and hide them all
                    PageVisibility(Visibility.Hidden, (PageNames)i);
                if (Pages[(int)ExceptThis] != null)//Page exists
                    PageVisibility(Visibility.Visible, ExceptThis);//Make this page visible
            }
        }

        private void SettingsPageSetter(object sender, RoutedEventArgs e)
        {
            PageVisibility(PageNames.SettingsPage);//Makes the settings page visible

            NewPasswordAgainField.Visibility = Visibility.Hidden;
            NewPasswordField.Visibility = Visibility.Hidden;
            CurrentPasswordField.Visibility = Visibility.Hidden;

            PasswordChangedText.Visibility = Visibility.Hidden;
        }
        private void MainPageSetter(object sender, RoutedEventArgs e)
        {
            PageVisibility(PageNames.MainPage);//Makes the Main page visible
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;//Makes the window not resizable
            DisplayListOfExe();//Update the Listbox with the correct data
            PageVisibility(PageNames.MainPage);//Makes sure to close all pages and open the main page
            UpdateProfilePicture();
        }

        #region Buttons
        #region MainWindowButtons
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
                UpdateTheme();
                UpdateProfilePicture();
                ListOfExe.Items.Clear();//Clears all the items
                ListOfExe.ItemsSource = null;//Also clears all the items
                for (int i = 0; i < Controller.CurrentUser.ExeNames.Count; i++)//Cycle through each exe name 
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

                UpdateTheme();
                UpdateProfilePicture();

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
        private void RemoveApplication(object sender, RoutedEventArgs e)
        {
            string FileName = "";//Name of the exe
            string Location = "";//Name of the location

            if (ListOfExe.SelectedItem != null)//Makes sure something is selected
            {
                Window Confirmation = new ConfirmWindow();//Create a confirmation window
                Confirmation.ShowDialog();//Display the window and wait for the return


                if (Confirmation.DialogResult == true)//If the user has confirmed the decision
                {
                    FileName = ListOfExe.SelectedItem.ToString();//Gets the Exe name of what app you want to run
                    Location = Controller.CurrentUser.ExeFileLocations[ListOfExe.SelectedIndex];//Gets the location of the file above

                    foreach (string s in Controller.CurrentUser.ExeNames)//Get all of the strings in exenames
                        if (s.CompareTo(FileName) == 0)//If the FileName is the same as the exename
                        {
                            Controller.CurrentUser.ExeNames.Remove(FileName);//remove it
                            break;//Break the loop
                        }
                    foreach (string s in Controller.CurrentUser.ExeFileLocations)//Now get the file locations from the exefilelocations
                        if (s.CompareTo(Location) == 0)//if the string locations is in the exefilelocations
                        {
                            Controller.CurrentUser.ExeFileLocations.Remove(Location);//remove it
                            break;//break the loop
                        }
                }
            }
            DisplayListOfExe();//redesplays the list
                               //if the application is not in the list this should also refresh the list
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

            DisplayListOfExe();//Updates the listbox 


            Finish:
            return;
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
            dlg.Filter = "Executable Files (*.exe)|*.exe";

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
        #endregion
        #region SettingsWindowButtons
        private void ChangeToDarkTheme(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.PlayerSettings.CurrentTheme = Settings.Theme.Dark;
            //Update the theme of the page.
            UpdateTheme();
        }
        private void ChangeToLightTheme(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.PlayerSettings.CurrentTheme = Settings.Theme.Light;
            //Update the theme of the page.
            UpdateTheme();
        }
        private void ChangeToBlueTheme(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.PlayerSettings.CurrentTheme = Settings.Theme.Blue;
            //Update the theme of the page.
            UpdateTheme();
        }

        private void UpdateImageBlack(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "Black";
            UpdateProfilePicture();
        }
        private void UpdateImageBlue(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "Blue";
            UpdateProfilePicture();
        }
        private void UpdateImageGreen(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "Green";
            UpdateProfilePicture();
        }
        private void UpdateImageRed(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "Red";
            UpdateProfilePicture();
        }
        private void UpdateImageWhite(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "White";
            UpdateProfilePicture();
        }

        private void SubmitNewPassword(object sender, RoutedEventArgs e)
        {
            if (Controller.CurrentUser.Age != -1)
            {
                string Encrypted = Controller.CurrentUser.DecryptPW(Controller.CurrentUser.PEaNsCsRwYoPrTdED);
                string Decrypted = "";

                for (int i = 1; i < Encrypted.Length; i++)
                    Decrypted += Encrypted[i];

                //Check if the Current password is correct
                if (CurrentPasswordField.Text.CompareTo(Decrypted) == 0 || (Controller.CurrentUser.RecoverPass != "" && CurrentPasswordField.Text.CompareTo(Controller.CurrentUser.RecoverPass) == 0))
                    //Check if the new password is long enough, and matches eachother
                    if (NewPasswordField.Text.Length > 8 && NewPasswordField.Text.CompareTo(NewPasswordAgainField.Text) == 0)
                    {
                        //Set the password to the new password but encrypted
                        Controller.CurrentUser.RecoverPass = "";

                        Controller.CurrentUser.PEaNsCsRwYoPrTdED = Controller.CurrentUser.EncryptPW(NewPasswordAgainField.Text);

                        CurrentPasswordField.Text = "";
                        EncryptedPWCurrent.Password = "";

                        NewPasswordAgainField.Text = "";
                        EncryptedPWNewSecond.Password = "";

                        NewPasswordField.Text = "";
                        EncryptedPWNewFirst.Password = "";

                        PasswordChangedText.Visibility = Visibility.Visible;
                    }
            }
        }

        #endregion

        #endregion

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


            for (int i = 0; i < Lines.Length; i++)//goes through each line is the original save file
            {
                MasterLines.Add(Lines[i]);//Add each line to the MasterList
                if (Lines[i].ToLower().CompareTo("#" + Controller.CurrentUser.Name.ToLower()) == 0)//If it hits the name of the current account
                {
                    MasterLines.Add(Controller.CurrentUser.PEaNsCsRwYoPrTdED);//add the password line
                    i++;
                    MasterLines.Add("@" + Controller.CurrentUser.FirstName + "," + Controller.CurrentUser.LastName);//add the users name
                    i++;
                    MasterLines.Add(Lines[++i]);//add the join date
                    MasterLines.Add("&" + Controller.CurrentUser.ProfileImage);//add Profiles image
                    i++;
                    MasterLines.Add("^" + (int)Controller.CurrentUser.PlayerSettings.CurrentTheme);//add current theme
                    i++;
                    MasterLines.Add("%" + Controller.CurrentUser.Email);
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

        #region SettingsFunctions
        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            NewPasswordAgainField.Visibility = Visibility.Visible;
            NewPasswordField.Visibility = Visibility.Visible;
            CurrentPasswordField.Visibility = Visibility.Visible;

            EncryptedPWCurrent.Visibility = Visibility.Hidden;
            EncryptedPWNewFirst.Visibility = Visibility.Hidden;
            EncryptedPWNewSecond.Visibility = Visibility.Hidden;
        }
        private void HidePassword(object sender, RoutedEventArgs e)
        {
            NewPasswordAgainField.Visibility = Visibility.Hidden;
            NewPasswordField.Visibility = Visibility.Hidden;
            CurrentPasswordField.Visibility = Visibility.Hidden;

            EncryptedPWCurrent.Visibility = Visibility.Visible;
            EncryptedPWNewFirst.Visibility = Visibility.Visible;
            EncryptedPWNewSecond.Visibility = Visibility.Visible;
        }
        #endregion
        #region UpdateLayout
        void UpdateTheme()
        {
            LinearGradientBrush MainBrush = new LinearGradientBrush();
            LinearGradientBrush SecondBrush = new LinearGradientBrush();
            switch (Controller.CurrentUser.PlayerSettings.CurrentTheme)
            {
                default:
                case Settings.Theme.Dark:
                    MainBrush = new LinearGradientBrush(Color.FromRgb(0, 0, 0), Color.FromRgb(255, 255, 255), new Point(0.5, 0), new Point(0.5, 1));
                    SecondBrush = new LinearGradientBrush(Color.FromRgb(150, 150, 150), Color.FromRgb(85, 85, 85), new Point(0.5, 0), new Point(0.5, 1));
                    break;
                case Settings.Theme.Light:
                    MainBrush = new LinearGradientBrush(Color.FromRgb(255, 255, 255), Color.FromRgb(255, 255, 255), new Point(0.5, 0), new Point(0.5, 1));
                    SecondBrush = new LinearGradientBrush(Color.FromRgb(255, 255, 255), Color.FromRgb(255, 255, 255), new Point(0.5, 0), new Point(0.5, 1));
                    break;
                case Settings.Theme.Blue:
                    MainBrush = new LinearGradientBrush(Color.FromRgb(255, 255, 255), Color.FromRgb(0, 70, 255), new Point(0.5, 0), new Point(0.5, 1));
                    SecondBrush = new LinearGradientBrush(Color.FromRgb(0, 70, 255), Color.FromRgb(255, 255, 255), new Point(0.5, 0), new Point(0.5, 1));
                    break;
            }
            GridSystem.Background = MainBrush;
            ListOfExe.Background = SecondBrush;
            NameField.Background = SecondBrush;
        }
        void UpdateProfilePicture()
        {
            ImageSource source = new BitmapImage(new Uri(@"Images/" + Controller.CurrentUser.ProfileImage + ".png", UriKind.Relative));
            UserImage.Source = source;
        }
        public void DisplayListOfExe()
        {
            ListOfExe.Items.Clear();//Clears all the items
            ListOfExe.ItemsSource = null;//Also clears all the items
                                         //if (Controller.CurrentUser != null)
            for (int i = 0; i < Controller.CurrentUser.ExeNames.Count; i++)//Cycle through each exe name 
                ListOfExe.Items.Add(Controller.CurrentUser.ExeNames[i]);//And populate the list with them
        }
        #endregion

        private void MovePasswords(object sender, RoutedEventArgs e)
        {
            NewPasswordAgainField.Text = EncryptedPWNewSecond.Password;
            NewPasswordField.Text = EncryptedPWNewFirst.Password;
            CurrentPasswordField.Text = EncryptedPWCurrent.Password;
        }
    }
    public class User
    {
        public string Name;//Username
        public string PEaNsCsRwYoPrTdED;
        public string ProfileImage;//Selects from the different profile pictures

        public string Email;
        public string RecoverPass;

        public string FirstName;//Users first name
        public string LastName;//Users Last Name
        public int Age = new int();//Current User's age, Allows certain games to be blocked

        public List<string> ExeFileLocations = new List<string>();//All of the exe files that the user has put under their belt
        public List<string> ExeNames = new List<string>();

        public Settings PlayerSettings = new Settings();//Settings set to this player

        public int IndexNumber = 0;//Number to retrieve the Username and Password

        public string errorMessage = "";

        public System.DateTime CreationDate = new System.DateTime();//Date in which the user created this account
                                                                    //public System.DateTime AccountCreationDate { get { return CreationDate; } }//Allows you to get the creation date, but cannot set it

        #region Initilizer
        public User()
        {
            //Starts the user on a guest account
            Name = "Guest";
            ProfileImage = "Green";//Default profile image
            Age = -1;//Sets the age to -1 to bypass the age restriction
            CreationDate = System.DateTime.Now;//Sets the CreationDate to now
            LoadData(true);//Loads the data using Guest
        }
        public User(int i)
        {
        }
        #endregion
        #region Functions
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
                        //IndexNumber = i;
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
                            //Checks for What Email for the user
                            else if (Lines[i][0].CompareTo('%') == 0)//Skips the password of the user
                            {
                                string email = "";//Create an empty string
                                for (int j = 1; j < Lines[i].Length; j++)//Itterate through the rest of the line skipping the first char
                                {
                                    email += Lines[i][j];//Add each char to the end of the string
                                }
                                Controller.CurrentUser.Email = email;
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

            //System.IO.File.Encrypt(SaveFileLocation);//Keeps the file ENCRYPTED and safe
            //Lines[this.IndexNumber + 1] = EncryptPW(Lines[this.IndexNumber + 1]);
            //Lines[this.IndexNumber + 1] = DecryptPW(Lines[this.IndexNumber + 1]);

            return true;
        }

        public string EncryptPW(string CurrentForm)
        {
            string newstring = "*";//Starts a string with the password character
            for (int i = 0; i < CurrentForm.Length; i++)//Loops through the password
                newstring += (char)((int)CurrentForm[i] + 1 /*Offset*/ /*- this.CreationDate.Second*/);//Adds the encryption
            return newstring;//Returns the new string which is the password
        }
        public string DecryptPW(string CurrentForm)
        {
            string newstring = "*";//Starts a string with the password character
            for (int i = 1; i < CurrentForm.Length; i++)//Loops through the password
                newstring += (char)((int)CurrentForm[i] - (1 /*Offset*/ /*- this.CreationDate.Second)*/));//Reverses the encryption
            return newstring;//Returns the new string which is the password
        }
        #endregion
    }
    public class Settings
    {
        public enum Theme { Dark, Light, Blue};
        public Theme CurrentTheme;
    }
}
