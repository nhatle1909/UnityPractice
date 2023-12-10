using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class DisplayMessageScript : MonoBehaviour
    {
   
        private SpriteRenderer[] messages;

        public Canvas canvasElement;
   
        // Start is called before the first frame update
        void Start()
        {
            messages = GetComponentsInChildren<SpriteRenderer>();    
        }

        // Update is called once per frame
       
        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                foreach (SpriteRenderer message in messages)
                {
                    message.enabled = true;
                }        
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            foreach (SpriteRenderer message in messages)
            {
                message.enabled = false;
            }
        }
    }
}
