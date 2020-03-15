using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonArea : MonoBehaviour
{
    public bool Hacked=false;
    public GameObject ComponentManager;

    void Initialization(){
    }
    void HackedAction(){
        Hacked=true;
    }

    void Awake(){Initialization();}

    public void OnTriggerEnter2D(Collider2D collision){
            Debug.Log("大空魔術");
            collision.gameObject.AddComponent<PoisonComponent>();
            
    }
    


    
}
