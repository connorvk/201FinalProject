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

        if (SceneManager.GetSceneByBuildIndex(5).isLoaded)
        {
            Debug.Log("unload for market");
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(5));
            SceneManager.UnloadSceneAsync(6);
        }

        else if (UserInfo.SignedIn)
        {
            GameManager.PlayerInstance.GetComponent<SpriteRenderer>().enabled = true;
            GameManager.PlayerInstance.GetComponent<PlayerMovement>().enabled = true;
            SceneManager.LoadScene(sceneIndex);
        }
        else if (sceneIndex == 0 || sceneIndex == 1  || sceneIndex == 2) //anyone can log out or go to forest level
        {
            GameManager.PlayerInstance.GetComponent<SpriteRenderer>().enabled = true;
            GameManager.PlayerInstance.GetComponent<PlayerMovement>().enabled = true;
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            ErrorResults.text = "Error: Must be signed in to access";
        }
    }
}