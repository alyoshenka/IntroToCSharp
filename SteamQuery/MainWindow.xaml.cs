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

using System.Net;
using System.IO;

namespace SteamQuery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string webApiKey = "";
        string userID = "";
        string k = "[apikey]";
        string i = "[steamid]";

        public MainWindow()
        {        
            string gGetPlayerSummaries = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=[apikey]&steamids=[steamid]";
            string gGetOwnedGames = "http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=[apikey]&steamid=[steamid]";


            InitializeComponent();

            string ps = MakeNewRequest(gGetOwnedGames);

            GameListRootobject tmp = Newtonsoft.Json.JsonConvert.DeserializeObject<GameListRootobject>(ps);
            string outputTxt = "";
            for(int i = 0; i < tmp.response.game_count; i++)
            {
                outputTxt += tmp.response.games[i].appid + "\n";
            }
            output.Text = outputTxt;
        }

        public string MakeNewRequest(string url)
        {
            url = url.Replace(k, webApiKey);
            url = url.Replace(i, userID);

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream ds = response.GetResponseStream();
            StreamReader sr = new StreamReader(ds);
            string responseFromServer = sr.ReadToEnd();
            sr.Close();
            response.Close();
            return responseFromServer;
        }

    }
}
