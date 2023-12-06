
using Assets;
using System;
using TMPro;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    public bool isFullItem = false;
    public GameObject weaponEquipped;
    public GameObject inventory;
 
    public static InventoryManager instance;
    public void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
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
 

    public void Equip(GameObject item) 
    {
        if (weaponEquipped.activeInHierarchy)
        {
            UnEquip();
        }
        GameService.Instance.Equip(CharacterStats.instance,weaponEquipped,item);
    }
    public void UnEquip() 
    {
        GameService.Instance.UnEquip(CharacterStats.instance, weaponEquipped);
    }
}
