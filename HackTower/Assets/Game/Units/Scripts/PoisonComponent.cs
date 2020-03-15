using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonComponent : MonoBehaviour
{
    public int poisonDamage=1;
    public float damageSpan=1;
    float ds;
    public float effectTime=10.0f;
    float et;

    public PoisonComponent(){}
    public PoisonComponent(int damage,int span,int time){
        poisonDamage=damage;
        damageSpan=span;
        effectTime=time;
    }
    void Start(){
        Debug.Log("毒生成");
        ds=damageSpan;
        et=effectTime;
    }
    void Update()
    {
        ds-=Time.deltaTime;
        et-=Time.deltaTime;
        if(ds<0){
        gameObject.GetComponent<Unit>().IncreseParameter(ParameterName.hp,-poisonDamage);
        ds=damageSpan;
        }
        if(et<0){
            Debug.Log("時間経過により毒消滅");Destroy(this);
        }
    }
}
