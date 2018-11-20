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
        else if (sceneIndex == 0 || sceneIndex == 2) //anyone can log out or go to forest level
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            ErrorResults.text = "Error: Must be signed in to access";
        }
    }
}