using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(fileName = "New Monster Stats", menuName = "New Monster")]
    public class EnemyStatsTemplate : ScriptableObject
    {
      
        public int HP;
        
        public int ATK;
        public int test;
        public float Speed;
    }
}
