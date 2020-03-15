using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ParameterName{cost,hp,attackPow,hackPow}

public class Unit : MonoBehaviour
{
    public int cost=1;
    public int hp=1;
    public int attackPow=1;
    public int hackPow=1;

    public void hpCheck(){
        if(hp<=0)Destroy(this.gameObject);
    }
    
    public void IncreseParameter(ParameterName parameterName,int num){
        if(parameterName==ParameterName.cost)cost+=num;
        if(parameterName==ParameterName.hp)hp+=num;
        if(parameterName==ParameterName.attackPow)attackPow+=num;
        if(parameterName==ParameterName.hackPow)hackPow+=num;

        if(hp<=0){Debug.Log("体力切れで消滅");Destroy(this.gameObject);}
    }
    public int GetParameter(ParameterName parameterName){
        if(parameterName==ParameterName.cost)return cost;
        if(parameterName==ParameterName.hp)return hp;
        if(parameterName==ParameterName.attackPow)return attackPow;
        if(parameterName==ParameterName.hackPow)return hackPow;
        else{Debug.Log("ReturnError");return 0;};
    }

    public void UnitBattle(Unit targetUnit){
        IncreseParameter(ParameterName.hp,-targetUnit.attackPow);
        targetUnit.IncreseParameter(ParameterName.hp,-this.attackPow);
        this.hpCheck();
        targetUnit.hpCheck();
        }
        

}
