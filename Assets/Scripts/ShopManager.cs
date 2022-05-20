using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public string itemToUnlock;
    public int costOfItem;
    private CurrencyManager _currencyManager;
    private bool _isInTrigger;
    private bool _canPurchaseItem;
    private InventoryManager _inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        _currencyManager = FindObjectOfType<CurrencyManager>();
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void Update()
    {
        if(_isInTrigger == true && _canPurchaseItem && Input.GetKeyDown(KeyCode.E))
        {
            _currencyManager.RemoveCurrency(costOfItem);
            _inventoryManager.AssignInvetoryItem(itemToUnlock);
            _canPurchaseItem = CheckPlayerCurrency();
        }
    }

    private bool CheckPlayerCurrency()
    {
        if(_currencyManager.currentCurrencyAmount >= costOfItem)
        {
            return true;
        }
        else
        {
            return false;   
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _isInTrigger = true;    
            _canPurchaseItem = CheckPlayerCurrency();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _isInTrigger = false;
        }
    }

}
