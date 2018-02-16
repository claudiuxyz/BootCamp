package com.ale;

public class OrderPizza {
    public static void main(String[] args) {
        Cashier order = new Cashier();

        PizzaBuilder funghiProsciutto   = new PizzaFunghiProsciutto();
        PizzaBuilder margherita         = new PizzaMargherita();
        PizzaBuilder quatroFormaggi     = new PizzaQuatroFormaggi();
        PizzaBuilder vegetaria          = new PizzaVegetaria();

        order.setPizzaBuilder(quatroFormaggi);
        order.MakePizza();
       // Pizza pizza = order.getPizza();

    }
}
