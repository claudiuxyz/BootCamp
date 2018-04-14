package com.ale;

public abstract class HouseTemplate
{
    public final void buildHouse()
    {
        buildFoundation();
        buildPillars();
        buildWalls();
        buildWindows();
        System.out.println("House is built.");
    }

    //default implementation
    private void buildFoundation()
    {
        System.out.println("Building Foundation with cement, iron rods and dans");
    }

    //methods that will be implemented by subclasses
    public abstract void buildWalls();
    public abstract void buildPillars();

    //default implementation
    private void buildWindows()
    {
        System.out.println("Building Glass Windows");
    }
}

