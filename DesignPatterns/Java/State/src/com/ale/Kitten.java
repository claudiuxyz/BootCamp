package com.ale;

public class Kitten
{
    private State state;

    public Kitten()
    {
        state = new ChillState(this);
    }

    public void timePasses()
    {
        if (state.getClass().equals(ChillState.class))
        {
            changeStateTo(new AnnoyedState(this));
        }
        else
        {
            changeStateTo(new ChillState(this));
        }
    }

    private void changeStateTo(State newState)
    {
        this.state = newState;
        this.state.onEnterState();
    }

    @Override
    public String toString()
    {
        return "The kitten";
    }

    public void observe()
    {
        this.state.observe();
    }
}
