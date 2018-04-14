package com.ale;

public class TemplateMethodDemo
{
    public static void main(String[] args)
    {
        HouseTemplate houseTemplate = new WoodenHouse();

        houseTemplate.buildHouse();
        System.out.println("#########################");

        houseTemplate = new BrickHouse();
        houseTemplate.buildHouse();
    }
}
