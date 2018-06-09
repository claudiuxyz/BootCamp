package com.ale;

public class RealCustomer extends AbstractCustomer
{
    public RealCustomer(String name)
    {
        this.name = name;
    }

    @Override
    public String getName()
    {
        return this.name;
    }

    @Override
    public boolean isNull()
    {
        return false;
    }
}
