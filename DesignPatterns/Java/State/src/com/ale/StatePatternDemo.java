package com.ale;

public class StatePatternDemo
{
    public static void main(String[] args)
    {
        Kitten kitty = new Kitten();
        kitty.observe();
        kitty.timePasses();
        kitty.observe();
        kitty.timePasses();
        kitty.observe();
    }
}
