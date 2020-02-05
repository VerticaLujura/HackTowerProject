using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackSystemDirector : MonoBehaviour
{
    public int hackPowerLimit=100;
    public int hackPower=100;
    public GameObject HackPowerDisplayer;
    public int hackCost =30;
    public List<GameObject> hackableFacilitiesList=new List<GameObject>();
    static Vector3Int Referenceosition=new Vector3Int();
    public GameObject HackEffect;
    public int xSize=10;
    public int ySize=10;
    public int choosingX=1;
    public GameObject choosingXLine;
    public int choosingY=1;
    public GameObject choosingYLine;

    public GameObject HorizontalLineFacility;
    public GameObject VerticalLineFacility;

    public class UnlockedHorizontal{
        public GameObject HLF;
        public bool Hacked;
        public void setHacked(bool arg){
        if(arg==true){
            Hacked=true;HLF.GetComponent<SpriteRenderer>().color=Color.blue;
        }
        else{
            Hacked=false;HLF.GetComponent<SpriteRenderer>().color=Color.white;
        }
            
        }
    }
    public class UnlockedVertical{
        
        public GameObject VLF;
        public bool Hacked;
        public void setHacked(bool arg){
        if(arg==true){
            Hacked=true;VLF.GetComponent<SpriteRenderer>().color=Color.blue;
        }
        else{
            Hacked=false;VLF.GetComponent<SpriteRenderer>().color=Color.white;
        }
            
        }
    }
    UnlockedHorizontal[] unlockedHorizontals;
    UnlockedVertical[] unlockedVerticals;

    public void Initial(){
        HackPowerDisplayer=GameObject.Find("HackPowerDisplayer");
        choosingXLine= Instantiate(choosingXLine);
         choosingXLine.transform.parent=this.gameObject.transform;
         choosingXLine.transform.localPosition=new Vector3(1,0,0);
        choosingYLine= Instantiate(choosingYLine); 
         choosingYLine.transform.parent=this.transform;
         choosingYLine.transform.localPosition=new Vector3(0,1,0);
        unlockedHorizontals=new UnlockedHorizontal[ySize];
        unlockedVerticals=new UnlockedVertical[xSize];
        //Array[0]は交差点につき未割当。
        GameObject Lines=new GameObject();
        Lines.transform.parent=this.gameObject.transform;
        Lines.transform.name="Lines";

        Referenceosition=Vector3Int.CeilToInt(this.gameObject.transform.position);
        for(int i=1;i<ySize;i++){
            unlockedHorizontals[i]=new UnlockedHorizontal();
            unlockedHorizontals[i].HLF=
            Instantiate(HorizontalLineFacility,new Vector3Int(Referenceosition.x,Referenceosition.y+i,0),Quaternion.identity);
            unlockedHorizontals[i].HLF.gameObject.transform.parent=Lines.transform;
        }
        for(int j=1;j<xSize;j++){
            unlockedVerticals[j]=new UnlockedVertical();
            unlockedVerticals[j].VLF=
            Instantiate(VerticalLineFacility,new Vector3Int(Referenceosition.x+j,Referenceosition.y,0),Quaternion.identity);
            unlockedVerticals[j].VLF.transform.parent= Lines.transform;
        }    
    }

    
    void UnlockAction(int x,int y){
        Debug.Log("Unlock"+x+""+y);
        for(int i=0;i<hackableFacilitiesList.Count;i++){
            GameObject hP=hackableFacilitiesList[i];
            if(hP.transform.position.x==x &&hP.transform.position.y==y){
                hP.GetComponent<HackablePosition>().HackedSignalRepeater(true);
            }
        }
    }
    //ハックされた際に呼び出されます
    public void UnlockUpdate(){
        for(int i=0;i<hackableFacilitiesList.Count;i++){
            GameObject hP=hackableFacilitiesList[i];
                hP.GetComponent<HackablePosition>().HackedSignalRepeater(false);
        }
        for(int i=1;i<ySize;i++){
            for(int j=1;j<xSize;j++){
                if(unlockedHorizontals[i].Hacked==true && unlockedVerticals[j].Hacked==true){
                    UnlockAction((int)unlockedVerticals[j].VLF.transform.position.x,(int)unlockedHorizontals[i].HLF.transform.position.y);
                }
            }
        }
        
    }
    public void UnlockVertical(int num){
        if(unlockedVerticals[num].Hacked==false){
            if(UseHackPower(hackCost))unlockedVerticals[num].setHacked(true);
            }
        else{
            UseHackPower(-hackCost);unlockedVerticals[num].setHacked(false);
            }
        HackPowerDisplayer.GetComponent<Text>().text=hackPower.ToString();
        UnlockUpdate();
    }
    public void UnlockHorizontal(int num){
        if(unlockedHorizontals[num].Hacked==false){
            if(UseHackPower(hackCost))unlockedHorizontals[num].setHacked(true);
            }
        else {
            UseHackPower(-hackCost);unlockedHorizontals[num].setHacked(false);
            }
        HackPowerDisplayer.GetComponent<Text>().text=hackPower.ToString();
        UnlockUpdate();
    }

    void IncreaseChoosingX(int num){
        choosingX+=num;
        if(choosingX>xSize-1)choosingX=1;
        if(choosingX<1)choosingX=xSize;
        choosingXLine.transform.localPosition=new Vector3(choosingX,0,0);
    }
    void IncreaseChoosingY(int num){
        choosingY+=num;
        if(choosingY>ySize-1)choosingY=1;
        if(choosingY<1)choosingY=ySize;
        choosingYLine.transform.localPosition=new Vector3(0,choosingY,0);
    }
    bool UseHackPower(int num){
        hackPower-=num;
        if(hackPower<0){
            hackPower+=num;
            return false;
        }
        else return true; 
    }

    public void Start(){
        Initial();
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            UnlockHorizontal(choosingY);
            UnlockVertical(choosingX);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))IncreaseChoosingX(1);
        if(Input.GetKeyDown(KeyCode.LeftArrow))IncreaseChoosingX(-1);
        if(Input.GetKeyDown(KeyCode.UpArrow))IncreaseChoosingY(1);
        if(Input.GetKeyDown(KeyCode.DownArrow))IncreaseChoosingY(-1);
    }

}
