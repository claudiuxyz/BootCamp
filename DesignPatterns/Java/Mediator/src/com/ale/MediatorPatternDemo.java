package com.ale;

public class MediatorPatternDemo
{
    public static void main(String[] args)
    {
        System.out.println("======= Party Members =======");
        Party party = new PartyImpl();
        Priest priest = new Priest();
        Wizard wizard = new Wizard();
        Hunter hunter = new Hunter();
        Rogue rogue = new Rogue();

        party.addMember(priest);
        party.addMember(wizard);
        party.addMember(hunter);
        party.addMember(rogue);

        System.out.println();
        System.out.println("======= ACTIONS =======");
        priest.act(Action.LOOKOUT);
        wizard.act(Action.TALE);
        rogue.act(Action.GOLD);
        hunter.act(Action.HUNT);
    }
}
