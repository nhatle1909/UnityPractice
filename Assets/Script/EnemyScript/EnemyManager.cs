using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class EnemyManager : MonoBehaviour
    {
        EnemyCombatController a;
        PatrolController p;
        private void Start()
        {
           a = GetComponent<EnemyCombatController>();
            p = GetComponent<PatrolController>();
        }
        public void Update()
        {

        }
        public void FixedUpdate()
        {
            a.EnemyCombat();
            p.EnemyPatrol();
        }
    }
}
