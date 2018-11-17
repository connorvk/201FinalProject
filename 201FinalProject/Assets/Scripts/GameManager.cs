using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum LevelState
    {
        Forest,
        Lava,
        Desert
    }
    public static GameManager instance = null;
    public GameObject player;
    public LevelState mCurrentState;
	
    public void LoadBattleScene(LevelState state)
    {
        player.SetActive(false);
        SceneManager.LoadScene("BattleScene");
        //if (state == LevelState.Forest)
        //{
        //    SceneManager.LoadScene("BattleScene");
        //}
        //else if (state == LevelState.Desert)
        //{

        //}
        //else if (state == LevelState.Lava)
        //{

        //}
    }

    // Use this for initialization
    void Awake ()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        mCurrentState = LevelState.Forest;
    }

    // Update is called once per frame
    void Update ()
    {
        //TODO do this in another function instead of update

        //if(mCurrentState == LevelState.Forest)
        //{
        //    //Load Level
        //    SceneManager.LoadScene("Forest Level");
        //}
        //else if(mCurrentState == LevelState.Desert)
        //{
        //    //Load Level
        //    SceneManager.LoadScene("Desert Level");
        //}
        //else if(mCurrentState == LevelState.Lava)
        //{
        //    //Load Level
        //    SceneManager.LoadScene("Lava Level");
        //}
    }
}
