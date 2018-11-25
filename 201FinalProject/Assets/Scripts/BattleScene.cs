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

    IEnumerator EnemyWaitCouroutine(float duration){ yield return new WaitForSeconds(duration);}

    // Use this for initialization
    void Awake ()
    {
        battle = false;
        playerWin = false;

        enemy = Monster;
        enemy.GetComponent<monsterScript>().Awake();

        player = Player;
        List<monsterScript.Type> inventory = PlayerInventory.Inventory.InventoryList;
        PlayerMonsterFromPlayer = new monsterScript();
        PlayerMonsterFromPlayer.type = inventory[0];
        PlayerMonsterFromPlayer.Awake();
        Debug.Log("DEBUG HERE: " + PlayerMonsterFromPlayer.type);
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
            else
                battleEnd();
        }
        else if (battle)
        {
            battle = false;
            if (enemy.GetComponent<monsterScript>().MonsterInfo.currHP > 0)
            {
                MessageText.text = "Enemy Move!!!!!";
                Debug.Log("Enemy is moving");
                curr = enemy.gameObject;
                enemyAttack();
            }
            else
            {
                playerWin = true;
                battleEnd();
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
        if (n >= 7)
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
            GameManager.instance.LoadForestScene();
            PlayerInventory.Inventory.InventoryList.Add(enemy.GetComponent<monsterScript>().MonsterInfo.MonsterType);
            GameManager.instance.processSave();
        }
        else if (!playerWin)
        {
            GameManager.instance.LoadGameOverScene();
        }

    }

	// Update is called once per frame
	void Update ()
    {
        playerHP.text = "Player hp: " + PlayerMonsterFromPlayer.MonsterInfo.currHP;
        enemyHP.text = "Enemy hp: " + enemy.GetComponent<monsterScript>().MonsterInfo.currHP;
    }
}
