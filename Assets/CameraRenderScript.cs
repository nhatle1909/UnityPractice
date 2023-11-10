using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRenderScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnBecameVisible()
    {
        gameObject.SetActive(true);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
