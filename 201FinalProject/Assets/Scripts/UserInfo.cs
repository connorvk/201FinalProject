using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NameAndPass user = new NameAndPass("Test Name", "Test Password");
		string message = JsonUtility.ToJson(user);
		File.WriteAllText("message.json", message);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

//need a wrapper class for variables you want in the json file
[System.Serializable]
public class NameAndPass
{
	public string username, password;

	public NameAndPass()
	{
		this.username = "";
		this.password = "";
	}

	public NameAndPass(string username, string password)
	{
		this.username = username;
		this.password = password;
	}
}