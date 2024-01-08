using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Actor
{
    [SerializeField] Inventory_UI inventory_UI;
    PlayerInputActions inputActions; 

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inventory_UI.Initialize(GetComponent<Inventory>());
        inputActions.Gameplay.InventoryToggle.performed += ctx => inventory_UI?.SetVisibility(!inventory_UI.IsOn());
    }

    public PlayerInputActions GetInputActions()
    {
        return inputActions;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
