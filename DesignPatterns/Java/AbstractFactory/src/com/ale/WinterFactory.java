package com.ale;

public class WinterFactory extends AbstractFactory {
    @Override
    public Clothes getClothes() {
        return new WinterOutfit();
    }

    @Override
    public Shoes getShoes() {
        return new WinterShoes();
    }
}
