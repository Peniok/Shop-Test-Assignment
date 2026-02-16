using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private int currency;
    
    public bool IfEnoughSpend(int price)
    {
        if(currency >= price)
        {
            currency -= price;
            return true;
        }
        return false;
    }
}
