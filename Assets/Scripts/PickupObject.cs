using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
    public Transform PickupPoint;
    public Text InfoText;
    private InventoryManager _inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        //clear the infotext box
        InfoText.text = "";

        //looking through objects in scene to find the one with the InventoryManager script
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            InfoText.text = "Press 'E' to pickup object";
            if (Input.GetKey(KeyCode.E))
            {
                //turn off pickup collider
                  //other.GetComponent<Collider>().enabled = false;
                //move the object to pickup point
                  //other.transform.position = PickupPoint.position;
                //make pick up object chid of player
                  //other.transform.parent = this.transform;
                
                //clear the text
                InfoText.text = "";

                //calling into the function on the InventoryManager to add this pickup item to the inventory list
                //passing the collider game.object to it
                _inventoryManager.AssignInvetoryItem(other.gameObject.name);

                //destroying the pickup object
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            //clear the text
            InfoText.text = "";
        }
    }
}
