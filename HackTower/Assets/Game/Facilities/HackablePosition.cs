using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackablePosition : MonoBehaviour
{
    public Component action;
    public GameObject HackSystem;
    public Sprite hackedSprite;
    public void Hacked(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = hackedSprite;
        action.SendMessage("HackedAction");
    }
    public void Start(){
        HackSystem=this.gameObject.transform.parent.parent.parent.gameObject;
        //HackSystem=GameObject.Find("HackSystemDirector");
        HackSystem.GetComponent<HackSystemDirector>().hackablePositionList.Add(this.gameObject);
    }

}
