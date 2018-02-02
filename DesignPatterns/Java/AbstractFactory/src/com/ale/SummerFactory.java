package com.ale;

public class SummerFactory extends AbstractFactory {
    @Override
    public Clothes getClothes() {
        return new SummerOutfit();
    }

    @Override
    public Shoes getShoes() {
        return new SummerShoes();
    }
}
