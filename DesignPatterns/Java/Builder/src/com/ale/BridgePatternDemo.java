package com.ale;

public class BridgePatternDemo {

    public static void main(String[] args) {

        Shape circle = new Circle(new RedColor());
        circle.applyColor();
        Shape square = new Square(new GreenColor());
        square.applyColor();
        Shape pentagon = new Pentagon(new BlueColor());
        pentagon.applyColor();
    }
}
