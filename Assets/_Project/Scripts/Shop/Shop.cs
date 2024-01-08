using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    [SerializeField] Inventory_UI inventory_UI;
    [SerializeField] Inventory_UI playerInventory_UI;
    [SerializeField] Inventory_UI basketInventory_UI;

    [SerializeField] Basket basket;

    bool active;

    private void Awake()
    {
        OnInteract += Enter;
    }

    private void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                basket.ConfirmTransaction();

            if (Input.GetKeyDown(KeyCode.Escape))
                Exit();
        }
    }

    void Enter(Actor customer)
    {
        active = true;
        basket.Initialize(customer, GetComponent<Inventory>());
        basketInventory_UI.SetInventory(basket);
        inventory_UI.SetInventory(GetComponent<Inventory>());

        inventory_UI.SetVisibility(active);
        basketInventory_UI.SetVisibility(active);
        playerInventory_UI.SetVisibility(active);
    }

    void Exit()
    {
        active = false;

        inventory_UI.SetVisibility(active);
        basketInventory_UI.SetVisibility(active);
        playerInventory_UI.SetVisibility(active);

        basket.CancelTransaction();
    }
}
