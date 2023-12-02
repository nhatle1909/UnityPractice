
using UnityEngine;
using UnityEngine.Animations;

namespace Assets {
    public class CharacterMovement : MonoBehaviour
    {
        public float horizontal;

        public Rigidbody2D rb;

        private Animator animator;

        private float xScale;

        private CharacterStats charStats;


        private void Start()
        {
            charStats = GetComponent<CharacterStats>();  
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            xScale = transform.localScale.x;
        }


        private void FixedUpdate()
        {
           

            rb.velocity = new Vector2(horizontal * charStats.Speed, rb.velocity.y);

            if (rb.velocity.y >= 0f) // Velocity Y >= 0 -> Play Fall Animation , < 0 , Disable Fall Animation
            {
                animator.SetBool(AnimationStringManager.Fall, false);
            }
            else 
            {
                animator.SetBool(AnimationStringManager.Fall, true);
            }
    

            if (horizontal != 0f && GameService.Instance.isGrounded(transform) == true) // Velocity X != 0f ( Moving ) and is being Grounded ( not Jump )
            {
                animator.SetBool(AnimationStringManager.Running, true);            
            }
            else
            {
                animator.SetBool(AnimationStringManager.Running, false);
            }

            if (charStats.Speed == 2.5f) // Speed = 2.5F -> Play Crouching animation, else disable
            {
                animator.SetBool(AnimationStringManager.Crouch, true);
               
            }
            else
            {
                animator.SetBool(AnimationStringManager.Crouch, false);
            }

            GameService.Instance.isFlip(rb, transform, xScale);

        }
    }








    //void Idle()
    //{

    //}

    //    void Fall()
    //    {
    //        animator.SetBool("isFall", true);
    //        if (MiscControllers.Instance.isGrounded(transform) == true)
    //        {
    //            Debug.Log("TEST");
    //            animator.SetBool(AnimationStringManager.Fall, false);
    //            currentState = State.Idle;
    //        }
    //    }

    //    void Jump()
    //    {

    //        animator.SetBool(AnimationStringManager.Jump, true);       
    //        if (rb.velocity.y < 0f)
    //        {
    //            animator.SetBool(AnimationStringManager.Jump, false);
    //            currentState = State.Falling;
    //        }
    //    }
    //    void Walking()
    //    {
    //        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    //        if (horizontal != 0f && animator.GetBool(AnimationStringManager.Jump) == false)
    //        {
    //            animator.SetBool(AnimationStringManager.Running, true);
    //        }
    //        else 
    //        {
    //            animator.SetBool(AnimationStringManager.Running, false);
    //            currentState = State.Idle;
    //        }
    //        if (speed == 2.5f)
    //        {
    //            currentState = State.Crouching;
    //        }
    //    }
    //    void Crouching()
    //    {
    //        if (speed == 2.5f)
    //        {
    //            animator.SetBool(AnimationStringManager.Crouch, true);
    //        }

    //        if (speed == 5f)
    //        {
    //            animator.SetBool(AnimationStringManager.Crouch, false);
    //            currentState = State.Walking;
    //        }
    //    }

    //}
}