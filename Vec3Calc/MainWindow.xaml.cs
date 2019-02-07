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

using ManagingErrors;

namespace Vec3Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Vector3 v1;
        Vector3 v2;

        TextBox v1Input;
        TextBox v2Input;
        TextBlock output;
        TextBlock error;
        TextBlock instructions;
        TextBlock detailedOutput;
        ComboBox cb;

        public MainWindow()
        {
            InitializeComponent();
            v1Input = FindName("v1In") as TextBox;
            v2Input = FindName("v2In") as TextBox;
            output = FindName("outputWin") as TextBlock;
            error = FindName("errorWin") as TextBlock;
            instructions = FindName("instructWin") as TextBlock;
            instructions.Text = "Enter the x, y, and z values as integers separated by commas into the spaces below."
                + "\nPress ENTER to display the new vector values."
                + "\nThe error window shows when there is invalid input."
                + "\nValid inputs: x,y,z or x, y, z";
            detailedOutput = FindName("detailedOut") as TextBlock;
            cb = FindName("boxyBoy") as ComboBox;
            // cb.SelectedIndex = 0;
        }

        Vector3 ParseInput(string txt)
        {
            if (txt.Length < 5) return new Vector3(); // invalid values -> null, essentially

            try
            {
                // take vec3 string and convert it to nums
                int i = 0;
                float x, y, z;
                string t = "";
                // get first
                while (txt[i] != ',') { t += txt[i++]; }
                x = Int32.Parse(t);
                while (txt[i] == ',' || txt[i] == ' ') i++; // iterate to next number
                t = "";
                while (txt[i] != ',') { t += txt[i++]; }
                y = Int32.Parse(t);
                while (txt[i] == ',' || txt[i] == ' ') i++; // iterate to next number
                t = "";
                while (i < txt.Length) { t += txt[i++]; } // iterate to end
                z = Int32.Parse(t);
                return new Vector3(x, y, z);
            }
            catch
            {
                error.Text = "Invalid input";
                return new Vector3();
            }
        }

        public void NewInput(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return; // only on new entry

            if (sender == v1Input) v1 = ParseInput(v1Input.Text);
            if (sender == v2Input) v2 = ParseInput(v2Input.Text);

            UpdateOutput();
        }

        public void BoxIsClicked(object sender, RoutedEventArgs e)
        {
            TextBox s = sender as TextBox;
            if (s != null) s.Text = ""; // empty
        }

        void UpdateOutput()
        {
            string t = "";
            t = "New input!";
            t += "\nVector 1: " + ShowVec3(v1);
            t += "\nVector 2: " + ShowVec3(v2);
            t += "\nVector 1 Magnitude: " + v1.Magnitude;
            t += "\nVector 2 Magnitude: " + v2.Magnitude;
            t += "\nVector 1 normalized = " + ShowVec3(v1.Normalized);
            t += "\nVector 2 normalized = " + ShowVec3(v2.Normalized);
            t += "\nVector 1 + Vector 2 = " + ShowVec3(v1.Sum(v2));
            t += "\nVector 1 - Vector 2 = " + ShowVec3(v1.Difference(v2));
            t += "\nVector 1 * (dot) Vector 2 = " + v1.Dot(v2);

            output.Text = t;
        }

        public void UpdateDetailedOutput(object sender, SelectionChangedEventArgs e)
        {
            string t = "";
            switch (cb.SelectedIndex)
            {               
                case 0:
                    t = "Vector 1: " + ShowVec3(v1) + "\nVector 2: " + ShowVec3(v2); break;
                case 1:
                    t = "Vector 1 + Vector 2 = " + ShowVec3(v1.Sum(v2)); break;
                case 2:
                    t = "Vector 1 - Vector 2 = " + ShowVec3(v1.Difference(v2)); break;
                case 3:
                    t = "Vector 1 Magnitude: " + v1.Magnitude + "\nVector 2 Magnitude: " + v2.Magnitude; break;
                case 4:
                    t = "Vector 1 normalized = " + ShowVec3(v1.Normalized) + "\nVector 2 normalized = " + ShowVec3(v2.Normalized); break;
                case 5:
                    t = "Vector 1 * (dot) Vector 2 = " + v1.Dot(v2); break;
                default:
                    t = "Programmer error"; break;


            }
            detailedOutput.Text = t;
        }

        string ShowVec3(Vector3 v) { return "x: " + v.x + ", y: " + v.y + ", z: " + v.z; }
    }
}
