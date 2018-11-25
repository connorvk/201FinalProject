using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public static ListWrapper Inventory;
    public GameObject Monster;
    public static void AddMonseter(monsterScript monster) { Inventory.InventoryList.Add(monster.MonsterInfo.MonsterType); }
    public static void RemoveMonseter(monsterScript monster) { Inventory.InventoryList.Remove(monster.MonsterInfo.MonsterType); }
    // Use this for initialization
    void Awake ()
    {
        Inventory = new ListWrapper();
        //monsterScript DefaultMonster = ScriptableObject.CreateInstance<monsterScript>();
        //monsterScript DefaultMonster = new monsterScript();
        //DefaultMonster.Awake();
        //AddMonster(DefaultMonster);
        monsterScript DefaultMonster = gameObject.AddComponent(typeof(monsterScript)) as monsterScript;
        DefaultMonster.type = monsterScript.Type.Char_Star;
        AddMonseter(DefaultMonster);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(Inventory.InventoryList.Count);
            Debug.Log(Inventory.InventoryList[0].GetType());
        }
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