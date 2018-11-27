using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class monsterScript : MonoBehaviour
{
    public class Monster
    {
        public List<monsterMove> moves;
        public int currHP;
        public string MonsterName;
        public Type MonsterType;
        public Monster(Type type)
        {
            MonsterType = type;
            moves = new List<monsterMove>();
            int maxHP = 100;
            currHP = maxHP;
            if (type == Type.BLOB)
            {
                MonsterName = "wild BLOB";
                moves.Add(new monsterMove("Goo Throw", 5));
                moves.Add(new monsterMove("Toxic", 10));
            }
            else if (type == Type.Long)
            {
                MonsterName = "wild Long";
                moves.Add(new monsterMove("Bind", 5));
                moves.Add(new monsterMove("Bite", 12));
            }
            else if (type == Type.Char_Star)
            {
                MonsterName = "wild Char_Star";
                moves.Add(new monsterMove("Throwing Star", 5));
                moves.Add(new monsterMove("Charring", 15));
            }
        }
    }

    private string FolderName;
    [System.Serializable]
    public enum Type
    {
        BLOB,
        Long,
        Char_Star
    }
    public Type type;
    public string MonsterName;
    public bool status;
    public Monster MonsterInfo;

    // Use this for initialization
    public void Awake ()
    {
        status = false;
        if (!status)
        {
            //wild monster init
            if (type == Type.BLOB)
                MonsterInfo = new Monster(Type.BLOB);
            else if (type == Type.Long)
                MonsterInfo = new Monster(Type.Long);
            else if (type == Type.Char_Star)
                MonsterInfo = new Monster(Type.Char_Star);
        }
	}

    public int moveOne()
    {
        return MonsterInfo.moves[0].dmg;
    }

    public int moveTwo()
    {
        return MonsterInfo.moves[1].dmg;
    }
}
