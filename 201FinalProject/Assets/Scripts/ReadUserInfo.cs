using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class ReadUserInfo : MonoBehaviour
{

    public Text ErrorResults;
    public bool isLogin;

    public void WaitForResults()
    {
        //need a coroutine to make it wait, I think
        StartCoroutine(ReadFile());
    }

    //I don't entirely understand this but it seems to put this script in a waiting state until the json exists
    IEnumerator ReadFile()
    {
        //yield return new WaitUntil(() => !IsFileReady("Passin.json"));
        yield return new WaitUntil(() => IsFileReady("Passout.json"));
        string message = "";
        while (!IsFileReady("Passout.json")) { }
        while (message.Length == 0) { message = File.ReadAllText("Passout.json"); }
        
        if (message != null)
        {
            UserResults ur = JsonUtility.FromJson<UserResults>(message);
            while (File.Exists("Passout.json"))
            {
                File.Delete("Passout.json");
            }
            if (ur.Result)
            {
                UserInfo.SignedIn = true;
                if (isLogin)
                {
                    PlayerInventory.Inventory = JsonUtility.FromJson<ListWrapper>(ur.Userinventory);
                }
                Debug.Log("Signed In: " + UserInfo.SignedIn);

                SceneManager.LoadScene(1);
            }
            else
            {
                ErrorResults.text = ur.Comment;
            }
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