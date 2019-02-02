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

namespace Vector3Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Vector3 LeftHandSide = new Vector3(0,0,0);
        Vector3 RightHandSide = new Vector3(0, 0, 0);
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangedVectorText(object sender, TextChangedEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            if (double.TryParse(Temp.Text, out double number))
                switch (Temp.Name)
                {
                    case "LX":case "LX1":case "LX2":case "LX3":case "LX4":case "LX5":
                        LeftHandSide.x = (float)Convert.ToDouble(Temp.Text);
                        break;
                    case "LY":case "LY1":case "LY2":case "LY3":case "LY4":case "LY5":
                        LeftHandSide.y = (float)Convert.ToDouble(Temp.Text);
                        break;
                    case "LZ":case "LZ1":case "LZ2":case "LZ3":case "LZ4":case "LZ5":
                        LeftHandSide.z = (float)Convert.ToDouble(Temp.Text);
                        break;
                    case "RX":case "RX1":case "RX2":case "RX3":
                        RightHandSide.x = (float)Convert.ToDouble(Temp.Text);
                        break;
                    case "RY":case "RY1":case "RY2":case "RY3":
                        RightHandSide.y = (float)Convert.ToDouble(Temp.Text);
                        break;
                    case "RZ":case "RZ1":case "RZ2":case "RZ3":
                        RightHandSide.z = (float)Convert.ToDouble(Temp.Text);
                        break;
                }
            else
                if(Temp.Text != "-" && Temp.Text!= ".")
                Temp.Text = "0";

        }  
        private void Calculate(object sender, RoutedEventArgs e)
        {
            Button Temp = (Button)sender;
            switch (Temp.Name)
            {
                case "Addition":
                    Vector3 ResultAdd = LeftHandSide.Sum(RightHandSide);
                    Results.Text = (ResultAdd.x + ", " + ResultAdd.y + ", " + ResultAdd.z);
                    break;
                case "Subtraction":
                    Vector3 ResultSub = LeftHandSide.Sub(RightHandSide);
                    Results1.Text = (ResultSub.x + ", " + ResultSub.y + ", " + ResultSub.z);
                    break;
                case "Magnitude":
                    double ResultMag = LeftHandSide.Magnitude();
                    Results2.Text = ResultMag.ToString();
                    break;
                case "Normalized":
                    Vector3 ResultNorm = LeftHandSide.GetNormalized();
                    Results3.Text = (ResultNorm.x + ", " + ResultNorm.y + ", " + ResultNorm.z);
                    break;
                case "Dot_Product":
                    double ResultDot = LeftHandSide.DotProduct(RightHandSide);
                    Results4.Text = ResultDot.ToString();
                    break;
                case "Cross_Product":
                    Vector3 ResultCross = LeftHandSide.CrossProduct(RightHandSide);
                    Results5.Text = (ResultCross.x + ", " + ResultCross.y + ", " + ResultCross.z);
                    break;
            }

        }

        private void LX_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            temp.Text = string.Empty;
        }

    }
    struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public Vector3 Sum(Vector3 Other)
        {
            return (new Vector3(x + Other.x, y + Other.y, z + Other.z));
        }
        public Vector3 Sub(Vector3 Other)
        {
            return (new Vector3(x - Other.x, y - Other.y, z - Other.z));
        }
        public double Magnitude()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        public Vector3 GetNormalized()
        {
            double magnitude = this.Magnitude();
            return (new Vector3((float)(x / magnitude), (float)(y / magnitude), (float)(z / magnitude)));
        }
        public Vector3 CrossProduct(Vector3 Other)
        {
            return (new Vector3(y * Other.z - z * Other.y, z * Other.x - x * Other.z, x * Other.y - y * Other.x));
        }
        public double DotProduct(Vector3 Other)
        {
            return (x * Other.x + y * Other.y + z * Other.z);
        }


    }
}
