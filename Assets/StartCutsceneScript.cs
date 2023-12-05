using Assets;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutsceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineBrain cmBrain;
    public Vector2 startPos = new Vector2 (8.875325f,0f);
    public CharacterMovement cm;
    void Start()
    {
        cmBrain = GetComponent<CinemachineBrain>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1f*Time.fixedDeltaTime,0f,0f);
        if (transform.position.x > 9f) 
        {
            
            cmBrain.enabled = true;
            cm.enabled = true;
            this.enabled = false;
            
        }
    }
}
