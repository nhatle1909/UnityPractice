using UnityEngine;

namespace Assets
{
    public class MovementService 
    {
        private static MovementService _instance;
        private MovementService()
        {
        }

        public static MovementService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MovementService();
                }
                return _instance;
            }
        }

        public void isFlip(Rigidbody2D rb, Transform transform,float TransformXScale)
        { 
            if (rb.velocity.x > 0f)
           {
                transform.localScale = new Vector3(TransformXScale, transform.localScale.y, transform.localScale.z);
           }
           if (rb.velocity.x < 0f)
           {
                transform.localScale = new Vector3(-TransformXScale, transform.localScale.y, transform.localScale.z);
           }
        }

        public bool isGrounded(Transform transform)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, 1);
            if (hit.collider != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
