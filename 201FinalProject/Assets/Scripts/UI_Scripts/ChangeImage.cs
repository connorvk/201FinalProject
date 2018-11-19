using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {

    public Image imagePrefab;
    private HashSet<monsterScript> Monsters;
    private List<Sprite> MonsterImages = new List<Sprite>();
    private string username;
    //public Sprite MonsterSprite;

    // Use this for initialization
    void Start ()
    {
        Instantiate(GameManager.instance.player.GetComponent<PlayerInventory>());
        Monsters = GameManager.instance.player.GetComponent<PlayerInventory>().Inventory;
        //Debug.Log(Monsters.Count); 
        foreach (monsterScript monster in Monsters)
            MonsterImages.Add(monster.GetComponent<SpriteRenderer>().sprite);
        Debug.Log(MonsterImages.Count);
        for(int i = 0; i < MonsterImages.Count; i++)
        {
            Image imageInstance = Instantiate(imagePrefab);
            imageInstance.transform.SetParent(this.transform, true);
            imageInstance.sprite = MonsterImages[i];
        }
    }
	
}
