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
        List<Ingrediant> TotalIngrediants;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CreateItems(object sender, RoutedEventArgs e)
        {

        }
    }

    public struct Ingrediant
    {
        public string Name;
        public float Amount;
        public List<Ingrediant> PossibleCombos;
    }
    public struct Item
    {
        enum Machines { Stove, Oven, Microwave}
        string Name;
        string FileLocation;
        int ComplexityLevel { set { ComplexityLevel = value < 5 && value > 0 ? value : value > 5 ? 5 : 1; } }//Complexity needs to be 1-5, if not, then it is set to 1 by default
        List<Ingrediant> TotalIngrediants;
        List<Machines> NeededMachines;
        List<string> Instructions;


        public void LoadInstructions()
        {
            //Reads in file
            string[] Lines = System.IO.File.ReadAllLines(@"SaveFile.txt");

            for(int i = 0; i < Lines.Length; i++)
            {
                if(Lines[i].CompareTo("[ingrediants]") == 0)
                {
                    while(Lines[i].CompareTo("[end]") != 0)
                    {

                    }
                }
            }
        }
        public void CreateItems(object sender, SelectionChangedEventArgs e)
        {

            
                
        }
        void AddIngrediantsRandomally()
        {
            Random RandomNumber = new Random();
            int rand = RandomNumber.Next(0, 3);
            for (int i = 0; i < rand; i++)
                TotalIngrediants.Add(TotalIngrediants[TotalIngrediants.Count - 1].PossibleCombos[RandomNumber.Next(0, TotalIngrediants[TotalIngrediants.Count - 1].PossibleCombos.Count)]);
        }
    }

}
