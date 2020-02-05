using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileRootMaker : MonoBehaviour
{
    public Vector3Int StartPosition;
    public static List<Vector3Int> RootList = new List<Vector3Int>();
  
    void RootMake(){
        var tm= this.gameObject.GetComponent<Tilemap>();
        if(tm.HasTile(StartPosition)==false){
            Debug.Log("startPositionにタイルが見つかりません");
        }
        else {
            RootList.Add(StartPosition);
            int n=0;
            while(true){
                if(n==RootList.Count){
                    Debug.Log("root探索終了");
                    Debug.Log("終端"+RootList[n-1]);
                    break;
                    }
                void func(Vector3Int gap){
                    if(tm.HasTile(RootList[n]+gap)){
                        if(n==0)RootList.Add(RootList[n]+gap);
                        else if(RootList[n]+gap!=RootList[n-1])RootList.Add(RootList[n]+gap);
                        }
                    }
                    func(new Vector3Int(1,0,0));
                    func(new Vector3Int(0,1,0));
                    func(new Vector3Int(-1,0,0));
                    func(new Vector3Int(0,-1,0));
                
            n++;
            }
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        RootMake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
