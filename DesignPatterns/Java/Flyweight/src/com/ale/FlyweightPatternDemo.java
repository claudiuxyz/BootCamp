package com.ale;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import com.ale.ShapeFactory.ShapeType;

public class FlyweightPatternDemo extends JFrame
{
    private final int WIDTH;
    private final int HEIGHT;

    private static final ShapeFactory.ShapeType shapes[] = {ShapeType.LINE, ShapeType.OVAL_FILL, ShapeType.OVAL_NOFILL};
    private static final Color colors[] = {Color.RED, Color.GREEN, Color.YELLOW};

    public FlyweightPatternDemo(int width, int height)
    {
        this.WIDTH = width;
        this.HEIGHT = height;
        Container contentPane = getContentPane();

        JButton startButoon = new JButton("Draw");
        final JPanel panel = new JPanel();

        contentPane.add(panel, BorderLayout.CENTER);
        contentPane.add(startButoon, BorderLayout.SOUTH);
        setSize(WIDTH, HEIGHT);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setVisible(true);

        startButoon.addActionListener(new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                Graphics g = panel.getGraphics();
                for (int i=0; i< 20; ++i)
                {
                    Shape shape = ShapeFactory.getShape(getRandomShape());
                    shape.draw(g, getRandomX(), getRandomY(), getRandomWidth(), getRandomHeight(), getRandomColor());
                }
            }
        });
    }

    private ShapeType getRandomShape()
    {
        return shapes[(int)(Math.random() * shapes.length)];
    }

    private int getRandomX()
    {
        return (int) (Math.random() * WIDTH);
    }

    private int getRandomY()
    {
        return (int) (Math.random() * HEIGHT);
    }

    private int getRandomWidth()
    {
        return (int) (Math.random() * (WIDTH / 10));
    }

    private int getRandomHeight()
    {
        return (int) (Math.random() * (HEIGHT / 10));
    }

    private Color getRandomColor()
    {
        return colors[(int) (Math.random() * colors.length)];
    }

    public static void main(String[] args)
    {
        FlyweightPatternDemo drawing = new FlyweightPatternDemo(500, 600);
    }
}
