using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;

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
            UserInfo.SignedInUser = user;

            Debug.Log(PlayerInventory.Inventory.InventoryList[0]);

            string inventJSON = JsonUtility.ToJson(PlayerInventory.Inventory);
            userPackage = new TypeNamePass(type, user, pass, inventJSON);

            Debug.Log("Inventory: " + userPackage.Userinventory);

            PlayerInventory.Inventory = JsonUtility.FromJson<ListWrapper>(userPackage.Userinventory);

            Debug.Log(PlayerInventory.Inventory.InventoryList[0]);

            string message = JsonUtility.ToJson(userPackage);
            //File.WriteAllText("Passin.json", message);
            using (FileStream fs = File.Create("Passin.json"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(message);
                fs.Write(info, 0, info.Length);
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
