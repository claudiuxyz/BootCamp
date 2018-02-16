package com.ale;

public class PizzaFunghiProsciutto extends PizzaBuilder{
    @Override
    public void makeDough() {
        pizza.setDough("thick");
    }
    @Override
    public void makeSauce() {
        pizza.setSauce("tomato");
    }
    @Override
    public void addTopping() {
        pizza.setTopping("Mozzarella, Mushrooms, Prosciutto and Oregano");
    }
}
