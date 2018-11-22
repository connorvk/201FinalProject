using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserInfo : MonoBehaviour {
    volatile public static bool SignedIn; //the flag that determines if content is locked or not
    volatile public static string SignedInUser;
    volatile public static bool SaveResult;
}

//need a wrapper class for variables you want in the json file
[System.Serializable]
public class TypeNamePass
{
	public string Typename, Username, Password, Userinventory;

    public TypeNamePass()
	{
        this.Typename = "";
		this.Username = "";
		this.Password = "";
        this.Userinventory = "";
    }

	public TypeNamePass(string typename, string username, string password, string inventoryJSON)
	{
        this.Typename = typename;
		this.Username = username;
		this.Password = password;
        this.Userinventory = inventoryJSON;
    }
}

[System.Serializable]
public class UserResults
{
    public string Comment, Userinventory;
    public bool Result;

    public UserResults()
    {
        this.Comment = "";
        this.Userinventory = "";
        this.Result = false;
    }

    public UserResults(string comment, string inventoryJSON, bool result)
    {
        this.Comment = comment;
        this.Userinventory = inventoryJSON;
        this.Result = result;
    }
}