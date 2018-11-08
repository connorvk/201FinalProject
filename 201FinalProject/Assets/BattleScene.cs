using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour {
    bool battle;
    bool playerWin;
    monsterScript player;
    monsterScript enemy;

    [SerializeField]
    GameObject MessagePanel;
    [SerializeField]
    Text MessageText;
    [SerializeField]
    Button moveOne;
    [SerializeField]
    Button moveTwo;


    [SerializeField]
    Text enemyHP;
    [SerializeField]
    Text playerHP;

    State currState;

    enum State
    {
        Init,
        Player,
        Enemy,
        RoundEnd
    }

    // Use this for initialization
    void Start () {
        battle = true;
        playerWin = false;
        currState = State.Init;
        //generate a wild monster

        //generate player monster
		
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
        if (playerWin)
        {
            //handle player
        }
        else if (!playerWin)
        {
            //lol
        }
        
    }

	// Update is called once per frame
	void Update () {
        while (battle)
        {
            playerAttack();
            enemyAttack();

            if(player.currHP <= 0)
            {
                //new monster
                //if no new monster
                battle = false;
                playerWin = false;

            }
            else if(enemy.currHP <= 0)
            {
                battle = false;
                playerWin = true;
            }
        }

        battleEnd();
    }
}
