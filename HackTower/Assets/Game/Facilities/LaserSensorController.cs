using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LaserSensorController : MonoBehaviour
{
    public void HackedAction(){        
        Debug.Log("ハッキングされました");
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.blue;
    }
    
    public void LockedAction(){        
        Debug.Log("ロックされました");
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.green;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    public void Start(){
    }


}
