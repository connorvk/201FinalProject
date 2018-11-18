using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SubmitLogin : MonoBehaviour {

    public InputField UserField;
    public InputField PassField;
    public Text ErrorUser;
    public Text ErrorPass;
    public Text ErrorResults;
    public TypeNamePass userPackage;

    public void AttemptLogin(string type)
    {
        bool emptyField = false;
        string user = UserField.text.Trim();
        string pass = PassField.text.Trim();
        ErrorUser.text = "";
        ErrorPass.text = "";
        ErrorResults.text = "";
        while (File.Exists("Passout.json"))
        {
            File.Delete("Passout.json");
        }

        if (user.Length == 0)
        {
            emptyField = true;
            ErrorUser.text = "Enter a username.";
        }
        if (pass.Length == 0)
        {
            emptyField = true;
            ErrorPass.text = "Enter a password.";
        }
        if (!emptyField)
        {
            user = user.ToLower();
            Debug.Log("Still here 1\n");
            PlayerInventory pi = GameManager.instance.player.GetComponent("PlayerInventory") as PlayerInventory;
            Debug.Log("Still here 2\n");
            string inventJSON = JsonUtility.ToJson(pi.GetInventory());
            Debug.Log("Still here 3\n");
            userPackage = new TypeNamePass(type, user, pass, inventJSON);
            string message = JsonUtility.ToJson(userPackage);
            Debug.Log("Still here 4\n");
            File.WriteAllText("Passin.json", message);
            Debug.Log("Still here 5\n");
        }
    }
}
