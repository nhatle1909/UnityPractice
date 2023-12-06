
using UnityEngine.InputSystem;
using UnityEngine;


namespace Assets
{
    public class InputSystem : MonoBehaviour
    {

        private Animator animator;
        private CharacterMovement charMovement;
        private CharacterStats charStats;
        private void Start() 
        { 
            charStats = GetComponent<CharacterStats>();
            charMovement = GetComponent<CharacterMovement>();
            animator = GetComponent<Animator>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed && GameService.Instance.isGrounded(charMovement.transform) == true) //Press Space Button + Player is staying on ground
            {
                animator.SetBool(AnimationStringManager.Running, false); // Disable playing Run Animation when jump while running
                animator.SetBool(AnimationStringManager.Crouch, false); // Disable playing Crouch Animation when jump while Crouching
                animator.SetTrigger(AnimationStringManager.Jump); // Enable playing Jump Animation

                charMovement.rb.velocity = new Vector2(charMovement.horizontal, charStats.Jump_Force);
            }
        }

        public void Move(InputAction.CallbackContext context)
        {
            charMovement.horizontal = context.ReadValue<Vector2>().x;
        }

        public void Crouch(InputAction.CallbackContext context)
        {       
            if (context.performed)
            {
                charStats.Speed = 2.5f;
            }

            if (context.canceled)
            {
                charStats.Speed = 5f;     
            }
        }

       public void Fire(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                animator.SetTrigger(AnimationStringManager.Attack);           
                
            }
        }

       public void ESC(InputAction.CallbackContext context) 
        {

        }
        public void InventoryButton(InputAction.CallbackContext context)
        { 
        
        }
    }
}
