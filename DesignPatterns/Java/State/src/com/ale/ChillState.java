package com.ale;

public class ChillState implements State
{
    private Kitten cat;

    public ChillState(Kitten cat)
    {
        this.cat = cat;
    }

    @Override
    public void onEnterState()
    {
        System.out.println(this.cat + " is calming down");
    }

    @Override
    public void observe()
    {
        System.out.println(this.cat + " is chill and takes a nap in the sun");
    }
}
