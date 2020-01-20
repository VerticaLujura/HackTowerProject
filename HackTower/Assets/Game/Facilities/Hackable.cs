using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackable : MonoBehaviour
{
    public Component a;
    public void Hack(){
        a.SendMessage("HackedAction");
    }
}
