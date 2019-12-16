using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreateDirector : MonoBehaviour
{
    List<GameObject> Units=new List<GameObject>();
    GameObject ChoicedUnit;
    int choicedNum=0;

    public void Start()
    {
        ChoicedUnit = Units[0];
    }

    public void ChangeUnit()
    {
        choicedNum++;
        if (choicedNum >= Units.Count) { choicedNum = 0; }
        ChoicedUnit = Units[choicedNum];
    }


}