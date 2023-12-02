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
        [SerializeField]
        public int HP;
        [SerializeField]
        public int ATK;
        [SerializeField]
        public float Speed;
    }
}
