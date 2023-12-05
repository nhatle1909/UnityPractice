
using TMPro;
using UnityEngine;

namespace Assets
{
    public class Coin : MonoBehaviour
    {
        private TextMeshProUGUI coinNumber;
        public void Start()
        {
            coinNumber = GetComponent<TextMeshProUGUI>();
        }
        public void Update()
        {
            coinNumber.SetText(CharacterStats.instance.Coin.ToString());
        }
    }
}
