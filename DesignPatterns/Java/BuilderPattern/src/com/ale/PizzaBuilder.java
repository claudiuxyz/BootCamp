package com.ale;

abstract class PizzaBuilder {

    protected Pizza pizza;

    public Pizza getPizza() {
        return pizza;
    }

    public void makeNewPizza(){
        pizza = new Pizza();
    }

    public abstract void makeDough();
    public abstract void makeSauce();
    public abstract void addTopping();

}
