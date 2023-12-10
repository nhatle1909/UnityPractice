using UnityEngine;
using UnityEngine.UI;


namespace Assets
{
    public class ItemService 
    {
        private static ItemService instance;
        private ItemService() { }
        public static ItemService Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemService();
                }
                return instance;
            }
        }

        public void UnEquip(CharacterManager charStats, GameObject weaponEquipped)
        {
            charStats.ATK -= weaponEquipped.GetComponent<Items>().ATK;
            weaponEquipped.SetActive(false);
        }
        public void Equip(CharacterManager charStats, GameObject weaponEquipped, GameObject Item)
        {
            if (!weaponEquipped.activeInHierarchy)
            {
                weaponEquipped.SetActive(true);
            }
            weaponEquipped.GetComponent<Items>().ATK = Item.GetComponent<Items>().weapon.ATK;
            weaponEquipped.GetComponent<Items>().Description = Item.GetComponent<Items>().Description;
            weaponEquipped.GetComponent<Image>().sprite = Item.GetComponent<Items>().weapon.sprite;

            charStats.ATK += weaponEquipped.GetComponent<Items>().ATK;
        }
        public void ItemGenerate(WeaponSO[] itemList, int ShopItemCount,Transform transform) 
        {
            itemList = Resources.LoadAll<WeaponSO>("ScriptableObject/");
            for (int i = 0; i < ShopItemCount; i++)
            {      
                GameObject newWeapon = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Weapon")) as GameObject;
                newWeapon.GetComponent<Items>().weapon = itemList[Random.Range(0, itemList.Length)];
                newWeapon.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 100f);

                newWeapon.transform.SetParent(transform);
                newWeapon.transform.localScale = new Vector2(1f, 1f);
            }
        }
        public void Buy(GameObject item) 
        {
            CharacterManager.instance.Coin -= item.GetComponent<Items>().weapon.Price;
            GameObject newWeapon = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Weapon")) as GameObject;
            newWeapon.GetComponent<Items>().weapon = item.GetComponent<Items>().weapon;
            newWeapon.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 100f);
            
            newWeapon.transform.SetParent(InventoryManager.instance.inventory.transform);
            newWeapon.transform.localScale = new Vector2(1f, 1f);
            MonoBehaviour.Destroy(item);
        }
     
    }
}
