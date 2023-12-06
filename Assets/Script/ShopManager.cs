
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
          
            itemList = Resources.LoadAll<WeaponSO>("ScriptableObject/");
            for (int i = 0; i < ShopItemCount; i++) 
            {
         
                GameObject newWeapon = Instantiate(Resources.Load<GameObject>("Prefab/Weapon")) as GameObject;
                newWeapon.GetComponent<Items>().weapon = itemList[Random.Range(0,itemList.Length)] ;
                newWeapon.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 100f);
               
                newWeapon.transform.SetParent(transform);
                newWeapon.transform.localScale = new Vector2(1f, 1f);
            }
        }

        public void Add(GameObject item)
        {
            if (InventoryManager.instance.isFullItem == false && CharacterStats.instance.Coin >= item.GetComponent<Items>().weapon.Price)
            {
                CharacterStats.instance.Coin -= item.GetComponent<Items>().weapon.Price;
                GameObject newWeapon = Instantiate(Resources.Load<GameObject>("Prefab/Weapon")) as GameObject;
                newWeapon.GetComponent<Items>().weapon = item.GetComponent<Items>().weapon;
                newWeapon.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 100f);

                newWeapon.transform.SetParent(InventoryManager.instance.inventory.transform);
                newWeapon.transform.localScale = new Vector2(1f, 1f);
                Destroy(item);
            }
        }
    }
}
