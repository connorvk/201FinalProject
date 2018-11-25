using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MarketPlace : MonoBehaviour {
    public Text ErrorUser;
    public Text ErrorPass;
    public Text ErrorResults;
    public TypeNamePass userPackage;

    public GameObject listingPrefab;

    // Use this for initialization
    void Start () {
        //grab stuff from marketplace json immediately.
        GetMarketplace();
	}

    public void GetMarketplace()
    {

    }

    public bool IsFileReady(string filename)
    {
        if (!File.Exists(filename))
        {
            return false;
        }
        // If the file can be opened for exclusive access it means that the file
        // is no longer locked by another process.
        try
        {
            using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                return inputStream.Length > 0;
        }
        catch (IOException ioe)
        {
            Debug.Log(ioe.Message);
        }
        return false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
