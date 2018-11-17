using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadUserInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//need a coroutine to make it wait, I think
		StartCoroutine(ReadFile());
	}

	// Update is called once per frame
	void Update () {
		
	}

	//I don't entirely understand this but it seems to put this script in a waiting state until the json exists
	IEnumerator ReadFile()
	{
		yield return new WaitUntil(() => File.Exists("message.json"));
		string message = File.ReadAllText("message.json");
		if (message != null)
		{
			NameAndPass user = JsonUtility.FromJson<NameAndPass>(message);
			print(user.username + "\n" + user.password);
		}
	}
}