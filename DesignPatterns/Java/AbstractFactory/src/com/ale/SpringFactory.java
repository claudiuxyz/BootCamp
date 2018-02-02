package com.ale;

public class SpringFactory extends AbstractFactory {
    @Override
    public Clothes getClothes() {
        return new SpringOutfit();
    }

    @Override
    public Shoes getShoes() {
        return new SpringShoes();
    }
}
