using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public static ListWrapper Inventory;
    public GameObject Monster;
    void AddMonseter(monsterScript monster) { Inventory.InventoryList.Add(monster.MonsterInfo.MonsterType); }
    void RemoveMonseter(monsterScript monster) { Inventory.InventoryList.Remove(monster.MonsterInfo.MonsterType); }
    // Use this for initialization
    void Awake ()
    {
        Inventory = new ListWrapper();
        //monsterScript DefaultMonster = ScriptableObject.CreateInstance<monsterScript>();
        //monsterScript DefaultMonster = new monsterScript();
        //DefaultMonster.Awake();
        //AddMonster(DefaultMonster);
        monsterScript DefaultMonster = gameObject.AddComponent(typeof(monsterScript)) as monsterScript;
        DefaultMonster.type = monsterScript.Type.BLOB;
        AddMonseter(DefaultMonster);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

[System.Serializable]
public class ListWrapper
{
    public List<monsterScript.Type> InventoryList;

    public ListWrapper()
    {
        this.InventoryList = new List<monsterScript.Type>();
    }
}