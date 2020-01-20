using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackSystemDirector : MonoBehaviour
{
    public GameObject Facilities;
    
    static Vector3Int Referenceosition=new Vector3Int();
    public int xSize=10;
    public int ySize=10;
    public bool[] unlockedHorizontalArray;
    public bool[] unlockedVerticalArray;
    public GameObject[] HorizontalLineFacilityArray;
    public GameObject[] VerticalLineFacilityArray;
    public GameObject HorizontalLineFacility;
    public GameObject VerticalLineFacility;

    public struct unlockedHorizontal{
        public GameObject HLF;
        public bool Hacked;
    }
    public struct unlockedVertical{
        public GameObject VLF;
        public bool Hacked;
    }
    unlockedHorizontal[] unlockedHorizontals;
    unlockedVertical[] unlockedVerticals;

    public void Initial(){
        
        unlockedHorizontals=new unlockedHorizontal[ySize];
        unlockedVerticals=new unlockedVertical[xSize];
        //Array[0]は交差点につき未割当。

        Referenceosition=Vector3Int.CeilToInt(this.gameObject.transform.position);
        for(int i=1;i<ySize;i++){
            unlockedHorizontals[i].HLF=
            Instantiate(HorizontalLineFacility,new Vector3Int(Referenceosition.x,Referenceosition.y+i,0),Quaternion.identity);
            unlockedHorizontals[i].HLF.gameObject.transform.parent=this.transform;
        }
        for(int j=1;j<xSize;j++){
            unlockedVerticals[j].VLF=
            Instantiate(VerticalLineFacility,new Vector3Int(Referenceosition.x+j,Referenceosition.y,0),Quaternion.identity);
            unlockedVerticals[j].VLF.transform.parent= this.transform;
        }    
    }

    
    void UnlockAction(int x,int y){
        Debug.Log("aa"+x+""+y);
        Instantiate(HorizontalLineFacility,new Vector3(x,y,0),Quaternion.identity);
        for(int i=0;i<Facilities.transform.childCount;i++){
            Transform fc=Facilities.transform.GetChild(i);
            if(fc.position.x==x &&fc.position.y==y){
                 fc.gameObject.GetComponent<Hackable>().Hack();}
        }
    }
    //ハックされた際に呼び出されます
    public void UnlockUpdate(){
        for(int i=1;i<ySize;i++){
            for(int j=1;j<xSize;j++){
                if(unlockedHorizontals[i].Hacked==true && unlockedVerticals[j].Hacked==true){
                    UnlockAction((int)unlockedVerticals[j].VLF.transform.position.x,(int)unlockedHorizontals[i].HLF.transform.position.y);
                }
            }
        }
    }
    public void UnlockVertical(int num){
        unlockedVerticals[num].Hacked=true;
        UnlockUpdate();
    }
    public void UnlockHorizontal(int num){
        unlockedHorizontals[num].Hacked=true;
        UnlockUpdate();
    }

    public void Start(){
        Initial();
    }
    public void Updata(){
        if(Input.GetMouseButtonDown(0)){
            UnlockHorizontal(3);
            UnlockVertical(6);
        }
    }

}
