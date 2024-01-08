using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Basket_UI : Inventory_UI
{
    [SerializeField] Button submitBtn;
    [SerializeField] TextMeshProUGUI totalTMP;
    [SerializeField] TextMeshProUGUI finalBalanceTMP;

    public override void Initialize(Inventory inventory)
    {
        base.Initialize(inventory);
        RefreshItems();
        RefreshText();
        inventory.OnItemsChanged += RefreshText;
        inventory.OnItemsChanged += RefreshItems;
        inventory.OnItemsChanged += RefreshSubmitBtn;
        submitBtn.onClick.AddListener(inventory.GetComponent<Basket>().ConfirmTransaction);
    }

    public void Clear()
    {
        RefreshItems();
        RefreshText();
        inventory.OnItemsChanged -= RefreshText;
        inventory.OnItemsChanged -= RefreshItems;
        inventory.OnItemsChanged -= RefreshSubmitBtn;
        submitBtn.onClick.RemoveListener(inventory.GetComponent<Basket>().ConfirmTransaction);
    }

    void RefreshText()
    {
        Basket basket = inventory as Basket;

        totalTMP.text = basket.GetTotal().ToString("+#;-#;0"); ;

        if(basket.GetCustomer() != null)
            finalBalanceTMP.text = (basket.GetCustomer().GetMoney() + basket.GetTotal()).ToString();
    }

    void RefreshSubmitBtn()
    {
        submitBtn.interactable = inventory.GetComponent<Basket>().IsAValidTransaction();
    }
}
