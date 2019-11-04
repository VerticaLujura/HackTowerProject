using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitChange : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    public Sprite [] SpriteBox = new Sprite[3];
    int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = GameObject.Find("UnitExample").gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void OnClick()
    {
        Change();
        // SpriteRenderのspriteを設定済みの他のspriteに変更
    }
    public void Change()
    {
        MainSpriteRenderer.sprite = SpriteBox[i];
        i++;
        if (i == 3) i = 0;
    }

}

