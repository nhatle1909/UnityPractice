using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class SignRoadScript : MonoBehaviour
    {
        private BoxCollider2D signroad;
        private BoxCollider2D rb;
        private SpriteRenderer srmessage;
        // Start is called before the first frame update
        void Start()
        {
            rb = GameObject.Find("Player").GetComponent<BoxCollider2D>();
            srmessage = GameObject.Find("SignRoadMessage").GetComponent<SpriteRenderer>();
            signroad = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerStay2D(Collider2D other)
        {
            srmessage.enabled = true;

        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            srmessage.enabled = false;
        }
    }
}
