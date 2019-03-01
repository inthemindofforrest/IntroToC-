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

        #region PageCode

        List<List<UIElement>> Pages = new List<List<UIElement>>();
        public int CurrentPage = 1;
        int Theme = 0;

        bool GetPageOne()
        {
            List<UIElement> Page = new List<UIElement>();//Creates a list of UIElements

            //Adds all the page elements to this page
            Page.Add(UsernameField);
            Page.Add(UserNameText);

            Page.Add(FirstPasswordText);
            Page.Add(SecondPasswordText);

            Page.Add(FirstPWField);
            Page.Add(SecondPWField);

            Page.Add(ShownPasswordOne);
            Page.Add(ShownPasswordTwo);

            Page.Add(FirstNameText);
            Page.Add(FirstNameField);

            Page.Add(LastNameText);
            Page.Add(LastNameField);

            Page.Add(ShowPasswords);
            Page.Add(NextButton);

            //Add the page to the list of pages
            Pages.Add(Page);

            return true;
        }
        bool GetPageTwo()
        {
            List<UIElement> Page = new List<UIElement>();

            Page.Add(ThemeText);
            Page.Add(BlackTheme);
            Page.Add(WhiteTheme);
            Page.Add(BlueTheme);

            Page.Add(EmailField);
            Page.Add(EmailText);

            Page.Add(NextButton);
            Page.Add(BackButton);

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

            Pages.Add(Page);

            return true;
        }
        bool GetPageThree()
        {
            List<UIElement> Page = new List<UIElement>();

            Page.Add(TermsOfAgreement);
            Page.Add(BackButton);
            Page.Add(SubmitButton);

            Pages.Add(Page);

            return true;
        }

        bool GetAllPages()
        {
            Pages.Clear();
            return (GetPageOne() && GetPageTwo() && GetPageThree());
        }

        bool VisualizePage(Visibility VisibilityLevel, int PageNumber)
        {
            if ((PageNumber == 1 || PageNumber == 2 || PageNumber == 3) && GetAllPages())//Gets all of the elements in the first page
            {
                foreach (UIElement item in Pages[PageNumber])//Finds each UIElement in the page list
                    item.Visibility = VisibilityLevel;//Sets each element to the visibility asked for above
                return true;
            }
            return false;
        }
        bool VisualizePage(bool ResetAllElse)
        {
            if (ResetAllElse)
            {
                if (GetAllPages())//Loads all the pages
                {
                    foreach(List<UIElement> page in Pages)//Gets the list of all the pages in the Pages list
                        foreach (UIElement item in page)//Finds each UIElement in the page list
                            item.Visibility = Visibility.Hidden;//Sets each element to the visibility asked for above
                    return true;
                }
            }
            return false;
        }
        bool VisualizePage(int ExceptThis)
        {
            List<UIElement> PageToDisplay = new List<UIElement>();
            if (GetAllPages())
            {
                for (int i = 0; i < Pages.Count; i++)//Goes through each page
                    if (i + 1 == ExceptThis)//Checks if the page is the same as the programmer entered page
                        PageToDisplay = Pages[i];//Saves it to be displayed last
                    else
                        foreach (UIElement item in Pages[i])//Finds each UIElement in the page list
                            item.Visibility = Visibility.Hidden;//Sets each element to the visibility Hidden

                foreach (UIElement item in PageToDisplay)//Finds each UIElement in the page list
                    item.Visibility = Visibility.Visible;//Sets each element to the visibility Visible

                return true;//Yay it made it through all the pages
            }
            return false;//Welp....
        }
        void NextPage(object sender, RoutedEventArgs e)
        {
            if (CurrentPage < Pages.Count)
                CurrentPage++;//Moves to the next page
            UpdatePage();
        }
        void BackPage(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 1)
                CurrentPage--;//Moves Back a page
            UpdatePage();
        }
        void UpdatePage()
        {
            if (VisualizePage(CurrentPage))
                return;
            else
            //Shouldnt Get here
            {
                Controller.CurrentUser.errorMessage = "Page \"" + CurrentPage + "\" does not exist";
                Window Errrrrrrrrrrrrrr = new ErrorWindow();
                Errrrrrrrrrrrrrr.ShowDialog();
            }
        }
        #endregion

        public NewUser()//MAIN
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            ShownPasswordOne.Visibility = Visibility.Hidden;
            ShownPasswordTwo.Visibility = Visibility.Hidden;
            UpdatePage();
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
                NewUserCreation.Add(Controller.CurrentUser.EncryptPW(FirstPWField.Password));
                NewUserCreation.Add("@" + FirstNameField.Text + "," + LastNameField.Text);
                NewUserCreation.Add("$" + DateTime.Now.ToString());
                NewUserCreation.Add("&" + Controller.CurrentUser.ProfileImage);
                NewUserCreation.Add("^" + Theme);
                NewUserCreation.Add("%" + EmailField.Text);

                NewUserCreation.Add("[end]");

                if (FirstPWField.Password.Length > 8 && FirstPWField.Password == SecondPWField.Password)
                    if (!IsAlreadyName)
                        if (FirstNameField.Text.Length > 0 && LastNameField.Text.Length > 0)
                        {
                            if (EmailCheck(EmailField.Text))
                            {
                                System.IO.File.AppendAllLines(SaveFileLocation, NewUserCreation);
                                this.Close();
                                return;
                            }
                        }

                Controller.CurrentUser.errorMessage = "Account could not be created. Please edit current proccess and try again.";
                Window Errrrrrrr = new ErrorWindow();
                Errrrrrrr.ShowDialog();
            }
        }
        void BlackPicture(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "Black";
        }
        void BluePicture(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "Blue";
        }
        void GreenPicture(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "Green";
        }
        void RedPicture(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "Red";
        }
        void WhitePicture(object sender, RoutedEventArgs e)
        {
            Controller.CurrentUser.ProfileImage = "White";
        }

        private bool EmailCheck(string email)
        {
            for (int i = 0; i < email.Length; i++)
                if (email[i] == '@')
                    return true;
            return false;
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

        private void ShowPasswordsChecked(object sender, RoutedEventArgs e)
        {
            ShownPasswordOne.Visibility = Visibility.Visible;
            ShownPasswordTwo.Visibility = Visibility.Visible;

            FirstPWField.Visibility = Visibility.Hidden;
            SecondPWField.Visibility = Visibility.Hidden;

            ShownPasswordOne.Text = FirstPWField.Password;
            ShownPasswordTwo.Text = SecondPWField.Password;
        }

        private void ShowPasswordsUnChecked(object sender, RoutedEventArgs e)
        {
            ShownPasswordOne.Visibility = Visibility.Hidden;
            ShownPasswordTwo.Visibility = Visibility.Hidden;

            FirstPWField.Visibility = Visibility.Visible;
            SecondPWField.Visibility = Visibility.Visible;

            FirstPWField.Password = ShownPasswordOne.Text;
            SecondPWField.Password = ShownPasswordTwo.Text;
        }

        private void ShownPasswordUpdater(object sender, RoutedEventArgs e)
        {
            FirstPWField.Password = ShownPasswordOne.Text;
            SecondPWField.Password = ShownPasswordTwo.Text;
        }

        //Selecting Theme style
        private void DarkThemeSelect(object sender, RoutedEventArgs e)
        {
            Theme = 0;
        }
        private void LightThemeSelect(object sender, RoutedEventArgs e)
        {
            Theme = 1;
        }
        private void BlueThemeSelect(object sender, RoutedEventArgs e)
        {
            Theme = 2;
        }
    }
}
