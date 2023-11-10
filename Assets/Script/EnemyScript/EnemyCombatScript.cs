


using UnityEngine;
namespace Assets
{

    public class EnemyCombatScript : MonoBehaviour
    {
        private EnemyStats enemyStats;

        public int currentHP;

        private Rigidbody2D rb;

        private Animator animator;


        public float attackRange = 1f;

        public Transform AttackPoint;

        public LayerMask enemyLayer;

      
        // Start is called before the first frame update
        void Start()
        {
            enemyStats = GetComponent<EnemyStats>();
            animator = GetComponent<Animator>();
            currentHP = enemyStats.HP;
            rb = GetComponent<Rigidbody2D>();
        }



        // Update is called once per frame
        void FixedUpdate()
        {
            GameService.Instance.isDeath(enemyStats.HP, animator,rb);
            GameService.Instance.isDamaged(enemyStats.HP, ref currentHP, animator);

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
                hit.gameObject.GetComponent<CharacterStats>().HP -= enemyStats.ATK ;
            }
        }
        public void DestroyObject()
        {
            Destroy(transform.parent.gameObject);
        }


    }
}