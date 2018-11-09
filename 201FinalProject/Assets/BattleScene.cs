using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour {
    bool battle;
    bool playerWin;
    GameObject curr;
    GameObject enemy;
    GameObject player;

    [SerializeField]
    GameObject BLOBpre;
    [SerializeField]
    GameObject LONGpre;
    [SerializeField]
    GameObject CSpr;

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

    // Use this for initialization
    void Start () {
        battle = false;
        playerWin = false;
        //generate a wild monster
        enemy = (GameObject)Instantiate(BLOBpre, new Vector2(0,0), Quaternion.identity);

        //generate player monster
        player = (GameObject)Instantiate(BLOBpre, new Vector2(0, 0), Quaternion.identity);
        moveOne.GetComponentInChildren<Text>().text= player.GetComponent<monsterScript>().moves[0].moveName;
        moveTwo.GetComponentInChildren<Text>().text = player.GetComponent<monsterScript>().moves[1].moveName;
        nextTurn();
	}

    void nextTurn()
    {
        if (!battle)
        {
            battle = true;
            if (player.GetComponent<monsterScript>().currHP > 0)
            {
                curr = player.gameObject;
                MessageText.text = "Player Move.......";
            }
        }
        else if (battle)
        {
            battle = false;
            if (enemy.GetComponent<monsterScript>().currHP > 0)
            {
                curr = enemy.gameObject;
                MessageText.text = "Enemy Move!!!!!";
                enemyAttack();
            }
        }
    }

    public void makeMoveOne()
    {
        enemy.GetComponent<monsterScript>().currHP -= player.GetComponent<monsterScript>().moves[0].dmg;
        nextTurn();
    }

    public void makeMoveTwo()
    {

        enemy.GetComponent<monsterScript>().currHP -= player.GetComponent<monsterScript>().moves[1].dmg;
        nextTurn();
    }

    void enemyAttack()
    {
        int n = Random.Range(0, 10);
        if(n >= 7)
        {
            player.GetComponent<monsterScript>().currHP -= enemy.GetComponent<monsterScript>().moves[1].dmg;
        }
        else
        {
            player.GetComponent<monsterScript>().currHP -= enemy.GetComponent<monsterScript>().moves[0].dmg;
        }
        nextTurn();

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
        enemyHP.text = "Enemy hp: " + enemy.GetComponent<monsterScript>().currHP;
        playerHP.text = "Player hp: " + player.GetComponent<monsterScript>().currHP;
    }
}
