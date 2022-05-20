using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public int currentCurrencyAmount;
    public Text currencyAmountText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateText()
    {
        currencyAmountText.text = currentCurrencyAmount.ToString();
    }

    public void AddCurrency(int _currencyToAdd)
    {
        currentCurrencyAmount += _currencyToAdd;
        UpdateText();
    }

    public void RemoveCurrency(int _currencyToRemove)
    {
        currentCurrencyAmount -= _currencyToRemove;
        UpdateText();
    }


}
