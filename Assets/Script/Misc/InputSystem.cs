
using UnityEngine.InputSystem;
using UnityEngine;


namespace Assets
{
    public class InputSystem : MonoBehaviour
    {
     
        private Animator animator;
        public DisplayShop displayShop;
        private void Start() 
        { 
            animator = GetComponent<Animator>();
            displayShop = GameObject.Find("shop").GetComponent<DisplayShop>();
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed && MovementService.Instance.isGrounded(MovementController.instance.transform) == true) //Press Space Button + Player is staying on ground
            {
                animator.SetBool(AnimationStringManager.Running, false); // Disable playing Run Animation when jump while running
                animator.SetBool(AnimationStringManager.Crouch, false); // Disable playing Crouch Animation when jump while Crouching
                animator.SetTrigger(AnimationStringManager.Jump); // Enable playing Jump Animation

                MovementController.instance.rb.velocity = new Vector2(MovementController.instance.horizontal, CharacterManager.instance.Jump_Force);
            }
        }

        public void Move(InputAction.CallbackContext context)
        {
            MovementController.instance.horizontal = context.ReadValue<Vector2>().x;
        }

        public void Crouch(InputAction.CallbackContext context)
        {       
            if (context.performed)
            {
                CharacterManager.instance.Speed = 2.5f;
            }

            if (context.canceled)
            {
                CharacterManager.instance.Speed = 5f;     
            }
        }

       public void Fire(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                animator.SetTrigger(AnimationStringManager.Attack);           
                
            }
        }

       public void Interact(InputAction.CallbackContext context)
        {
            if (context.performed) 
            {
                displayShop.isInteract = true;
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
