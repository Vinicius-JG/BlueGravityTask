using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Inventory_UI inventory_UI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory_UI?.SetVisibility(!inventory_UI.Ison());
        }
    }
}
