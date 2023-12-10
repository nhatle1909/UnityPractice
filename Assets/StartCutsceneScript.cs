using Assets;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutsceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineBrain cmBrain;
   
    void Start()
    {
        cmBrain = GetComponent<CinemachineBrain>();
        CharacterManager.instance.enabled = false;     
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1.5f*Time.fixedDeltaTime,0f,0f);
        if (transform.position.x > 9f) 
        {
            
            cmBrain.enabled = true;

            CharacterManager.instance.enabled = true;
            this.enabled = false;
            
        }
    }
}
