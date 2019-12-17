﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonController : MonoBehaviour
{
SpriteRenderer MainSpriteRenderer;
    public Sprite [] SpriteBox = new Sprite[3];
    int i = 1;
    void Start()
    {
        MainSpriteRenderer = GameObject.Find("UnitExample").gameObject.GetComponent<SpriteRenderer>();
    }

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