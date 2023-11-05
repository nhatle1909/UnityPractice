
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class CombatManager : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField]
        public int HP = 20;
        [SerializeField]
        public int ATK = 10;
        [SerializeField]
        public int DEF = 5;

        public int currentHP;

        public float attackRange = 1f;

        public Transform AttackPoint;

        public LayerMask enemyLayer;

        private UnityEngine.UI.Slider HPBar;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
            HPBar = GameObject.Find("HP").GetComponent<UnityEngine.UI.Slider>();
            HPBar.maxValue = HP;
            currentHP = HP;
        }
        public void Update()
        {
            HPBar.value = HP;
            GameService.Instance.isDeath(HP, animator);
            GameService.Instance.isDamaged(HP, ref currentHP, animator);


        }

        public void AttackEvent()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D hit in hits)
            {
                hit.gameObject.GetComponent<EnemyCombatScript>().HP -= ATK;
            }
        }
        public void Pause()
        {
            Time.timeScale = 0;
        }

    }
}