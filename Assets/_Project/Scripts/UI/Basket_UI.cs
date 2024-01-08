using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Basket_UI : Inventory_UI
{
    [SerializeField] TextMeshProUGUI totalTMP;
    [SerializeField] TextMeshProUGUI finalBalanceTMP;

    private void Start()
    {
        RefreshItems();
        RefreshText();
        inventory.OnItemsChanged += RefreshText;
        inventory.OnItemsChanged += RefreshItems;
    }

    void RefreshText()
    {
        Basket basket = inventory as Basket;

        totalTMP.text = basket.GetTotal().ToString("+#;-#;0"); ;

        if(basket.GetCustomer() != null)
            finalBalanceTMP.text = (basket.GetCustomer().GetMoney() + basket.GetTotal()).ToString();
    }
}
