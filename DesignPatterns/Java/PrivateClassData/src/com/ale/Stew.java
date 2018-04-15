package com.ale;

public class Stew
{
    private int numPotatoes;
    private int numCarrots;
    private int numOnions;
    private int numPeppers;

    public Stew(int numPotatoes, int numCarrots, int numOnions, int numPeppers) {
        this.numPotatoes = numPotatoes;
        this.numCarrots = numCarrots;
        this.numOnions = numOnions;
        this.numPeppers = numPeppers;
    }

    public void ▓mix()
    {
        System.out.println("While mixing the vegetable stew, we find " + numPotatoes + " potatoes, "
                            + numCarrots + " carrots, " + numOnions + " onions and " + numPeppers + " peppers");
    }

    public void taste()
    {
        System.out.println("Tasting the stew");
        if (numPotatoes > 0)
        {
            numPotatoes--;
        }

        if (numPeppers > 0)
        {
            numPeppers--;
        }

        if (numCarrots > 0)
        {
            numCarrots--;
        }

        if (numOnions > 0)
        {
            numOnions--;
        }
    }
}
