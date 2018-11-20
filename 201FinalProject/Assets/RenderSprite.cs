using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSprite : MonoBehaviour
{
    public void LoadMonsterSprite(int type)
    {
        spriteR.sprite = sprites[type];
    }

    public enum Type
    {
        BLOB,
        Long,
        Char_Star
    }
    public Type type;
    private SpriteRenderer spriteR;
    private Sprite[] sprites;
    void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("EnemySprites");
        if(type == Type.BLOB)
            LoadMonsterSprite(1);
        else if (type == Type.Char_Star)
            LoadMonsterSprite(567);
        else if (type == Type.Long)
            LoadMonsterSprite(232);
    }
}
