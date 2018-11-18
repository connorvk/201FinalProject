using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterScript : MonoBehaviour
<<<<<<< HEAD
{
    private string FolderName;
    public enum Type
    {
        BLOB,
        Long,
        Char_Star
    }
    public Type type;
    private string MonsterName;
    public bool status;
    public int currHP;
    public int maxHP;
    public List<monsterMove> moves;
    private SpriteRenderer spriteR;
    private Sprite[] sprites;

    public void LoadMonsetrSprite(int type)
    {
        Debug.Log("here");
        Debug.Log(sprites.Length);
        spriteR.sprite = sprites[type];
    }

    // Use this for initialization
    void Awake () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        maxHP = 100;
        status = false;
        FolderName = "../EnemySprites/en";
        sprites = Resources.LoadAll<Sprite>(FolderName);
        if (!status)
        {
            //wild monster init
            currHP = maxHP;
            if (type == Type.BLOB)
            {
                MonsterName = "wild BLOB";
                LoadMonsetrSprite(0);
            }
            else if (type == Type.Long)
            {
                MonsterName = "wild Long";
            }
            else if (type == Type.Char_Star)
            {
                MonsterName = "wild Char_Star";

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
=======
{
    public enum Type
    {
        BLOB,
        Long,
        Char_Star
    }
    public Type type;
    public string mName;
    public bool status;
    public int currHP;
    public int maxHP;
    public List<monsterMove> moves;

    // Use this for initialization
    void Awake () {
        maxHP = 100;
        status = false;
        if (!status)
        {
            //wild monster init
            currHP = maxHP;
            if (type == Type.BLOB)
            {
                mName = "wild BLOB";
            }
            else if (type == Type.Long)
            {
                mName = "wild Long";
            }
            else if (type == Type.Char_Star)
            {
                mName = "wild Char_Star";

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
	

	// Update is called once per frame
	void Update () {
		
	}
}
>>>>>>> edc418e8d001a290289267a27dacd45d64ef8271
