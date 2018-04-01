package com.ale;

public class VeggieFood implements Food {
    @Override
    public String prepareFood() {
        return "Stir fried vegetables";
    }

    @Override
    public double foodPrice() {
        return 12.0;
    }
}
