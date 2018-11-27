using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour {

    public Image m_Image;
    public Sprite m_SpriteExit;
    public Sprite m_blob;
    public Sprite m_long;
    public Sprite m_char_star;
    public int index;
    private monsterScript.Type monster;
    public Text mon_name;
    public Text mon_mov1;
    public Text mon_mov2;

    public Button trade;
    bool fromMarket = false;

    public GameObject choosePanel;
    string ask = "";
    public Button confirm;
    public Text chooseTxt;
    public Text tradeTxt;

    GameManager manager;


    // Use this for initialization
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        confirm.enabled = false;
        chooseTxt.text = "Which do you want?";
        ask = "";
        trade.gameObject.SetActive(false);
        trade.enabled = false;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(6));
        if (SceneManager.GetSceneByBuildIndex(5).isLoaded)
            fromMarket = true;

        if (index < PlayerInventory.Inventory.InventoryList.Count)
        {
            monster = PlayerInventory.Inventory.InventoryList[index];
            if (monster == monsterScript.Type.BLOB)
            {
                mon_name.text = "BLOB";
                mon_mov1.text = "Goo Throw";
                mon_mov2.text = "Toxic";
            }
            else if (monster == monsterScript.Type.Long)
            {
                mon_name.text = "Long";
                mon_mov1.text = "Bind";
                mon_mov2.text = "Bite";
            }
            else if (monster == monsterScript.Type.Char_Star)
            {
                mon_name.text = "Char_Star";
                mon_mov1.text = "Throwing Star";
                mon_mov2.text = "Charring";
            }

            if (fromMarket)
            {
                trade.gameObject.SetActive(true);
                trade.enabled = true;
            }

        }
    }

    public void addToMarket()
    {
        choosePanel.SetActive(true);
    }

    public void revertChoose()
    {
        choosePanel.SetActive(false);
        confirm.enabled = false;
        ask = "";
        chooseTxt.text = "Which do you want?";

    }

    public void confirmChoose()
    {
        Debug.Log("Confirmed trade"); Debug.Log("Starts get");
        while (File.Exists("Passout.json"))
        {
            File.Delete("Passout.json");
        }

        //GIMEM A USERNAME HERE!!!!
        //Also where do I find the mosnter hp?? (replace 100)
        SellRequest req = new SellRequest(UserInfo.SignedInUser, mon_name.text, ask, 100);
        string message = JsonUtility.ToJson(req);
        Debug.Log(message);
        using (FileStream fs = File.Create("Passin.json"))
        {
            byte[] info = new UTF8Encoding(true).GetBytes(message);
            fs.Write(info, 0, info.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        confirm.enabled = false;
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

            choosePanel.SetActive(false);
            trade.enabled = false;
            tradeTxt.text = "traded";

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


    public void setAsk(int i)
    {
        if (i == 0)
        {
            ask = "BLOB";
        }
        else if (i == 1)
        {
            ask = "Long";
        }
        else if (i == 2)
        {
            ask = "Char_Star";
        }

        Debug.Log("asked for " + ask);


        chooseTxt.text = "Click to confirm trade.";
        confirm.enabled = true;
    }

    void OnMouseOver()
    {
        if (index < PlayerInventory.Inventory.InventoryList.Count)
        {
            if (monster == monsterScript.Type.BLOB)
            {
                m_Image.sprite = m_blob;
            }
            else if (monster == monsterScript.Type.Long)
            {
                m_Image.sprite = m_long;
            }
            else if (monster == monsterScript.Type.Char_Star)
            {
                m_Image.sprite = m_char_star;
            }
        }
    }

    void OnMouseExit()
    {
        m_Image.sprite = m_SpriteExit;
    }
}

[System.Serializable]
public class SellRequest
{
        //Sell { "Typename": "Sell", "Username": "Vincent", "Monstername": "pig", "Ask": "cat", "HP": 100, "Attack": 10 }
        public string Typename;
    public string Username;
    public string Monstername;
    public string Ask;
    public string HP;
    public string Attack;
        
    public SellRequest(string u, string m, string a, int hp )
    {
        this.Typename = "Sell";
        this.Username = u;
        this.Monstername = m;
        this.Ask = a;
        this.HP = hp.ToString();
        this.Attack = "20";
    }

}
