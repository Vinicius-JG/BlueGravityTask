using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Inventory_UI inventory_UI;
    [SerializeField] Inventory_UI playerInventory_UI;
    [SerializeField] Inventory_UI basketInventory_UI;

    [SerializeField] Basket basket;

    [SerializeField] Actor player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!basketInventory_UI.IsOn())
                Enter(player);
            else
                Exit();

            inventory_UI.SetVisibility(!inventory_UI.IsOn());
            basketInventory_UI.SetVisibility(!basketInventory_UI.IsOn());
            playerInventory_UI.SetVisibility(!inventory_UI.IsOn());
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Submit();
        }
    }

    void Enter(Actor customer)
    {
        basket.Initialize(customer, GetComponent<Inventory>());
    }

    void Submit()
    {
        if (-basket.GetTotal() > basket.GetCustomer().GetMoney())
            return;

        basket.GetCustomer().ChangeMoney(basket.GetTotal());
        basket.ConfirmTransaction();
    }

    void Exit()
    {
        basket.CancelTransaction();
    }
}
