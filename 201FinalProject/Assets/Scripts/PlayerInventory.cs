using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public static ListWrapper Inventory;
    void AddMonster(monsterScript monster) { Inventory.InventoryList.Add(monster); }
    void RemoveMonster(monsterScript monster) { Inventory.InventoryList.Remove(monster); }

    // Use this for initialization
    void Awake ()
    {
        Inventory = new ListWrapper();
        //monsterScript DefaultMonster = ScriptableObject.CreateInstance<monsterScript>();
        monsterScript DefaultMonster = new monsterScript();
        DefaultMonster.Awake();
        AddMonster(DefaultMonster);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

[System.Serializable]
public class ListWrapper
{
    public List<monsterScript> InventoryList;

    public ListWrapper()
    {
        this.InventoryList = new List<monsterScript>();
    }
}