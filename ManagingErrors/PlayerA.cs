using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingErrors
{
    class PlayerA
    {
        public static PlayerA classReference;

        private string name = "null";
        private int frag = 0;
        private int death = 0;
        private int totalDamage = 0;
        // private int score;
        public string Name
        {
            get => name;
            set => name = value.Length > 0 ? value : name;
        }

        public int Frag
        {
            get => frag;
            set => frag = value >= 0 ? frag + value : frag; // add 1
        }

        // inly increments by 1
        public int Death
        {
            get => death;
            set => ++death;
        }

        public int TotalDamage
        {
            get => totalDamage;
            set => totalDamage = value >= 0 ? totalDamage + value : totalDamage; // only go up
        }

        public int Score { get => (frag - death); }
    }
}
