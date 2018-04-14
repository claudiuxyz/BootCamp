package com.ale;

public class SergeantVisitor implements UnitVisitor {
    @Override
    public void visitSoldier(Soldier soldier)
    {

    }

    @Override
    public void visitSergeant(Sergeant sergeant)
    {
        System.out.println("Greetings, " + sergeant);
    }

    @Override
    public void visitCommander(Commander commander)
    {

    }
}
