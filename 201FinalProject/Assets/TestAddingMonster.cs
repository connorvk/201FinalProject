using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddingMonster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void addingAMonster()
    {
        monsterScript Monster = gameObject.AddComponent(typeof(monsterScript)) as monsterScript;
        Monster.MonsterInfo.MonsterType = monsterScript.Type.Char_Star;
        PlayerInventory.AddMonseter(Monster);
        Debug.Log("Added Char_Star");
        Debug.Log(UserInfo.SignedIn);
        Debug.Log(PlayerInventory.Inventory.InventoryList[0] + "\n" + PlayerInventory.Inventory.InventoryList[1]);
    }
}
