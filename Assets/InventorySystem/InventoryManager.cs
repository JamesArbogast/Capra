using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour {

    public enum InventoryStates
    {
        DISABLED,
        OPTIONS_PANEL,
        EQUIPMENT_PANEL,
        INVENTORY_PANEL,
        INVENTORY_USE,
        INVENTORY_ORGANIZE
    }

    public InventoryStates inventoryState;
    [Header("Panels")]
    public GameObject equipmentPanel;
    public GameObject optionsPanel;
    public GameObject inventoryPanel;
    public GameObject heroEquipPanel;

    [Header("Arrows")]
    public GameObject horizontalArrow;
    public GameObject verticalArrow;
    public GameObject blinkingArrow;

    public List<GameObject> optionsList = new List<GameObject>();
    private int currentOption = 0;
    public List<GameObject> inventoryOptionsList = new List<GameObject>();
    private int inventoryCurrentOption = 0;

    private int selectedItem = -1;
    [Header("Scrolling")]
    public ScrollRect itemScrollRect;
    private int arrowCounter = 1;

    //equip panel hero panels
    public Transform heroEquipPanelSpacer;
    public List<GameObject> HeroEquipPanels;
    public TeamManagement teamManagement;

	// Use this for initialization
	void Start () {
        teamManagement = FindObjectOfType<TeamManagement>();
        HeroEquipPanels = teamManagement.HeroTeam;


    }
	
	// Update is called once per frame
	void Update ()
    {

        switch (inventoryState)
        {
            case InventoryStates.DISABLED:
                break;

            case InventoryStates.OPTIONS_PANEL:
                OptionsSelect();
                HeroInventoryPanels();
                break;

            case InventoryStates.INVENTORY_PANEL:
                InventorySelect();
                break;

            case InventoryStates.INVENTORY_USE:
                UseAndOrder();

                break;

        }
	}

    void OptionsSelect()
    {
        horizontalArrow.SetActive(false);
        verticalArrow.SetActive(true);

        inventoryPanel.SetActive(false);
        equipmentPanel.SetActive(true);
        optionsPanel.SetActive(true);
        blinkingArrow.SetActive(false);

        if(Input.GetKeyDown(KeyCode.A) && currentOption > 0)
        {
            currentOption--;
        }
        else if(Input.GetKeyDown(KeyCode.D) && currentOption < optionsList.Count-1)
        {
            currentOption++;
        }

        if(Input.GetKeyDown(KeyCode.Space) && currentOption == 0)
        {
            //equipment panel
        }
        else if (Input.GetKeyDown(KeyCode.Space) && currentOption == 1)
        {
            //open inventory
            //hide options
            //hide vertical arrow

            inventoryState = InventoryStates.INVENTORY_PANEL;
        }

        verticalArrow.transform.position = optionsList[currentOption].transform.position;
    }


    void InventorySelect()
    {
        horizontalArrow.SetActive(true);
        verticalArrow.SetActive(false);

        inventoryPanel.SetActive(true);
        equipmentPanel.SetActive(false);
        optionsPanel.SetActive(false);
        blinkingArrow.SetActive(false);

        if (Input.GetKeyDown(KeyCode.A) && inventoryCurrentOption > 0)
        {
            inventoryCurrentOption--;
        }
        else if (Input.GetKeyDown(KeyCode.D) && inventoryCurrentOption < inventoryOptionsList.Count - 1)
        {
            inventoryCurrentOption++;
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            inventoryCurrentOption = 0;
            inventoryState = InventoryStates.OPTIONS_PANEL;
        }

        if(Input.GetKeyDown(KeyCode.Space) && inventoryCurrentOption == 0)
        {
            inventoryState = InventoryStates.INVENTORY_USE;
            InventoryUI.instance.descriptionTextField.text = Inventory.instance.inventoryList[inventoryCurrentOption].item.description;
            arrowCounter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && inventoryCurrentOption == 1)
        {
            //Organize items
            //Inventory.instance.inventoryList = Inventory.instance.inventoryList.OrderBy(t => t.item.itemID).ToList();
            Inventory.instance.inventoryList = Inventory.instance.inventoryList.OrderBy(t => t.item.type).ThenBy(t => t.item.name).ToList();
            //recreate item list
            InventoryUI.instance.RecreateList();
        }

        horizontalArrow.transform.position = inventoryOptionsList[inventoryCurrentOption].transform.position;
    }

    void UseAndOrder()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            inventoryCurrentOption = 0;
            inventoryState = InventoryStates.INVENTORY_PANEL;
        }

        if (InventoryUI.instance.itemHolderList.Count <= 0)
        {
            return;
        }

        //movement up
        if (Input.GetKeyDown(KeyCode.W) && inventoryCurrentOption > 0)
        {
            inventoryCurrentOption--;

            if (arrowCounter > 1)
            {
                arrowCounter--;
            }
            else if (arrowCounter == 1)
            {
                itemScrollRect.verticalNormalizedPosition += (float)1 / (InventoryUI.instance.itemHolderList.Count - 6); 
            }

            InventoryUI.instance.descriptionTextField.text = Inventory.instance.inventoryList[inventoryCurrentOption].item.description;
        }
        //movement down
        else if (Input.GetKeyDown(KeyCode.S) && inventoryCurrentOption < InventoryUI.instance.itemHolderList.Count-1)
        {
            inventoryCurrentOption++;

            if (arrowCounter < 6)
            {
                arrowCounter++;
            }
            else if (arrowCounter == 6)
            {
                itemScrollRect.verticalNormalizedPosition -= (float)1 / (InventoryUI.instance.itemHolderList.Count - 6);
            }

            InventoryUI.instance.descriptionTextField.text = Inventory.instance.inventoryList[inventoryCurrentOption].item.description;
        }

        if(Input.GetKeyDown(KeyCode.Space) && selectedItem == -1)
        {
            blinkingArrow.SetActive(true);

            blinkingArrow.transform.position = horizontalArrow.transform.position;

            selectedItem = inventoryCurrentOption;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && (selectedItem != -1) && (selectedItem != inventoryCurrentOption))
        {
            Inventory.instance.SwapItems(selectedItem, inventoryCurrentOption);
            selectedItem = -1;
            blinkingArrow.SetActive(false);

        }

        if(blinkingArrow.activeInHierarchy)
        {
            blinkingArrow.transform.position = InventoryUI.instance.itemHolderList[selectedItem].GetComponent<ItemHolder>().arrowPoint.transform.position;
        }

        horizontalArrow.transform.position = InventoryUI.instance.itemHolderList[inventoryCurrentOption].GetComponent<ItemHolder>().arrowPoint.transform.position;
    }

    public void HeroInventoryPanels()
    {
        foreach (GameObject equipHero in HeroEquipPanels)
        {
            Debug.Log("Working on it!");
            GameObject newPanel = Instantiate(heroEquipPanel) as GameObject;
            HeroEquipPanelSelect panel = newPanel.GetComponent<HeroEquipPanelSelect>();
            HeroStateMachine currentHero = equipHero.GetComponent<HeroStateMachine>();
            
            Text panelNameText = newPanel.transform.Find("CharacterNameText").gameObject.GetComponent<Text>();
            panelNameText.text = currentHero.hero.theName;
            panel.heroPrefab = equipHero;
            newPanel.transform.SetParent(heroEquipPanelSpacer, false);
            HeroEquipPanels.Add(newPanel);

            Debug.Log("FinishedCreatingHeroPanels");

        }
    }
}
