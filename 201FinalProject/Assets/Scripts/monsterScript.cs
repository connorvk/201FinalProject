using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class monsterScript : MonoBehaviour
{
    private string FolderName;
    public enum Type
    {
        BLOB,
        Long,
        Char_Star
    }
    public Type type;
    public string MonsterName;
    public bool status;
    [HideInInspector]
    public int currHP;
    [HideInInspector]
    public int maxHP;
    [HideInInspector]
    public List<monsterMove> moves;
    [HideInInspector]
    private SpriteRenderer spriteR;
    private Sprite[] sprites;

    public void LoadMonsterSprite(int type)
    {
        Debug.Log(sprites.Length);
        //this assignment doesn't work after I made monsterScript into a ScriptableObject
        spriteR.sprite = sprites[type];
    }

    // Use this for initialization
    void Awake () {
        spriteR = GetComponent<SpriteRenderer>();
        moves = new List<monsterMove>();
        maxHP = 100;
        status = false;
        sprites = Resources.LoadAll<Sprite>("EnemySprites");
        if (!status)
        {
            //wild monster init
            currHP = maxHP;
            if (type == Type.BLOB)
            {
                MonsterName = "wild BLOB";
                LoadMonsterSprite(1);
            }
            else if (type == Type.Long)
            {
                MonsterName = "wild Long";
                LoadMonsterSprite(232);
            }
            else if (type == Type.Char_Star)
            {
                MonsterName = "wild Char_Star";
                LoadMonsterSprite(567);
            }

        }

        if(type == Type.BLOB)
        {
            moves.Add(new monsterMove("blob one", 5));
            moves.Add(new monsterMove("blob two", 10));
        }
        else if(type == Type.Long)
        {
            moves.Add(new monsterMove("long one", 5));
            moves.Add(new monsterMove("long two", 12));
        }
        else if(type == Type.Char_Star)
        {
            moves.Add(new monsterMove("long one", 5));
            moves.Add(new monsterMove("long two", 15));
        }
	}

    public int moveOne()
    {
        return moves[0].dmg;
    }

    public int moveTwo()
    {
        return moves[1].dmg;
    }
}
