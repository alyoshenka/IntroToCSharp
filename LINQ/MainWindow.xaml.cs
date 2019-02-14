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

using System.IO;

namespace LINQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<PlayerData> players;
        IOrderedEnumerable<PlayerData> top10;        

        public MainWindow()
        {
            InitializeComponent();
            players = LoadPlayerData("../../hscores.txt");
            // get top 10
            top10 = players.Where(delegate (PlayerData p) { return p.Rank <= 10; } )
                .OrderByDescending(delegate(PlayerData p) { return -p.Rank; });
            // put data into window list
           
            hsList.DataContext = top10;
        }

        public List<PlayerData> LoadPlayerData(string file)
        {
            List<string> lines = new List<string>();
            List<PlayerData> players = new List<PlayerData>();
            // get lines
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while((line = sr.ReadLine()) != null) { lines.Add(line); }
            }
            // parse info
            string[] split;
            foreach(string line in lines)
            {
                split = line.Split(',');
                players.Add(new PlayerData(split[0], int.Parse(split[1]), int.Parse(split[2]) ) );
            }
            return players;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ApplyData(object sender, RoutedEventArgs e)
        {
            string s = nameTB.Text;
            string hs = hsTB.Text;
            string r = rankTB.Text;
            // if empty field
            if (s.Length == 0 || hs.Length == 0 || r.Length == 0)
            {
                // do nothing
                errorTB.Text = "empty field(s)";
                hsList.DataContext = top10;
                return;
            } 

            // check vals
            try { int.Parse(hs); int.Parse(r); }
            catch
            {
                // do nothing
                errorTB.Text = "non-int";
                hsList.DataContext = top10;
                return;
            } 

            PlayerData user = new PlayerData(s, int.Parse(r), int.Parse(hs));

            List<PlayerData> temp = players;
            temp.Add(user);
            var top11 = players.Where(delegate (PlayerData p) { return p.Rank <= 10 || p == user; } )
                .OrderByDescending(delegate (PlayerData p) { return -p.Rank; });
            hsList.DataContext = top11;

            //foreach (ListBoxItem i in hsList.Items)
            //{
            //    if(i.DataContext == user) { i.Background = Brushes.BlueViolet; }
            //}
        }

        private void hsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
