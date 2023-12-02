using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets
{
    public class CharacterStats : MonoBehaviour
    {
        [SerializeField]
        public int HP;
        [SerializeField]
        public int ATK;
        [SerializeField]
        public float attackRange = 1f;
        [SerializeField]
        public float Speed;
        [SerializeField]
        public float Jump_Force;
      
    }
   
}
