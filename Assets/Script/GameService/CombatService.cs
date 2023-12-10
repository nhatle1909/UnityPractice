using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class CombatService
    {
        private static CombatService _instance;
        private CombatService()
        {
        }

        public static CombatService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CombatService();
                }
                return _instance;
            }
        }

        public void isDamaged(int HP, ref int currentHP, Animator animator)
        {
            if (currentHP > HP && currentHP > 0)
            {
                animator.SetTrigger(AnimationStringManager.Hit);
                currentHP = HP;
            }
        }

        public void isDeath(int HP, Animator animator, Rigidbody2D rb) // For Enemy Bot
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

    }
}
