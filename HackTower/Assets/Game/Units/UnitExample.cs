using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitExample : MonoBehaviour
{
    int selfRootIndex;
    List<Vector3Int> root;
    float defaultMoveCoolTime=1;
    float moveCoolTime=1;
    int rootIndex=0;
    void Initial(){
        root=TileRootMaker.RootList;
        this.gameObject.transform.position=root[0];
    }
    void Move(){
        moveCoolTime-=Time.deltaTime;
        if(moveCoolTime<0){
            rootIndex++;
            if(rootIndex>root.Count)Destroy(gameObject);
            transform.position=root[rootIndex];
            moveCoolTime=defaultMoveCoolTime;
        }
    }

    void Start()
        {Initial();}
    void Update()
        {Move();}

   
}
