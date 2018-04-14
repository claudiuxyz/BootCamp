package com.ale;

public class Soldier extends Unit
{
    public Soldier(Unit... children)
    {
        super(children);
    }

    @Override
    public void acceptVisitor(UnitVisitor visitor)
    {
        visitor.visitSoldier(this);
        super.acceptVisitor(visitor);
    }

    @Override
    public String toString()
    {
        return "soldier";
    }
}
