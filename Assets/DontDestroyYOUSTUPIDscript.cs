using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyYOUSTUPIDscript : MonoBehaviour
{
    private CinemachineConfiner2D confiner2D;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
