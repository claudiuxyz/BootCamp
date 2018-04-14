package com.ale;

public class Sergeant extends Unit
{
    public Sergeant(Unit... children)
    {
        super(children);
    }

    @Override
    public void acceptVisitor(UnitVisitor visitor)
    {
        visitor.visitSergeant(this);
        super.acceptVisitor(visitor);
    }

    @Override
    public String toString()
    {
        return "sergeant";
    }
}
