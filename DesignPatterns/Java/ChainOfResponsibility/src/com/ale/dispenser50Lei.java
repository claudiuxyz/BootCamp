package com.ale;

public class dispenser50Lei implements DispenseChain
{
    private DispenseChain chain;

    @Override
    public void setNextChain(DispenseChain nextChain)
    {
        this.chain = nextChain;
    }

    @Override
    public void dispense(Currency currency)
    {
        if (currency.getAmount() >= 50)
        {
            int num = currency.getAmount() / 50;
            int rest = currency.getAmount() % 50;
            System.out.println("Dispensing " + num + " of 50 lei notes");
            if (rest != 0)
            {
                this.chain.dispense(new Currency(rest));
            }
        }
        else
        {
            this.chain.dispense(currency);
        }

    }
}
