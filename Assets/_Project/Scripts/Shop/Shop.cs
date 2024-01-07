using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Inventory_UI inventory_UI;
    [SerializeField] Inventory_UI playerInventory_UI;
    [SerializeField] Inventory_UI basketInventory_UI;

    [SerializeField] Basket basket;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (basketInventory_UI.IsOn())
                Exit();

            inventory_UI.SetVisibility(!inventory_UI.IsOn());
            basketInventory_UI.SetVisibility(!basketInventory_UI.IsOn());
            playerInventory_UI.SetVisibility(!inventory_UI.IsOn());
        }
    }

    void Exit()
    {
        basket.CancelTransaction();
    }

}
