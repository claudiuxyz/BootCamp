package com.ale;

public class AutumnFactory extends AbstractFactory {
    @Override
    public Clothes getClothes() {
        return new AutumnOutfit();
    }

    @Override
    public Shoes getShoes() {
        return new AutumnShoes();
    }
}
