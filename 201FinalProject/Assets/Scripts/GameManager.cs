using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading;

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
    public LevelState CurrentState;
    public static Thread saveThread;
    private EventWaitHandle saveThreadWait;
    
    private bool saveThreadRunning;

    public void LoadBattleScene(LevelState state)
    {
        player.SetActive(false);
        SceneManager.LoadScene("BattleScene");
    }

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
        
        //TODO get the JSON file from connor to load forest
        CurrentState = LevelState.Forest;

        //MultisaveThreading starts here
        saveThread = new Thread(save);
        saveThreadWait = new EventWaitHandle(true, EventResetMode.ManualReset);
        saveThread.Start();
    }

    public void save()
    {
        //Debug.Log("server started");
        saveThreadWait.Reset();
        saveThreadWait.WaitOne();
        //Do your work here user break
        //Debug.Log("Put save code here");
        saveThreadWait.Reset();
    }


    // Update is called once per frame
    void Update()
    {
    }
}
 