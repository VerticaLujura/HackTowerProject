using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiribiriController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    
    public void HackedAction(){
        Destroy(this.gameObject);
    }

}
