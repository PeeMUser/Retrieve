using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asset.Code.Interfaces;

namespace Asset.Code.States
{
    public class WonStates : StatesManager
    {
        private RealStageManager manager;
        public WonStates(RealStageManager managerRef)
        {
            manager = managerRef;
            Debug.Log("Win States");
        }
        public void StaticUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                manager.SwitchState(new BeginStates(manager));
            }
        }
        public void ShowIT()
        {

        }

    }
}
