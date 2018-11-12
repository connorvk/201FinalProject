using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuestLogin : MonoBehaviour {


    public void LoadByIndex(int sceneIndex)
    {
        UserInfo.SignedIn = false;
        SceneManager.LoadScene(sceneIndex);
    }
}
