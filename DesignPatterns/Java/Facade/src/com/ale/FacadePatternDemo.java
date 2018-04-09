package com.ale;

public class FacadePatternDemo {

    public static void main(String[] args) {

        ShapeDrawing drawing = new ShapeDrawing();

        drawing.drawRectangle();
        drawing.drawSquare();
        drawing.drawCircle();
    }
}
