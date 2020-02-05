using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaker : MonoBehaviour
{
    public GameObject Unit;
    public KeyCode Key; 

    void Start(){
        if(Key==KeyCode.None){
            Debug.Log("keyが不正");
        }
    }
    void Update(){
        if(Input.GetKeyDown(Key)){
            Instantiate(Unit);
        }
    }
}
