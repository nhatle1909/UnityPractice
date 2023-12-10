
using TMPro;
using UnityEngine;

namespace Assets
{
    public class CoinManager : MonoBehaviour
    {
        private TextMeshProUGUI coinNumber;
        public static CoinManager instance;
        public void Start()
        {
            instance = this;
            coinNumber = GetComponent<TextMeshProUGUI>();
        }
        public void CoinUpdate()
        {
            coinNumber.SetText(CharacterManager.instance.Coin.ToString());
        }
    }
}
