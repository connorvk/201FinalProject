using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteRendererEnemy : MonoBehaviour {

    public void LoadMonsterSprite(int type)
    {
        spriteR.sprite = sprites[type];
    }
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    private monsterScript Monster;
    void Start ()
    {
        spriteR = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("EnemySprites");
        Monster = GetComponent<monsterScript>();

        if (Monster.type == monsterScript.Type.BLOB)
            LoadMonsterSprite(1);
        else if (Monster.type == monsterScript.Type.Char_Star)
            LoadMonsterSprite(567);
        else if (Monster.type == monsterScript.Type.Long)
            LoadMonsterSprite(232);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
