
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets
{
    public class CombatController : MonoBehaviour
    {
        public int currentHP;

        public Transform AttackPoint;

        public LayerMask enemyLayer;

        private Slider HPBar;

        private Animator animator;

        public static CombatController instance;
        private void Start()
        {
            instance = this;
            animator = GetComponent<Animator>();
            HPBar = GameObject.Find("HP").GetComponent<Slider>();
            HPBar.maxValue = CharacterManager.instance.HP;
            currentHP = CharacterManager.instance.HP;
        }
        public void Combat()
        {
            HPBar.value = CharacterManager.instance.HP;
            CombatService.Instance.isDeath(CharacterManager.instance.HP, animator);
            CombatService.Instance.isDamaged(CharacterManager.instance.HP, ref currentHP, animator);
        }

        public void AttackEvent()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(AttackPoint.position, CharacterManager.instance.attackRange, enemyLayer);
            foreach (Collider2D hit in hits)
            {
                hit.gameObject.GetComponent<EnemyStats>().HP -= CharacterManager.instance.ATK;
            }
        }
        public void Pause()
        {
            Time.timeScale = 0;
        }

    }
}