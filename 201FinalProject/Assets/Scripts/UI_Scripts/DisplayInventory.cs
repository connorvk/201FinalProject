using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Use this for initialization
    void Start ()
    {
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
        }
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
