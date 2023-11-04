


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
        public float speed = 2f;

        public Rigidbody2D rb;
        public Transform leftEnd;
        public Transform rightEnd;
        private Animator animator;

        float xscale;

        public float attackRange = 1f;

        public Transform AttackPoint;

        public LayerMask enemyLayer;

        public bool isMovingRight = true;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            currentHP = HP;
            rb = GetComponent<Rigidbody2D>();
            xscale = transform.localScale.x;
        }



        // Update is called once per frame
        void FixedUpdate()
        {

            if (isMovingRight)
            {
                rb.velocity = new Vector2(speed, 0f);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0f);
            }

            if (transform.position.x > rightEnd.position.x)
            {
                isMovingRight = false;
            }
            if (transform.position.x < leftEnd.position.x)
            {

                isMovingRight = true;
            }

            GameService.Instance.isFlip(rb, transform, xscale);
            GameService.Instance.isDeath(HP, animator);
            GameService.Instance.isDamaged(HP, currentHP, animator);

        }




        public void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.bodyType = RigidbodyType2D.Static;
                animator.SetTrigger(AnimationStringManager.Attack);
            }
        }
        public void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
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
            Destroy(gameObject);
        }


    }
}