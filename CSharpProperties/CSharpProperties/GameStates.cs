using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProperties
{
    class GameStates
    {
        public enum GState { Warmup, InProgress, PostMatch };
        public GState State
        {
            get { return State; }
            set { OnStateChanged(State); State = value; }
        }

        public void OnStateChanged(GState oldState)
        {
            //Transition between old state and the current state
        }

    }
}
