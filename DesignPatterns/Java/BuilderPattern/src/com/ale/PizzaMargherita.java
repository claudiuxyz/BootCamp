package com.ale;

public class PizzaMargherita extends PizzaBuilder{
    @Override
    public void makeDough() {
        pizza.setDough("thin");
    }
    @Override
    public void makeSauce() {
        pizza.setSauce("tomato");
    }
    @Override
    public void addTopping() {
        pizza.setTopping("Mozzarella and Oregano");
    }
}
