package com.ale;

public class SpellStrategy implements DragonSlayingStrategy
{
    @Override
    public void execute()
    {
        System.out.println("You cast the spell of disintegration and the dragon becomes a pile of dust.");
    }
}
