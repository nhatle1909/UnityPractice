


using UnityEngine;
namespace Assets
{

    public class EnemyCombatScript : MonoBehaviour
    {
        [SerializeField]
        public int HP = 20;
        [SerializeField]
        public int ATK = 10;

        public int currentHP;

        private Rigidbody2D rb;

        private Animator animator;


        public float attackRange = 1f;

        public Transform AttackPoint;

        public LayerMask enemyLayer;

      
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            currentHP = HP;
            rb = GetComponent<Rigidbody2D>();
        }



        // Update is called once per frame
        void FixedUpdate()
        {
            GameService.Instance.isDeath(HP, animator);
            GameService.Instance.isDamaged(HP, ref currentHP, animator);

        }




        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.bodyType = RigidbodyType2D.Static;
                animator.SetTrigger(AnimationStringManager.Attack);
            }
        }
        public void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
     

        public void AttackEvent()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D hit in hits)
            {
                hit.gameObject.GetComponent<CombatManager>().HP -= ATK - hit.gameObject.GetComponent<CombatManager>().DEF;
            }
        }
        public void DestroyObject()
        {
            Destroy(transform.parent.gameObject);
        }


    }
}