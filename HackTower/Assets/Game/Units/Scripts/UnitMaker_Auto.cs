using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaker_Auto : MonoBehaviour
{
    public GameObject Unit;
    private float deltaTime=1.0f;
    public float coolTime;
    private void MakeUnit(){
            deltaTime+=Time.deltaTime;
            if(deltaTime>coolTime){
                Instantiate(Unit,Vector3Int.zero,Quaternion.identity,this.transform);
                deltaTime=0;
            }
            }
    void Awake(){
    }
    void Update(){
        MakeUnit();
    }
}
