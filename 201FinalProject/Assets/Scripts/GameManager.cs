using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading;
using System.IO;
using System.Text;

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
        UserInfo.SignedIn = false;

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
        if (UserInfo.SignedIn)
        {
            string inventJSON = JsonUtility.ToJson(PlayerInventory.Inventory);
            TypeNamePass savePackage = new TypeNamePass("Save", UserInfo.SignedInUser, "null", inventJSON);

            string saveMessage = JsonUtility.ToJson(savePackage);
            using (FileStream fs = File.Create(UserInfo.SignedInUser + ".json"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(saveMessage);
                fs.Write(info, 0, info.Length);
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
            WaitForResults();
            if (UserInfo.SaveResult)
            {
                Debug.Log("Saved");
            }
        }
        saveThreadWait.Reset();
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void WaitForResults()
    {
        //need a coroutine to make it wait, I think
        StartCoroutine(ReadFile());
    }

    //I don't entirely understand this but it seems to put this script in a waiting state until the json exists
    IEnumerator ReadFile()
    {
        yield return new WaitUntil(() => IsFileReady(UserInfo.SignedInUser + "Result.json"));
        string message = "";
        while (!IsFileReady(UserInfo.SignedInUser + "Result.json")) { }
        while (message.Length == 0) { message = File.ReadAllText(UserInfo.SignedInUser + "Result.json"); }

        if (message != null)
        {
            UserResults ur = JsonUtility.FromJson<UserResults>(message);
            while (File.Exists(UserInfo.SignedInUser + "Result.json"))
            {
                File.Delete(UserInfo.SignedInUser + "Result.json");
            }
            UserInfo.SaveResult = ur.Result;
        }
    }

    public bool IsFileReady(string filename)
    {
        if (!File.Exists(filename))
        {
            return false;
        }
        // If the file can be opened for exclusive access it means that the file
        // is no longer locked by another process.
        try
        {
            using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                return inputStream.Length > 0;
        }
        catch (IOException ioe)
        {
            Debug.Log(ioe.Message);
        }
        return false;
    }
}
 