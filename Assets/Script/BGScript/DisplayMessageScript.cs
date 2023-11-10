using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class DisplayMessageScript : MonoBehaviour
    {
        private BoxCollider2D detectionZone;
        private SpriteRenderer[] messages;
        // Start is called before the first frame update
        void Start()
        {
            messages = GetComponentsInChildren<SpriteRenderer>();
            detectionZone = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerStay2D(Collider2D other)
        {
            foreach (SpriteRenderer message in messages)
            {
                message.enabled = true;
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
