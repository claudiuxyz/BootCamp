package com.ale;

public class Main {

    public static void main(String[] args) {
        for (Seasons season : Seasons.values()) {
            AbstractFactory factory = FactoryProducer.getFactory(season);
            Clothes clothes = factory.getClothes();
            clothes.dress();

            Shoes shoes = factory.getShoes();
            shoes.putOnShoes();
        }
    }
}
