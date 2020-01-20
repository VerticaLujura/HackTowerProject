using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackSystemDirector : MonoBehaviour
{
    public List<GameObject> hackablePositionList=new List<GameObject>();
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
        GameObject Lines=new GameObject();
        Lines.transform.parent=this.gameObject.transform;
        Lines.transform.name="Lines";

        Referenceosition=Vector3Int.CeilToInt(this.gameObject.transform.position);
        for(int i=1;i<ySize;i++){
            unlockedHorizontals[i].HLF=
            Instantiate(HorizontalLineFacility,new Vector3Int(Referenceosition.x,Referenceosition.y+i,0),Quaternion.identity);
            unlockedHorizontals[i].HLF.gameObject.transform.parent=Lines.transform;
        }
        for(int j=1;j<xSize;j++){
            unlockedVerticals[j].VLF=
            Instantiate(VerticalLineFacility,new Vector3Int(Referenceosition.x+j,Referenceosition.y,0),Quaternion.identity);
            unlockedVerticals[j].VLF.transform.parent= Lines.transform;
        }    
    }

    
    void UnlockAction(int x,int y){
        Debug.Log("Unlock"+x+""+y);
        Instantiate(HorizontalLineFacility,new Vector3(x,y,0),Quaternion.identity);
        for(int i=0;i<hackablePositionList.Count;i++){
            GameObject hP=hackablePositionList[i];
            if(hP.transform.position.x==x &&hP.transform.position.y==y){
                hP.GetComponent<HackablePosition>().Hacked();
            }
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
    public void Update(){
        if(Input.GetMouseButtonDown(0)){
            UnlockHorizontal(6);
            UnlockVertical(6);
        }
    }

}
