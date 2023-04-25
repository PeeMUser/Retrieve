using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asset.Code.Interfaces;

namespace Asset.Code.States
{
    public class BeginStates : StatesManager
    {
        private RealStageManager manager;
        public BeginStates(RealStageManager managerRef )
        {
            manager = managerRef;
            Debug.Log("Construting BeginState");
        }
        public void StaticUpdate()
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                manager.SwitchState(new PlayStates(manager));
            }
        }


        public void ShowIT()
        {

        }
    }
}   
