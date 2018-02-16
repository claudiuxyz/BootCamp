package com.ale;

public class PizzaVegetaria extends PizzaBuilder{
    @Override
    public void makeDough() {
        pizza.setDough("thin");
    }
    @Override
    public void makeSauce() {
        pizza.setSauce("sweet");
    }
    @Override
    public void addTopping() {
        pizza.setTopping("Mozzarella, Onions, Olives, Mushrooms, Corn");
    }
}
