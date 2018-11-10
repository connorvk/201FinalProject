using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : MonoBehaviour {
    State currState;

    enum State
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        SELECTING,
        ACTION,
        DEAD
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (currState)
        {
            case (State.PROCESSING):
                break;
            case (State.ADDTOLIST):
                break;
            case (State.WAITING):
                break;
            case (State.SELECTING):
                break;
            case (State.ACTION):
                break;
            case (State.DEAD):
                break;

        }
	}
}
