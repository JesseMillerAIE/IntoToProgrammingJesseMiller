using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InventoryManager : MonoBehaviour
{
    public List<string> inventoryItemNames;
    public Text inventoryListText;
    public GameObject inventoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        //clear text
        inventoryListText.text = "";

        //turn off the inventory panel on start incase was left on
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        //checking every frame to see if tab was pushed
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //set the inventory panel active or inactive depending on whether it is currently active or inactive
            inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
        }
    }

    public void AssignInvetoryItem(string _itemPickedUp)
    {
        //add the item to the piclup list, the item name is passed in from the function call on the pickup item script
        inventoryItemNames.Add(_itemPickedUp);
        UpdateInventoryText();
    }

    public void UpdateInventoryText()
    {
        //clear text
        inventoryListText.text = "";

        //foreach loop will run through eacg item in the list and execute the code
        foreach (string _inventoryItem in inventoryItemNames)
        {
            //add new item to the text then creat a new line (/n)
            inventoryListText.text += _inventoryItem + "/n";
        }
    }

    public bool CheckInventoryForItem(string _itemToCheck)
    {
        //run through each item in inventory list to che4ck if the name passed in (_itemToCheck) matches an item in inventory
        foreach (string _inventoryItem in inventoryItemNames)
        {
            //check if the inn=ventory item we are up to has the same name
            if (_inventoryItem == _itemToCheck)
            {
                //return a true boolean to whatever has called the function
                return true;
            }
        }

        //return a false boolean to whatever has called the function
        return false;
    }

    public void UseItem(string _itemToCheck)
    {
        bool _foundItem = false;

        //run through each item in inventory list to che4ck if the name passed in (_itemToCheck) matches an item in inventory
        foreach (string _inventoryItem in inventoryItemNames)
        {
            //check if the inn=ventory item we are up to has the same name
            if (_inventoryItem == _itemToCheck)
            {
                _foundItem = true;

            }
        }

        //after loop has finished, we then remove item from inventory
        if(_foundItem == true)
        {
            //remove the item from the inventory
            inventoryItemNames.Remove(_itemToCheck);

            //update the textfor the inventory
            UpdateInventoryText();
        }

    }
}
