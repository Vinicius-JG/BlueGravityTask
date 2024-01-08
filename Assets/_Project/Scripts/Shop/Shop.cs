using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    Actor actor;
    [SerializeField] Inventory_UI inventory_UI;
    [SerializeField] Inventory_UI playerInventory_UI;
    [SerializeField] Basket_UI basketInventory_UI;

    [SerializeField] Basket basket;

    private void Awake()
    {
        OnInteract += Enter;
    }

    void Enter(Actor customer)
    {
        actor = customer;
        basket.SetBasket(customer, GetComponent<Inventory>());
        basketInventory_UI.Initialize(basket);
        inventory_UI.Initialize(GetComponent<Inventory>());

        inventory_UI.SetVisibility(true);
        basketInventory_UI.SetVisibility(true);
        playerInventory_UI.SetVisibility(true);

        actor.GetComponent<Player>().GetInputActions().UI.Back.performed += ctx => Exit();
        actor.GetComponent<Player>().GetInputActions().UI.Submit.performed += ctx => basket.ConfirmTransaction();
        actor.GetComponent<Player>().GetInputActions().Gameplay.Disable();
    }

    void Exit()
    {
        actor.GetComponent<Player>().GetInputActions().UI.Submit.performed -= ctx => basket.ConfirmTransaction();
        actor.GetComponent<Player>().GetInputActions().UI.Back.performed -= ctx => Exit();
        actor.GetComponent<Player>().GetInputActions().Gameplay.Enable();

        inventory_UI.SetVisibility(false);
        basketInventory_UI.SetVisibility(false);
        playerInventory_UI.SetVisibility(false);

        basket.CancelTransaction();
        basketInventory_UI.Clear();
    }
}
