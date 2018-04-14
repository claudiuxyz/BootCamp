package com.ale;

public abstract class Unit
{
    private Unit[] children;

    public Unit(Unit... children)
    {
        this.children = children;
    }

    public void acceptVisitor(UnitVisitor visitor)
    {
        for (Unit child : children)
        {
            child.acceptVisitor(visitor);
        }
    }
}
