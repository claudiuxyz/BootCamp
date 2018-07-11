package com.ale;

public class Commander extends Unit
{
    public Commander(Unit... children)
    {
        super(children);
    }

    @Override
    public void acceptVisitor(UnitVisitor visitor)
    {
        visitor.visitCommander(this);
        super.acceptVisitor(visitor);
    }

    @Override
    public String toString()
    {
        return "commander";
    }
}
