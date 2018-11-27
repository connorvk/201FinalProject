using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarketPlaceManager : MonoBehaviour {

    public GameObject listingPrefab;
    public GameManager manager;
    public GameObject canvas;
    public Button back;

    // Use this for initialization
    void Start () {
        //grab stuff from marketplace json immediately.
        GetMarketplace();
        manager = FindObjectOfType<GameManager>();
	}

    public void returnMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void addTrade()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
    }

    public void GetMarketplace()
    {
        Debug.Log("Starts get");
        while (File.Exists("Passout.json"))
        {
            File.Delete("Passout.json");
        }

        MarketRequest req = new MarketRequest();
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
            message = "{\"MonsterListing\":" + message + "}";
            Debug.Log("return: " + message);

            Market market = JsonUtility.FromJson<Market>(message);
            while (File.Exists("Passout.json"))
            {
                File.Delete("Passout.json");
            }

            createListings(market);

        }
        else
        {
            Debug.Log("Null return");
        }

        //[{"MonsterID":1,"Monster":"BLOB","Ask":"Long","HP":100,"Seller":"vincent","Attack":20},
        //{ "MonsterID":2,"Monster":"Long","Ask":"BLOB","HP":5,"Seller":"baiyu","Attack":1},
        //{ "MonsterID":3,"Monster":"Char_Star","Ask":"BLOB","HP":5,"Seller":"connor","Attack":1}]

        

        Debug.Log("fin");
    }

    void createListings(Market m)
    {
        int i = 0;
        int x = -774;
        int y = 245;
        foreach(MonstertListing curr in m.MonsterListing){
            if(curr.Seller != manager.player.name)
            {
                GameObject newListing = (GameObject)Instantiate(listingPrefab, new Vector3(x, y, 0), Quaternion.identity);
                newListing.transform.SetParent(canvas.transform);
                newListing.transform.localPosition = new Vector3(x, y, 0);
                newListing.transform.localScale = new Vector3(1, 1, 1);
                newListing.GetComponent<Listing>().market = this;
                newListing.GetComponent<Listing>().monsterInfo = curr;
                newListing.GetComponent<Listing>().ask.text = curr.Ask;
                newListing.GetComponent<Listing>().monster.text = curr.Monster;
                
                if(curr.Monster == "Char_Star")
                    newListing.GetComponent<Listing>().listingSprite.sprite = newListing.GetComponent<Listing>().CHARsprite;
                else if(curr.Monster == "BLOB")
                    newListing.GetComponent<Listing>().listingSprite.sprite = newListing.GetComponent<Listing>().BLOBsprite;
                else if(curr.Monster == "Long")
                    newListing.GetComponent<Listing>().listingSprite.sprite = newListing.GetComponent<Listing>().LONGsprite;

                x += 500;
                if(i%4 == 3)
                {
                    y += 437;
                    x = -774;
                }
                i++;

            }
        }

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

}

[System.Serializable]
public class MarketRequest
{
    public string Typename;

    public MarketRequest()
    {
        this.Typename = "LoadMarket";
    }
}

[System.Serializable]
public class Market
{
    public MonstertListing[] MonsterListing;
} 

[System.Serializable]
public class MonstertListing
{
    public string MonsterID;
    public string Monster;
    public string Ask;
    public string HP;
    public string Seller;
    public string Attack;

}