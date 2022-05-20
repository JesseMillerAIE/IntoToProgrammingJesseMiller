using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockedDoor : MonoBehaviour
{
    public string keyName;
    private InventoryManager _inventoryManager;
    public Text infoText;
    private bool _canOpenDoor;
    private bool _inTrigger;


    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //this is an if statement that is checking for 2 conditions to be true using the syntax "&&"
        if (_canOpenDoor == true && Input.GetKeyDown(KeyCode.E) == true && _inTrigger == true)
        {
            infoText.text = "";

            //remove item from inventory 
            _inventoryManager.UseItem(keyName);

            //setting the parent gameobject inactive
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //set bool intrigger to true
            _inTrigger = true;

            //asking InventoryManager if the Player has the correct item, 
            //i.e there is an item in the inventory that has the same name as the public string "KeyName"
            if (_inventoryManager.CheckInventoryForItem(keyName))
            {
                //tell the player that they can open the door
                infoText.text = "Press 'E' to open door";

                //set a bool to allow the player to open the door, that we will check in Update()
                _canOpenDoor = true;
            }

            else 
            {
                //tell the play they need to find "X" key
                infoText.text = "Door is locked, find the " + keyName;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _inTrigger = false;
            infoText.text = "";
        }
    }
}
