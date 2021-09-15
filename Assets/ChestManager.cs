using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ChestManager : MonoBehaviour {


    [Header("Arrows")]
    public GameObject horizontalArrow;
    public GameObject verticalArrow;
    public GameObject blinkingArrow;

    //item panels that you see when the chest is open
    public GameObject weaponItemPanel;
    public GameObject armorItemPanel;
    public GameObject accessoryItemPanel;
    public Transform chestItemSpacer;

    //full gameobjects
    public GameObject chestInventoryCanvas;
    public GameObject inventoryCanvas;

    public bool chestOpen;
    public bool chestEmpty;

    public List<GameObject> optionsList = new List<GameObject>();
    private int currentOption = 0;
    public List<GameObject> inventoryOptionsList = new List<GameObject>();
    private int inventoryCurrentOption = 0;
    public List<GameObject> weaponsInChest = new List<GameObject>();
    public List<GameObject> armorInChest = new List<GameObject>();
    public List<GameObject> accessoriesInChest = new List<GameObject>();

    //none replacement items
    public GameObject NoneItemWeapon;
    public GameObject NoneItemArmor;
    public GameObject NoneItemAccessory;

    //empty bools
    public bool emptyWeapon;
    public bool emptyArmor;
    public bool emptyAccessory;


    private int selectedItem = -1;

    [Header("Scrolling")]
    public ScrollRect itemScrollRect;
    private int arrowCounter = 1;

    //equip panel hero panels
    public Transform heroEquipPanelSpacer;
    public List<GameObject> HeroEquipPanels;
    public TeamManagement teamManagement;

    //equipping
    public GameObject associatedGameObject;

    //empty chest variables
    public Text EmptyWeaponItemName;
    public Text EmptyArmorItemName;
    public Text EmptyAccessoryItemName;

    public Button EmptyWeaponEquipItemButton;
    public Button EmptyWeaponStoreItemButton;
    public Button EmptyArmorEquipItemButton;
    public Button EmptyArmorStoreItemButton;
    public Button EmptyAccessoryEquipItemButton;
    public Button EmptyAccessoryStoreItemButton;

    // Use this for initialization
    void Start () {

        ChestWeaponPanels();
        ChestArmorPanels();
        ChestAccessoryPanels();

        teamManagement = FindObjectOfType<TeamManagement>();
        chestInventoryCanvas = GameObject.Find("ChestInventoryCanvas");
        inventoryCanvas = GameObject.Find("HeroEquipInventoryCanvas");

        //HeroEquipPanels = teamManagement.HeroTeam;
    }
	
	// Update is called once per frame
	void Update ()
    {

        EmptyWeaponItemName = GameObject.Find("WeaponItemName").GetComponent<Text>();
        EmptyWeaponEquipItemButton = GameObject.Find("EquipWeaponButton").GetComponent<Button>();
        EmptyWeaponStoreItemButton = GameObject.Find("StoreWeaponButton").GetComponent<Button>();

        if (EmptyWeaponItemName.text == "Empty")
        {
            EmptyWeaponEquipItemButton.interactable = false;
            EmptyWeaponStoreItemButton.interactable = false;
            emptyWeapon = true;    
        }

        EmptyArmorItemName = GameObject.Find("ArmorItemName").GetComponent<Text>();
        EmptyArmorEquipItemButton = GameObject.Find("EquipArmorButton").GetComponent<Button>();
        EmptyArmorStoreItemButton = GameObject.Find("StoreArmorButton").GetComponent<Button>();

        if (EmptyArmorItemName.text == "Empty")
        {
            EmptyArmorEquipItemButton.interactable = false;
            EmptyArmorStoreItemButton.interactable = false;
            emptyArmor = true;
        }

        EmptyAccessoryItemName = GameObject.Find("AccessoryItemName").GetComponent<Text>();
        EmptyAccessoryEquipItemButton = GameObject.Find("EquipAccessoryButton").GetComponent<Button>();
        EmptyAccessoryStoreItemButton = GameObject.Find("StoreAccessoryButton").GetComponent<Button>();

        if (EmptyAccessoryItemName.text == "Empty")
        {
            EmptyAccessoryEquipItemButton.interactable = false;
            EmptyAccessoryStoreItemButton.interactable = false;
            emptyAccessory = true;
        }

        if(emptyWeapon == true && emptyArmor == true && emptyAccessory == true)
        {
            chestEmpty = true;
        }
    }

    public void ChestWeaponPanels()
    {
        foreach (GameObject chestItem in weaponsInChest)
        {
            GameObject newItem = Instantiate(weaponItemPanel) as GameObject;
            Text itemNameText = newItem.transform.Find("WeaponItemName").GetComponent<Text>();
            Image itemImage = newItem.transform.Find("WeaponItemHolderImage").GetComponent<Image>();
            Button weaponEquipButton = GameObject.Find("EquipWeaponButton").GetComponent<Button>();

            itemNameText.text = chestItem.GetComponent<BaseItem>().itemName;
            itemImage.sprite = chestItem.GetComponent<BaseItem>().itemImage;
            newItem.transform.SetParent(chestItemSpacer, false);
            
            if (itemNameText.text == "Empty")
            {
                weaponEquipButton.interactable = false;
            }
        }

    }

    public void ChestArmorPanels()
    {
        foreach (GameObject chestItem in armorInChest)
        {
            GameObject newItem = Instantiate(armorItemPanel) as GameObject;
            Text itemNameText = newItem.transform.Find("ArmorItemName").GetComponent<Text>();
            Image itemImage = newItem.transform.Find("ArmorItemHolderImage").GetComponent<Image>();

            itemNameText.text = chestItem.GetComponent<BaseItem>().itemName;
            itemImage.sprite = chestItem.GetComponent<BaseItem>().itemImage;
            newItem.transform.SetParent(chestItemSpacer, false);

        }
    }

    public void ChestAccessoryPanels()
    {
        foreach (GameObject chestItem in accessoriesInChest)
        {
            GameObject newItem = Instantiate(accessoryItemPanel) as GameObject;
            Text itemNameText = newItem.transform.Find("AccessoryItemName").GetComponent<Text>();
            Image itemImage = newItem.transform.Find("AccessoryItemHolderImage").GetComponent<Image>();

            itemNameText.text = chestItem.GetComponent<BaseItem>().itemName;
            itemImage.sprite = chestItem.GetComponent<BaseItem>().itemImage;
            newItem.transform.SetParent(chestItemSpacer, false);
            //itemsInChest.Add(newItem);
        }
    }

    public void XOut()
    {
        chestInventoryCanvas.SetActive(false);
        inventoryCanvas.SetActive(false);
    }


}
