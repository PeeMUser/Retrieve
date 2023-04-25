using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asset.Code.States;
using Asset.Code.Interfaces;

public class RealStageManager : MonoBehaviour
{
    private StatesManager activateState;
    

    // Start is called before the first frame update
    void Start()
    {
        activateState = new BeginStates(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (activateState != null)
            activateState.StaticUpdate();
    }
    public void SwitchState(StatesManager newState)
    {
        activateState = newState;
    }
}
