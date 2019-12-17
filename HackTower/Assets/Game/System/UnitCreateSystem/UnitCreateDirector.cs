using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreateDirector : MonoBehaviour
{
    public List<GameObject> Units=new List<GameObject>();
    public GameObject ChoicedUnit;
    int choicedNum=0;

    public void ChangeUnit(int arg)
    {
        choicedNum+=arg;
        if(choicedNum<0){choicedNum=0;}
        if (choicedNum >= Units.Count) { choicedNum = 0; }
        ChoicedUnit = Units[choicedNum];
    }
    void CreateUnit(){
        Instantiate(Units[choicedNum]);
    }

    public void Start()
    {
        ChoicedUnit = Units[0];
    }
}