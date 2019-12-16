using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiribiriController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
