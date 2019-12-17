using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public class UnitStatus{
    int cost;
    int hp;
    int attackPow;
    int hackPow;
    float speed;
    }
    int selfRootIndex;
    List<Vector3Int> root;
    float defaultMoveCoolTime=1;
    float moveCoolTime=1;
    int rootIndex=0;
    void Move(){
        moveCoolTime-=Time.deltaTime;
        if(moveCoolTime<0){
            rootIndex++;
            if(rootIndex>root.Count)Destroy(this.gameObject);
            transform.position=root[rootIndex];
            moveCoolTime=defaultMoveCoolTime;
        }
    
    }
   
    
    
    
    void Initial(){
        root=TileRootMaker.RootList;
        this.gameObject.transform.position=root[0];
    }

    

    void Start()
        {Initial();}
    void Update()
        {Move();}
}
