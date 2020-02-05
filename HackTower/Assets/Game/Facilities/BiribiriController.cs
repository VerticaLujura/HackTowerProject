using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiribiriController : MonoBehaviour
{
    public bool Hacked=false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(Hacked==false)Destroy(collision.gameObject);
    }
    
    public void HackedAction(){
        Hacked=true;
    }
    public void LockedAction(){
        Hacked=false;
    }

}
