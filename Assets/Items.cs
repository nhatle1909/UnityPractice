using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int ATK;
    [SerializeField]
    public string Description;
    [SerializeField]
    public int Price;

    public WeaponSO weapon;
    public Image image;
    public Button button;
    public void Start()
    {
        gameObject.name = weapon.Name;
        ATK = weapon.ATK;
        image = gameObject.GetComponent<Image>();
        Description = weapon.Description;
        Price = weapon.Price;
        image.sprite = weapon.sprite;

        button = GetComponent<Button>();
        AddButtonListener();

    }
    public void AddButtonListener() 
    {
        if (transform.parent.gameObject.name.Equals("Inventory")) 
        {
            button.onClick.AddListener(() => InventoryManager.instance.Equip(gameObject));
        }
        if (transform.parent.gameObject.name.Equals("Shop")) 
        {
            button.onClick.AddListener(()=> InventoryManager.instance.Add(gameObject));
        }
    }

}
