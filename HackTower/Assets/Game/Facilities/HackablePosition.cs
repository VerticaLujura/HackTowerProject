using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackablePosition : MonoBehaviour
{
    public Component action;
    public GameObject HackSystem;
    public Sprite hackedSprite;
    Sprite noSprite;
    public void HackedSignalRepeater(bool unlock){
        if(unlock==true){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = hackedSprite;
        action.SendMessage("HackedAction");
        }
        else{
        this.gameObject.GetComponent<SpriteRenderer>().sprite = noSprite;
        action.SendMessage("LockedAction");
        }
    }
    public void Start(){
        HackSystem=this.gameObject.transform.parent.parent.parent.gameObject;
        //HackSystem=GameObject.Find("HackSystemDirector");
        HackSystem.GetComponent<HackSystemDirector>().hackableFacilitiesList.Add(this.gameObject);
    }

}
