package com.ale;

public class ImmutableStew {

    private StewIngredients ingredients;

    public ImmutableStew(int numPotatoes, int numCarrots, int numOnions, int numPeppers)
    {
        ingredients = new StewIngredients(numPotatoes, numCarrots, numOnions, numPeppers);
    }

    public void mix()
    {
        System.out.println("While mixing the immutable vegetable stew, we find " + ingredients.getNumPotatoes() + " potatoes, "
                + ingredients.getNumCarrots() + " carrots, " + ingredients.getNumOnions() + " onions and " + ingredients.getNumPeppers() + " peppers");
    }

}
