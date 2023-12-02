using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "New Weapon")]
    public class WeaponSO : ScriptableObject
    {
        [SerializeField]
        public int ATK;
        [SerializeField]
        public string Name;
        [SerializeField]
        public Sprite sprite;
        [SerializeField]
        public string Description;
        [SerializeField]
        public int Price;
    }
}
