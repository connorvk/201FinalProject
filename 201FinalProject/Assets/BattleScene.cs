using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour {
    bool battle;
    monsterScript player;
    monsterScript enemy;

	// Use this for initialization
	void Start () {
        battle = true;
        //generate a wild monster

        //generate player monster
		
	}

    void loadMonsters()
    {
        //player

        //enemy

    }

    void enemyAttack()
    {
        //wait for enemy move
    }

    void playerAttack()
    {
        //wait for player move.
    }

    void battleEnd()
    {
        
    }

	// Update is called once per frame
	void Update () {
        while (battle)
        {
            playerAttack();
            enemyAttack();

            battleEnd();

        }
	}
}
