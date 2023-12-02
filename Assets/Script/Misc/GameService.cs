
using UnityEngine;
using UnityEngine.UI;


namespace Assets
{
    public class GameService 
    {
        private static GameService _instance;
        private GameService()
        {
        }

        public static GameService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameService();
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

        public void isDamaged(int HP, ref int currentHP,Animator animator)
        {
            if (currentHP > HP && currentHP > 0)
            {
                animator.SetTrigger(AnimationStringManager.Hit);
                currentHP = HP;
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

        public void isDeath(int HP, Animator animator,Rigidbody2D rb) // For Enemy Bot
        {
            if (HP <= 0)
            {
                rb.bodyType = RigidbodyType2D.Static;
                animator.SetTrigger(AnimationStringManager.Death);
            }

        }

        public void isDeath(int HP, Animator animator) // For Player
        {
            if (HP <= 0)
            {
                animator.SetTrigger(AnimationStringManager.Death);
            }

        }

        public void UnEquip(CharacterStats charStats,GameObject weaponEquipped) 
        {
            charStats.ATK -= weaponEquipped.GetComponent<Items>().ATK;
            weaponEquipped.SetActive(false);
        }
        public void Equip(CharacterStats charStats, GameObject weaponEquipped,GameObject Item) 
        {
            if (!weaponEquipped.activeInHierarchy) 
            {
                weaponEquipped.SetActive(true);
            }
            weaponEquipped.GetComponent<Items>().ATK = Item.GetComponent<Items>().weapon.ATK;
            weaponEquipped.GetComponent<Items>().Description = Item.GetComponent<Items>().Description;
            weaponEquipped.GetComponent<Image>().sprite = Item.GetComponent<Items>().weapon.sprite;
           
            charStats.ATK += weaponEquipped.GetComponent<Items>().ATK;
        }

    }
}
