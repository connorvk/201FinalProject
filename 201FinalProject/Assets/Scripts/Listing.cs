using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Listing : MonoBehaviour {
    public Button confirm;
    public Button init;
    public Text errorTxt;
    public Text monster;
    public Text ask;
    public Sprite CHARsprite;
    public Sprite BLOBsprite;
    public Sprite LONGsprite;
    public Image listingSprite;

    public MonstertListing monsterInfo;
    public MarketPlaceManager market;

	// Use this for initialization
	void Start () {
        confirm.gameObject.SetActive(false);
        confirm.enabled = false;
        errorTxt.enabled = false;
	}

    public void initTrade()
    {
        bool hasMonster = true;
        if (hasMonster)
        {
            init.gameObject.SetActive(false);
            init.enabled = false;
            confirm.gameObject.SetActive(true);
            confirm.enabled = true;
        }
        else
        {
            init.enabled = false;
            errorTxt.enabled = true;
        }

    }


    public void confirmTrade()
    {
        confirm.enabled = false;
        errorTxt.text = "Traded";
        errorTxt.enabled = true;

        GetTrade();
    }

    public void GetTrade()
    {
        Debug.Log("Starts get");
        while (File.Exists("Passout.json"))
        {
            File.Delete("Passout.json");
        }

        //FIND ME A USERNAME HERE AS WELL.
        TradeRequest req = new TradeRequest("username", monsterInfo.Seller, monsterInfo.Monster, monsterInfo.Ask);
        string message = JsonUtility.ToJson(req);
        using (FileStream fs = File.Create("Passin.json"))
        {
            byte[] info = new UTF8Encoding(true).GetBytes(message);
            fs.Write(info, 0, info.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        StartCoroutine(ReadFile());
    }


    IEnumerator ReadFile()
    {
        Debug.Log("reading");
        //yield return new WaitUntil(() => !IsFileReady("Passin.json"));
        yield return new WaitUntil(() => IsFileReady("Passout.json"));
        string message = "";
        while (!IsFileReady("Passout.json")) { Debug.Log("waiting"); }
        while (message.Length == 0) { message = File.ReadAllText("Passout.json"); }

        if (message != null)
        {
            Debug.Log("return: " + message);
        }
        else
        {
            Debug.Log("Null return");
        }

        Debug.Log("fin");
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

    [System.Serializable]
    public class TradeRequest
    {
        public string Typename;
        public string Buyer;
        public string Seller;
        public string Monster;
        public string Ask;

        public TradeRequest(string b, string s, string m, string a)
        {
            this.Typename = "Trade";
            this.Buyer = b;
            this.Seller = s;
            this.Monster = m;
            this.Ask = a;
        }
    }
    

	// Update is called once per frame
	void Update () {
		
	}
}
