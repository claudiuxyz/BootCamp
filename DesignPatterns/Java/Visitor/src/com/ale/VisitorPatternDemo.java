package com.ale;

public class VisitorPatternDemo
{
    public static void main(String[] args)
    {
        Commander commander = new Commander(new Sergeant(new Soldier(), new Soldier(), new Soldier()), new Sergeant(new Soldier(), new Soldier(), new Soldier()));
        commander.acceptVisitor(new SoldierVisitor());
        commander.acceptVisitor((new SergeantVisitor()));
        commander.acceptVisitor(new CommanderVisitor());
    }
}
