package com.ale;

public class PizzaQuatroFormaggi extends PizzaBuilder{
    @Override
    public void makeDough() {
        pizza.setDough("crusty");
    }
    @Override
    public void makeSauce() {
        pizza.setSauce("tomato");
    }
    @Override
    public void addTopping() {
        pizza.setTopping("Mozzarella, Parmezan, Gorgonzola and Pecorino ");
    }
}

