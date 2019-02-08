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

using System.Reflection;


namespace LevelEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock levelOutput;
        Grid g;

        public MainWindow()
        {
            InitializeComponent();

            levelOutput = FindName("levelO") as TextBlock;
            g = FindName("grid") as Grid;

            //This first section cache's the various strings we'll be using
            //this helps demonstrate that the classes & methods can all
            //be entirely data driven.
            string workingDir = System.IO.Directory.GetCurrentDirectory();
            string dllFileName = "/ExternLib.dll";
            string extClass = "ExternLib.Level";
            string extMethod = "Test";
            string levelMethod = "GetLevel";
            string l1 = "level1.txt";

            //First load the external assembly
            Assembly ass = Assembly.LoadFile(workingDir + dllFileName);

            //Get th type of the desired class (including the namespace)
            Type typ = ass.GetType(extClass);

            //Get the supporting method info so we can execute a method.
            MethodInfo meth = typ.GetMethod(extMethod);
            MethodInfo meth2 = typ.GetMethod(levelMethod);

            //Create an instance of the desired object
            object obj = Activator.CreateInstance(typ);

            //And invoke the method
            levelOutput.Text = meth.Invoke(obj, null).ToString();

            object[] p = new object[] { l1 };
            List<int> lev1 = meth2.Invoke(obj, p) as List<int>;

            levelOutput.Text = "Level 1 map";
            Rectangle[] recs = ImageFromIntData(lev1);
            if (recs[0].AreAnyTouchesOver) { recs[0].Fill = System.Windows.Media.Brushes.Green; }
        }

        public Rectangle[] ImageFromIntData(List<int> data)
        {
            Rectangle[] tiles = new Rectangle[data.Count];
            int w, h, x, y;
            w = h = x = y = 16;
            y = 50;

            Window win = FindName("mw") as Window;

            int winW = (int)win.Width;
            int winH = (int)win.Height;

            foreach (int i in data)
            {
                int idx = 0;
                Rectangle tile = new Rectangle();
                tile.Margin = new Thickness(x, y, 0-w, 0-h);
                tile.Width = w;
                tile.Height = h;
                tile.HorizontalAlignment = HorizontalAlignment.Left;
                tile.VerticalAlignment = VerticalAlignment.Top;
                switch (i)
                {
                    case 0: // wall
                        tile.Fill = System.Windows.Media.Brushes.Gray;
                        x += w+2;
                        break;
                    case 1: // t2
                        tile.Fill = System.Windows.Media.Brushes.Black;
                        x += w + 2;
                        break;
                    case 2:
                        tile.Fill = System.Windows.Media.Brushes.Purple;
                        x += w + 2;
                        break;
                    case 3:
                        tile.Fill = System.Windows.Media.Brushes.White;
                        x += w + 2;
                        break;
                    case -1:
                        y += h + 2;
                        x = w;
                        break;
                    default:
                        tile.Fill = System.Windows.Media.Brushes.Red;
                        x += w + 2;
                        break;
                }
                
                g.Children.Add(tile);
                tiles[idx++] = tile;   
            }

            win.Width = x + w;
            win.Height = y + h;

            return tiles;
        }
    }
}
