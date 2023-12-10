
using Assets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

namespace Assets {
    public class MovementController : MonoBehaviour
    {
        public float horizontal;

        public Rigidbody2D rb;

        private Animator animator;

        private float xScale;

        public static MovementController instance;
        private void Start()
        {
            instance = this;
 
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            xScale = transform.localScale.x;
        }


        public void Movement()
        {
            rb.velocity = new Vector2(horizontal * CharacterManager.instance.Speed, rb.velocity.y);
            
            // Velocity Y < 0 -> Play Fall Animation , esle Disable Fall Animation
            animator.SetBool(AnimationStringManager.Fall, rb.velocity.y < 0f);

            // Speed = 2.5F->Play Crouching animation, else disable
            animator.SetBool(AnimationStringManager.Crouch, CharacterManager.instance.Speed == 2.5f);

            // Velocity X != 0f ( Moving ) and is being Grounded ( not Jump ) => Play Running Animation
            animator.SetBool(AnimationStringManager.Running, horizontal != 0f && MovementService.Instance.isGrounded(transform) == true); 

            MovementService.Instance.isFlip(rb, transform, xScale);
        }
    }




}

//    if (rb.velocity.y >= 0f) // Velocity Y >= 0 -> Play Fall Animation , < 0 , Disable Fall Animation
//    {
//        animator.SetBool(AnimationStringManager.Fall, false);
//    }
//    else
//{
//    animator.SetBool(AnimationStringManager.Fall, true);
//}

//if (CharacterStats.instance.Speed == 2.5f) // Speed = 2.5F -> Play Crouching animation, else disable
//{
//    animator.SetBool(AnimationStringManager.Crouch, true);

//}
//else
//{
//    animator.SetBool(AnimationStringManager.Crouch, false);
//}

//if (horizontal != 0f && GameService.Instance.isGrounded(transform) == true) // Velocity X != 0f ( Moving ) and is being Grounded ( not Jump )
//{
//    animator.SetBool(AnimationStringManager.Running, true);
//}
//else
//{
//    animator.SetBool(AnimationStringManager.Running, false);
//}