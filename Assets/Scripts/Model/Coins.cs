using System;

public class Coins
{
    public int Amount { get; private set; }

    public Coins(int initialAmount)
    {
        if (initialAmount < 0) throw new ArgumentException("Number of coins must be >= 0");
        Amount = initialAmount;
    }

    public void OnPickupCoin() => Amount++;

    public bool TryDiscard(int price)
    {
        if (Amount < price)
            return false;

        Amount -= price;
        return true;
    }
}