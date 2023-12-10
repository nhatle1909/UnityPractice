
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
    
    public void InventoryCheck()
    {
        isFullItem = inventory.transform.childCount == 18; 
    }
 

    public void Equip(GameObject item) 
    {
        if (weaponEquipped.activeInHierarchy)
        {
            UnEquip();
        }
        ItemService.Instance.Equip(CharacterManager.instance,weaponEquipped,item);
    }
    public void UnEquip() 
    {
        ItemService.Instance.UnEquip(CharacterManager.instance, weaponEquipped);
    }
}
