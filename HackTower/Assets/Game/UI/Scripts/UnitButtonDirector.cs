using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitButtonDirector : MonoBehaviour
{
    public List<GameObject> Units=new List<GameObject>();
    GameObject ChosenUnit;
    int unitsIndex = 0;
    public GameObject UnitDisplayer;
    void UnitDisplay(){
        UnitDisplayer.GetComponent<Image>().sprite=ChosenUnit.GetComponent<SpriteRenderer>().sprite;
    }
    void Initial(){
        ChosenUnit=Units[unitsIndex];
        UnitDisplay();
    }
    
    public void UnitChange()
    {
        if(Units.Count==0)Debug.Log("UnitListが空です");
        unitsIndex+=1;
        if(Units.Count<=unitsIndex)unitsIndex=0;
        ChosenUnit = Units[unitsIndex];
        UnitDisplay();
        Debug.Log("現在の選択ユニットは"+ChosenUnit);
    }
    public void UnitCreate(){
        Instantiate(ChosenUnit);
    }

    void Start()
        {Initial();}
    public void OnClickChange()
        {UnitChange();}
    public void OnClickCreate()
        {UnitCreate();}
    
}
