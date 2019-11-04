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
    // Start is called before the first frame update
    void Start()
    {
        root = GameObject.Find("WayTile").GetComponent<TileRootMaker>().RootList;
        this.gameObject.transform.position = root[root.Count-1];
        rootIndex = root.Count-1;
    }
    void Update()
    {
        moveCoolTime -= Time.deltaTime;
        if (moveCoolTime < 0)
        {
            rootIndex--;
            if (rootIndex < 0) Destroy(gameObject);
            transform.position = root[rootIndex];
            moveCoolTime = defaultMoveCoolTime;
        }
    }


}
