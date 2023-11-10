
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class CombatManager : MonoBehaviour
    {
        // Start is called before the first frame update


        private CharacterStats charStats;

        public int currentHP;

      

        public Transform AttackPoint;

        public LayerMask enemyLayer;

        private UnityEngine.UI.Slider HPBar;

        private Animator animator;

        private void Start()
        {
            charStats = GetComponent<CharacterStats>();
            animator = GetComponent<Animator>();
            HPBar = GameObject.Find("HP").GetComponent<UnityEngine.UI.Slider>();
            HPBar.maxValue = charStats.HP;
            currentHP = charStats.HP;
        }
        public void Update()
        {
            HPBar.value = charStats.HP;
            GameService.Instance.isDeath(charStats.HP, animator);
            GameService.Instance.isDamaged(charStats.HP, ref currentHP, animator);


        }

        public void AttackEvent()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(AttackPoint.position, charStats.attackRange, enemyLayer);
            foreach (Collider2D hit in hits)
            {
                hit.gameObject.GetComponent<EnemyStats>().HP -= charStats.ATK;
            }
        }
        public void Pause()
        {
            Time.timeScale = 0;
        }

    }
}