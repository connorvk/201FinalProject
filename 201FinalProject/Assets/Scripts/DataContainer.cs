using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour {

    public HashSet<monsterScript.Type> fastInventory;
    public Stack<GameObject> scenesInGame;
    public Queue<string> attackTurnOrder;

    public DataContainer()
    {
        fastInventory = new HashSet<monsterScript.Type>();
        scenesInGame = new Stack<GameObject>();
        attackTurnOrder = new Queue<string>();
    }
}
