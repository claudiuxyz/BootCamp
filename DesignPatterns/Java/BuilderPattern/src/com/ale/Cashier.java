package com.ale;

public class Cashier {
    private PizzaBuilder pizzaBuilder;

    public void setPizzaBuilder(PizzaBuilder pizzaBuilder) {
        this.pizzaBuilder = pizzaBuilder;
    }

    public Pizza getPizza() {
        return pizzaBuilder.getPizza();
    }

    public void MakePizza(){
        pizzaBuilder.makeNewPizza();
        pizzaBuilder.makeDough();
        pizzaBuilder.makeSauce();
        pizzaBuilder.addTopping();
        System.out.println(pizzaBuilder.getPizza());
    }
}
