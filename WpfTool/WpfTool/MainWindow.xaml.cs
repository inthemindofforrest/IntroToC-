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

namespace WpfTool
{

    public partial class MainWindow : Window
    {
        User CurrentUser = new User();
        public MainWindow()
        {
            InitializeComponent();
        }

        void AttemptLogin()
        {
            //Using the username cycle through the save of the users accounts

            //If the password matches the encrypted user password, Load data

            //If not instruct the user that the password entered was incorrect
        }

    }
    public class User
    {
        public string Name;//Username
        string PEaNsCsRwYoPrTdED;
        public int ProfileImage = new int();//Selects from the different profile pictures

        public int Age = new int();//Current User's age, Allows certain games to be blocked

        public List<string> ExeFileLocations = new List<string>();//All of the exe files that the user has put under their belt

        public Settings PlayerSettings = new Settings();//Settings set to this player

        public int IndexNumber = new int();//Number to retrieve the Username and Password


        System.DateTime CreationDate = new System.DateTime();//Date in which the user created this account
        public System.DateTime AccountCreationDate { get { return CreationDate; } }//Allows you to get the creation date, but cannot set it

        //INITILIZER:
        public User()
        {
            //Starts the user on a guest account
            Name = "Guest";
            ProfileImage = 0;//Default profile image
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
                if ((!Guest && Lines[i].CompareTo("#" + this.Name) == 0) || (Guest && Lines[i].CompareTo("!Guest") == 0))
                {
                    if (!Guest)
                        IndexNumber = i;
                    //Check if the line is not the end of the account
                    while (Lines[++i].CompareTo("[end]") != 0)
                    {
                        //Checks for password line
                        if (Lines[i][0].CompareTo('*') == 0)//Skips the password of the user
                        {
                            PEaNsCsRwYoPrTdED = Lines[i];
                            continue;
                        }

                        //Adds the data to the ExeFileLocations
                        this.ExeFileLocations.Add(Lines[i]);//Adds the 
                    }

                    //Once it is the end, Escape
                    break;
                }
                else
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
                                this.ExeFileLocations.Add(Lines[i]);//Adds the 
                            }

                            //Once it is the end, Escape
                            break;
                        }
                    }
                }
            }
            System.IO.File.Encrypt(SaveFileLocation);//Keeps the file ENCRYPTED and safe
            //Lines[this.IndexNumber + 1] = EncryptPW(Lines[this.IndexNumber + 1]);
            //Lines[this.IndexNumber + 1] = DecryptPW(Lines[this.IndexNumber + 1]);
            return true;
        }

        string EncryptPW(string CurrentForm)
        {
            string newstring = "*";//Starts a string with the password character
            for (int i = 1; i < CurrentForm.Length; i++)//Loops through the password
                newstring += (char)((int)CurrentForm[i] + this.IndexNumber + 1 /*Offset*/ + this.CreationDate.Second);//Adds the encryption
            return newstring;//Returns the new string which is the password
        }
        string DecryptPW(string CurrentForm)
        {
            string newstring = "*";//Starts a string with the password character
            for (int i = 1; i < CurrentForm.Length; i++)//Loops through the password
                newstring += (char)((int)CurrentForm[i] - (this.IndexNumber + 1 /*Offset*/ + this.CreationDate.Second));//Reverses the encryption
            return newstring;//Returns the new string which is the password
        }
    }
    public class Settings
    {
        public enum Theme { Dark, Light, Blue};
        public Theme CurrentTheme;
    }
}
