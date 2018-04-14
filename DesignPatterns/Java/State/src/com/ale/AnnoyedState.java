package com.ale;

public class AnnoyedState implements State
{
    private Kitten cat;

    public AnnoyedState(Kitten cat)
    {
        this.cat = cat;
    }

    @Override
    public void onEnterState()
    {
        System.out.println(this.cat + " is starting to get irritated");
    }

    @Override
    public void observe()
    {
        System.out.println(this.cat + " is annoyed and starts scratching");
    }
}
