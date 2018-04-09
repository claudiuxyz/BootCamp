package com.ale;

public class StewIngredients
{
    private int numPotatoes;
    private int numCarrots;
    private int numOnions;
    private int numPeppers;

    public StewIngredients(int numPotatoes, int numCarrots, int numOnions, int numPeppers) {
        this.numPotatoes = numPotatoes;
        this.numCarrots = numCarrots;
        this.numOnions = numOnions;
        this.numPeppers = numPeppers;
    }

    public int getNumPotatoes() {
        return numPotatoes;
    }

    public int getNumCarrots() {
        return numCarrots;
    }

    public int getNumOnions() {
        return numOnions;
    }

    public int getNumPeppers() {
        return numPeppers;
    }
}
