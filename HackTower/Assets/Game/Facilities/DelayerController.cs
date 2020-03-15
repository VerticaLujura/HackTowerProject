using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayerController : MonoBehaviour
{
    public bool Hacked=false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(Hacked==false)collision.GetComponent<MoveOnRoot>().multiplyMoveCoolTime(1.5f,2.0f);
    }
    
    public void HackedAction(){
        Hacked=true;
    }
    public void LockedAction(){
        Hacked=false;
    }
}
