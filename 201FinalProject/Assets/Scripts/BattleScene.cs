using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour {
    bool battle;
    bool playerWin;

    private GameObject curr;
    private GameObject enemy;
    private GameObject player;
    private monsterScript PlayerMonsterFromPlayer;

    [SerializeField]
    GameObject Monster;
    [SerializeField]
    GameObject Player;

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
    void Awake ()
    {
        battle = false;
        playerWin = false;

        //generate a wild monster
        //enemy = (GameObject)Instantiate(Monster, new Vector2(0, 0), Quaternion.identity);
        enemy = Monster;
        enemy.GetComponent<monsterScript>().Awake();
        //generate player monster
        //player = (GameObject)Instantiate(BLOBpre, new Vector2(0, 0), Quaternion.identity);

        player = Player;
        List<monsterScript> inventory = PlayerInventory.Inventory.InventoryList;
        PlayerMonsterFromPlayer = inventory[0];
        Debug.Log("Player's first monster: " + inventory.Count);
        Debug.Log("Player's first monster: " + PlayerMonsterFromPlayer.type);
        Debug.Log("Player's first monster: " + PlayerMonsterFromPlayer.MonsterInfo.moves.Count);

        moveOne.GetComponentInChildren<Text>().text= PlayerMonsterFromPlayer.MonsterInfo.moves[0].moveName;
        moveTwo.GetComponentInChildren<Text>().text = PlayerMonsterFromPlayer.MonsterInfo.moves[1].moveName;
        nextTurn();
	}

    void nextTurn()
    {
        if (!battle)
        {
            battle = true;
            if (PlayerMonsterFromPlayer.MonsterInfo.currHP > 0)
            {
                curr = player.gameObject;
                MessageText.text = "Player Move.......";
            }
        }
        else if (battle)
        {
            battle = false;
            if (enemy.GetComponent<monsterScript>().MonsterInfo.currHP > 0)
            {
                curr = enemy.gameObject;
                MessageText.text = "Enemy Move!!!!!";
                enemyAttack();
            }
        }
    }

    public void makeMoveOne()
    {
        enemy.GetComponent<monsterScript>().MonsterInfo.currHP -= PlayerMonsterFromPlayer.MonsterInfo.moves[0].dmg;
        nextTurn();
    }

    public void makeMoveTwo()
    {

        enemy.GetComponent<monsterScript>().MonsterInfo.currHP -= PlayerMonsterFromPlayer.MonsterInfo.moves[1].dmg;
        nextTurn();
    }

    void enemyAttack()
    {
        int n = Random.Range(0, 10);
        if(n >= 7)
        {
            PlayerMonsterFromPlayer.MonsterInfo.currHP -= enemy.GetComponent<monsterScript>().MonsterInfo.moves[1].dmg;
        }
        else
        {
            PlayerMonsterFromPlayer.MonsterInfo.currHP -= enemy.GetComponent<monsterScript>().MonsterInfo.moves[0].dmg;
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
	void Update ()
    {
        playerHP.text = "Player hp: " + PlayerMonsterFromPlayer.MonsterInfo.currHP;
        enemyHP.text = "Enemy hp: " + enemy.GetComponent<monsterScript>().MonsterInfo.currHP;
    }
}
