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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pages pages = new Pages();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            pages.LoadItems();
            Directions.Items.Clear();
            for (int i = 0; i < pages.Items[pages.CurrentPage].Instructions.Count; i++)
                Directions.Items.Add((i + 1) + ") " + pages.Items[pages.CurrentPage].Instructions[i]);
            Item_Name.Text = pages.Items[pages.CurrentPage].Name;
            for (int i = 0; i < pages.Items[pages.CurrentPage].TotalIngrediants.Count; i++)
                Ingrediants.Items.Add(pages.Items[pages.CurrentPage].TotalIngrediants[i].Amount + "x " + pages.Items[pages.CurrentPage].TotalIngrediants[i].Name);
        }
    }

    public struct Ingrediant
    {
        public string Name;
        public float Amount;
        //public List<Ingrediant> PossibleCombos;

        public Ingrediant(string name, float amount)
        {
            Name = name;
            Amount = amount;
        }
    }
    public struct Item
    {
        enum Machines { Stove, Oven, Microwave}
        public string Name;
        public int ComplexityLevel; /*{ set { ComplexityLevel = value < 5 && value > 0 ? value : value > 5 ? 5 : 1; } }*///Complexity needs to be 1-5, if not, then it is set to 1 by default
        public List<Ingrediant> TotalIngrediants;
        List<Machines> NeededMachines;
        public List<string> Instructions;


        public void LoadInstructions()
        {
            //Reads in file
            string[] Lines = System.IO.File.ReadAllLines(@"SaveFile.txt");

            for(int i = 0; i < Lines.Length; i++)
            {
                if(Lines[i].CompareTo("[ingrediants]") == 0)
                {
                    while(Lines[++i].CompareTo("[end]") != 0)
                    {

                    }
                }
            }
        }
        public void CreateItems(object sender, SelectionChangedEventArgs e)
        {

            
                
        }
        //void AddIngrediantsRandomally()
        //{
        //    Random RandomNumber = new Random();
        //    int rand = RandomNumber.Next(0, 3);
        //    for (int i = 0; i < rand; i++)
        //        TotalIngrediants.Add(TotalIngrediants[TotalIngrediants.Count - 1].PossibleCombos[RandomNumber.Next(0, TotalIngrediants[TotalIngrediants.Count - 1].PossibleCombos.Count)]);
        //}
    }

    public class Pages
    {
        public List<Item> Items = new List<Item>();
        public int PageCount { get { return Items.Count; } }
        public int CurrentPage = 0;
        public void LoadItems()
        {
            //Reads in file
            string[] Lines = System.IO.File.ReadAllLines(@"SaveFile.txt");

            for (int i = 0; i < Lines.Length; i++)
            {
                if (Lines[i].CompareTo("[Item]") == 0)
                {
                    Item tmpItem = new Item();
                    tmpItem.Instructions = new List<string>();
                    tmpItem.TotalIngrediants = new List<Ingrediant>();
                    while (Lines[++i].CompareTo("[end]") != 0)
                    {
                        switch (Lines[i].Split('[',']')[1])
                        {
                            case "Name"://Name of Item
                                tmpItem.Name = Lines[i].Split(']')[1];
                                break;
                            case "Complexity"://Complexity Level
                                int.TryParse(Lines[i].Split('=')[1], out int tmpNumber);
                                if (tmpNumber > 5) tmpNumber = 5;
                                else if (tmpNumber < 1) tmpNumber = 1;
                                tmpItem.ComplexityLevel = tmpNumber;
                                break;
                            case "Direction"://Instructions
                                tmpItem.Instructions.Add(Lines[i].Split(']')[1]);
                                break;
                            case "Ingrediant"://Ingrediants
                                float.TryParse(Lines[i].Split('=')[1], out float AmountNumber);
                                tmpItem.TotalIngrediants.Add(new Ingrediant(Lines[i].Split(']','=')[1], AmountNumber));
                                break;

                        }
                    }
                    Items.Add(tmpItem);
                }
            }
        }
    }


}
