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
            userPackage = new TypeNamePass(type, user, pass);
            string message = JsonUtility.ToJson(userPackage);
            File.WriteAllText("Passin.json", message);
        }
    }
}
