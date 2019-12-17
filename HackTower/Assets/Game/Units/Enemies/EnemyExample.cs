using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExample : MonoBehaviour
{
    int selfRootIndex;
    List<Vector3Int> root;
    float defaultMoveCoolTime = 1;
    float moveCoolTime = 1;
    int rootIndex = 0;

    private void Initial(){
         root = GameObject.Find("WayTile").GetComponent<TileRootMaker>().RootList;
        this.gameObject.transform.position = root[root.Count-1];
        rootIndex = root.Count-1;
    }
    private void Move(){
         moveCoolTime -= Time.deltaTime;
        if (moveCoolTime < 0)
        {
            rootIndex--;
            if (rootIndex < 0) Destroy(gameObject);
            transform.position = root[rootIndex];
            moveCoolTime = defaultMoveCoolTime;
        }
    }
    private void Action(Collider2D arg){
        Debug.Log(this.gameObject+":"+arg.gameObject+"に接触");
    }
    

    void Start()
        {Initial();}
    void Update()
        {Move();}
    void OnTriggerEnter2D(Collider2D target)
        {Action(target);}


}
