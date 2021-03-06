package com.ale;

public abstract class PartyMemberBase implements PartyMember
{
    protected Party party;

    @Override
    public abstract String toString();

    @Override
    public void joinedParty(Party party)
    {
        System.out.println(this + " joins the party");
        this.party = party;
    }

    @Override
    public void partyAction(Action action)
    {
        System.out.println("======> " + this + " " + action.getDescription());
    }

    @Override
    public void act(Action action)
    {
        if (party != null)
        {
            System.out.println(this + " " + action);
            party.act(this, action);
        }
    }
}
