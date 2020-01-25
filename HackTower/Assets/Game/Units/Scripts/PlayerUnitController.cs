using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitController : MoveOnRoot
{   
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Enemy"){
            this.gameObject.GetComponent<Unit>().UnitBattle(collision.gameObject.GetComponent<Unit>());
            }
    }
}