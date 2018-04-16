package com.ale;

public class dispenser100Lei implements DispenseChain
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
        if(currency.getAmount() >= 100)
        {
            int num = currency.getAmount() / 100;
            int rest = currency.getAmount() % 100;
            System.out.println("Dispensing " + num + " of 100 lei notes");
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
