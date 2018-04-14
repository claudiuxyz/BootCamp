package com.ale;

public class BrickHouse extends HouseTemplate
{
    @Override
    public void buildWalls()
    {
        System.out.println("Building Brick Walls");
    }

    @Override
    public void buildPillars()
    {
        System.out.println("Building Pillars of Bricks");
    }
}
