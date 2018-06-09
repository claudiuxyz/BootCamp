package com.ale;

public class NullCustomer extends AbstractCustomer
{
    @Override
    public String getName()
    {
        return "The name is not available in the Customer database.";
    }

    @Override
    public boolean isNull()
    {
        return true;
    }
}
