package com.ale;

public class ChineseFood extends FoodDecorator{
    public ChineseFood(Food newFood) {
        super(newFood);
    }

    @Override
    public String prepareFood() {
        return super.prepareFood() + " with fried noodles, tofu and sour-sweet sauce";
    }

    @Override
    public double foodPrice() {
        return super.foodPrice() + 17.5;
    }
}
