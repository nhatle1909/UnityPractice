
using Assets;
using System;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    private bool isFullItem = false;
    private GameObject weaponEquipped;
    private CharacterStats charStats;
    private GameObject inventory;

    public static InventoryManager instance;
    public void Awake()
    {
        instance = this;
        inventory = GameObject.Find("Inventory");
        weaponEquipped = GameObject.Find("WeaponEquipped");
        charStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        weaponEquipped.SetActive(false);
    }

    private void Update()
    {
        if (inventory.transform.childCount == 18) // Max Item Number in inventory is 18 
        {
            isFullItem = true;
        }
        else 
        {
            isFullItem = false;
        }
    }
    public  void Add(GameObject item) 
    {
        if (isFullItem == false)
        {
       
            GameObject newWeapon = Instantiate(Resources.Load<GameObject>("Prefab/Weapon")) as GameObject;
            newWeapon.GetComponent<Items>().weapon = item.GetComponent<Items>().weapon;
            newWeapon.GetComponent<RectTransform>().sizeDelta = new Vector2(150f,100f);

            newWeapon.transform.SetParent(inventory.transform);
            newWeapon.transform.localScale = new Vector2(1f,1f);
            Destroy(item);
        } 
    }

    public void Equip(GameObject item) 
    {
        if (weaponEquipped.activeInHierarchy)
        {
            UnEquip();
        }
        GameService.Instance.Equip(charStats,weaponEquipped,item);
    }
    public void UnEquip() 
    {
        GameService.Instance.UnEquip(charStats, weaponEquipped);
    }
}
