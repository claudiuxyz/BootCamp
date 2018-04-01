package com.ale;

public class ShapeDrawing { //facade class

    private Rectangle rectangle;
    private Square square;
    private Circle circle;

    public ShapeDrawing()
    {
        rectangle = new Rectangle();
        square = new Square();
        circle = new Circle();
    }

    public void drawRectangle()
    {
        rectangle.draw();
    }

    public void drawSquare()
    {
        square.draw();
    }

    public void drawCircle()
    {
        circle.draw();
    }
}
