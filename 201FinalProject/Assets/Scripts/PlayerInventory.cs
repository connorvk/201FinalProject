using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    private HashSet<monsterScript> Inventory;
    public GameObject Monster;

    void AddMonseter(monsterScript monster) { Inventory.Add(monster); }
    void RemoveMonseter(monsterScript monster) { Inventory.Remove(monster); }

    // Use this for initialization
    void Awake ()
    {
        monsterScript DefaultMonster = new monsterScript();
        DefaultMonster.type = monsterScript.Type.BLOB;
        Inventory.Add(DefaultMonster);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LoadInventory(string inventoryJSON)
    {
        Inventory = JsonUtility.FromJson<HashSet<monsterScript>>(inventoryJSON);
    }

    public HashSet<monsterScript> GetInventory()
    {
        return Inventory;
    }
}
