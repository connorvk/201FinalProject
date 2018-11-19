using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class monsterScript : ScriptableObject
{
    public string FolderName;
    public enum Type
    {
        BLOB,
        Long,
        Char_Star
    }
    public Type type;
    public string MonsterName;
    public bool status;
    public int currHP;
    public int maxHP;
    public List<monsterMove> moves;
    public SpriteRenderer spriteR;
    public Sprite[] sprites;

    public void LoadMonsetrSprite(int type)
    {
        Debug.Log(sprites.Length);
        //this assignment doesn't work after I made monsterScript into a ScriptableObject
        //spriteR.sprite = sprites[type];
    }

    // Use this for initialization
    void Awake () {
        moves = new List<monsterMove>();
        spriteR = new SpriteRenderer();
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
                LoadMonsetrSprite(1);
            }
            else if (type == Type.Long)
            {
                MonsterName = "wild Long";
                LoadMonsetrSprite(232);
            }
            else if (type == Type.Char_Star)
            {
                MonsterName = "wild Char_Star";
                LoadMonsetrSprite(99);
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
