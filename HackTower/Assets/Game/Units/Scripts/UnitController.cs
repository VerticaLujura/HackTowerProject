using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{   
    public int cost;
    public int hp;
    public int attackPow;
    public int hackPow;
    public float speed=0.02f;
    float deltaSpeed;
    List<Vector3Int> root;
     
    
    void Initial(){
        root=TileRootMaker.RootList;
        this.gameObject.transform.position=root[0];
    }
    void Move(){
        deltaSpeed+=speed;
        transform.position= root[(int)deltaSpeed];
    }

    

    void Start()
        {Initial();}
    void Update()
        {Move();}
}
