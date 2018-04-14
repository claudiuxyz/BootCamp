package com.ale;

public class CommanderVisitor implements UnitVisitor
{
    @Override
    public void visitSoldier(Soldier soldier)
    {

    }

    @Override
    public void visitSergeant(Sergeant sergeant)
    {

    }

    @Override
    public void visitCommander(Commander commander)
    {
        System.out.println("Greetings, " + commander);
    }
}
