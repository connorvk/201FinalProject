using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public Text ErrorResults;

    public void OnPointerClick(int sceneIndex)
    {
        ErrorResults.text = "";
        if (UserInfo.SignedIn)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else if (sceneIndex == 2) //anyone can go to forest level
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            ErrorResults.text = "Error: Must be signed in to access";
        }
    }
}