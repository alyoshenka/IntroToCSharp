using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingErrors
{
    class GameState
    {
        public enum States { Warmup, InProgress, PostMatch };
        private States currentState;

        public States State
        {
            get => currentState;
            set
            {
                ValueChanged(value);
                currentState = value;
            }
        }

        // before change happens
        private void ValueChanged(States newVal)
        {
            // use old as currentState, new as newVal
            Console.WriteLine("State changed from " + currentState + " -> " + newVal);
        }
    }
}
