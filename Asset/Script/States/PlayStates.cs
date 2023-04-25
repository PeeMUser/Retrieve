using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asset.Code.Interfaces;

namespace Asset.Code.States
{
    public class PlayStates : StatesManager
    {
        private RealStageManager manager;
        public PlayStates(RealStageManager managerRef)
        {
            manager = managerRef;
            Debug.Log("Playing States");
        }
        public void StaticUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                manager.SwitchState(new WonStates(manager));
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                manager.SwitchState(new LostStates(manager));
            }
        }
        public void ShowIT()
        {

        }

    }
}