using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] int money;

    public void ChangeMoney(int amount)
    {
        money += amount;
    }

    public int GetMoney()
    {
        return money;
    }
}
