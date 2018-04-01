package com.ale;

public class NonVegFood extends FoodDecorator
{
    public NonVegFood(Food newFood) {
        super(newFood);
    }

    @Override
    public String prepareFood() {
        return super.prepareFood() + " with roasted chicken and curry chicken";
    }

    @Override
    public double foodPrice() {
        return super.foodPrice() + 15.5;
    }
}
