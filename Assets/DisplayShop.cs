using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShop : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isInteract;
    public Canvas canvasElement;
    private void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isInteract == true) canvasElement.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInteract = false;
        canvasElement.enabled = false;
    }
}
