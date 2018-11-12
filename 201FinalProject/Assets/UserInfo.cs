using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserInfo : MonoBehaviour {
    public static bool SignedIn; //the flag that determines if content is locked or not
}

//need a wrapper class for variables you want in the json file
[System.Serializable]
public class TypeNamePass
{
	public string Typename, Username, Password;

	public TypeNamePass()
	{
        this.Typename = "";
		this.Username = "";
		this.Password = "";
	}

	public TypeNamePass(string typename, string username, string password)
	{
        this.Typename = typename;
		this.Username = username;
		this.Password = password;
	}
}

[System.Serializable]
public class UserResults
{
    public string Comment;
    public bool Result;

    public UserResults()
    {
        this.Comment = "";
        this.Result = false;
    }

    public UserResults(string comment, bool result)
    {
        this.Comment = comment;
        this.Result = result;
    }
}