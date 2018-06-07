package com.ale;

public class dispenser10Lei implements DispenseChain
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
        if (currency.getAmount() >= 10)
        {
            int num = currency.getAmount() / 10;
            int rest = currency.getAmount() % 10;
            System.out.println("Dispensing " + num + " of 10 lei notes");
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
