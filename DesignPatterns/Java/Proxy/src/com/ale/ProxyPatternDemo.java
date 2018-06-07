package com.ale;

public class ProxyPatternDemo {

    public static void main(String[] args)
    {
        Image image = new ProxyImage("test_image.jpg");

        image.display(); //image will be loaded from disk
        System.out.println("");

        image.display();//image will not be loaded from disk
    }
}
