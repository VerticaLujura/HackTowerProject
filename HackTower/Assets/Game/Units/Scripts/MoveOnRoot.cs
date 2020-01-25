using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnRoot : MonoBehaviour
{
    public enum Direction{back=-1,stop=0,forward=1}
    public Direction direction=Direction.forward;
    public int indexOnRoot;
    public float moveCoolTime=1; 
    float deltaTime;
    List<Vector3Int> Root;

    
    void Move(){
        deltaTime+=Time.deltaTime;
        if(deltaTime>moveCoolTime){
        indexOnRoot+=(int)direction;
        this.transform.position=(Root[indexOnRoot]);
        deltaTime=0;
        }
    }

    void Start(){
        Root=TileRootMaker.RootList;
        if(direction==Direction.back)indexOnRoot=Root.Count-1;
        if(direction==Direction.forward)indexOnRoot=0;
        this.transform.position=(Root[indexOnRoot]);
    }

    public virtual void UpdateFunc(){
        //仮想メソッド
    }

    public void Update(){
        Move();
        UpdateFunc();
    }

}
