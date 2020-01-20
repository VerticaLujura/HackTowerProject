using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackablePosition : MonoBehaviour
{
    public Component action;
    public GameObject HackSystem;
    public void Hacked(){
        action.SendMessage("HackedAction");
    }
    public void Awake(){
        HackSystem.GetComponent<HackSystemDirector>().hackablePositionList.Add(this.gameObject);
    }

}
