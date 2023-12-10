using Assets;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

namespace Assets
{

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
            AssignItemInfor();
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
                button.onClick.AddListener(() => ShopManager.instance.Buy(gameObject));
            }
        }
        public void AssignItemInfor()
        {
            gameObject.name = weapon.Name;
            ATK = weapon.ATK;
            image = gameObject.GetComponent<Image>();
            Description = weapon.Description;
            Price = weapon.Price;
            image.sprite = weapon.sprite;

        
        }
        //public void OnMouseEnter()
        //{
        //    itemInfo.SetActive(true);
        //}

    }
    }