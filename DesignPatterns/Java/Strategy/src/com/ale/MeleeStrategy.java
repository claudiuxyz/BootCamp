package com.ale;

public class MeleeStrategy implements DragonSlayingStrategy
{
    @Override
    public void execute()
    {
        System.out.println("With your Excalibur you sever the head of the dragon.");
    }
}
