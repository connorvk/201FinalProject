using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSpritePlayer : MonoBehaviour
{
    public void LoadMonsterSprite(int type)
    {
        spriteR.sprite = sprites[type];
    }
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("EnemySprites");

        List<monsterScript.Type> inventory = PlayerInventory.Inventory.InventoryList;
        monsterScript.Type type = inventory[0];

        if (type == monsterScript.Type.BLOB)
            LoadMonsterSprite(1);
        else if (type == monsterScript.Type.Char_Star)
            LoadMonsterSprite(567);
        else if (type == monsterScript.Type.Long)
            LoadMonsterSprite(232);
    }
}
