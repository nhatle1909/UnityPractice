
using UnityEngine;

namespace Assets
{

    public class EnemyStats : MonoBehaviour
    {
        [SerializeField]
        public int HP;
        [SerializeField]
        public int ATK;
        [SerializeField]
        public float Speed;

        public EnemyStatsTemplate Stats;
        public void Start()
        {
            HP = Stats.HP;
            ATK = Stats.ATK;
            Speed = Stats.Speed;
        }
    }
}
