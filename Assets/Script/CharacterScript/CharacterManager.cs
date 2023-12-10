using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets
{
    public class CharacterManager : MonoBehaviour
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
        [SerializeField]
        public int Coin;

        public static CharacterManager instance;
        public void Start()
        {
            instance = this;
        }
        public void Update()
        {
            InventoryManager.instance.InventoryCheck();
            CoinManager.instance.CoinUpdate();
            
        }
        private void FixedUpdate()
        {
            MovementController.instance.Movement();
            CombatController.instance.Combat();
        }
    }
   
}
