using UnityEngine;

public class Player : Actor
{
    [SerializeField] Inventory_UI inventory_UI;

    private void Awake()
    {
        inventory_UI.SetInventory(GetComponent<Inventory>());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory_UI?.SetVisibility(!inventory_UI.IsOn());
        }
    }
}
