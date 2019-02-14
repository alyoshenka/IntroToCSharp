using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamQuery
{
    //Steam Object Classes
    public enum pState { Offline, Online, Busy, Away, Snooze, Looking_to_trade, Looking_to_play };
    public class Rootobject
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public Player[] players { get; set; }
    }

    public class Player
    {
        public string steamid { get; set; }
        public int communityvisibilitystate { get; set; }
        public int profilestate { get; set; }
        public string personaname { get; set; }
        public int lastlogoff { get; set; }
        public string profileurl { get; set; }
        public string avatar { get; set; }
        public string avatarmedium { get; set; }
        public string avatarfull { get; set; }
        public pState personastate { get; set; }
    }
    //Sloppy as anything....


    public class GameListRootobject
    {
        public GameListResponse response { get; set; }
    }

    public class GameListResponse
    {
        public int game_count { get; set; }
        public Game[] games { get; set; }
    }

    public class Game
    {
        public int appid { get; set; }
        public string name { get; set; }
        public int playtime_forever { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
        public bool has_community_visible_stats { get; set; }
    }
}
