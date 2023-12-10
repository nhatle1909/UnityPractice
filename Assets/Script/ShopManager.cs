
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class ShopManager : MonoBehaviour
    {
        private int ShopItemCount = 10;
        WeaponSO[] itemList;
        public static ShopManager instance;
        int randomIndex;
        public void Awake()
        {
                instance = this;
        }

        private void Start()
        {
            
            ItemGenerate();
        }

        public void ItemGenerate() 
        {
            ItemService.Instance.ItemGenerate(itemList,ShopItemCount,transform);   
        }

        public void Buy(GameObject item)
        {
            if (InventoryManager.instance.isFullItem == false && CharacterManager.instance.Coin >= item.GetComponent<Items>().weapon.Price)
            {
               ItemService.Instance.Buy(item);
            }
        }
    }
}
