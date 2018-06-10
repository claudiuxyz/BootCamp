package com.ale;

public class Orcs implements WeatherObserver
{
    @Override
    public void update(WeatherType currentWeather)
    {
        switch(currentWeather)
        {
            case COLD:
                System.out.println("The orcs are freezing.");
                break;
            case SUNNY:
                System.out.println("The sun hurts the orcs' eyes.");
                break;
            case RAINY:
                System.out.println("The orcs are dripping wet.");
                break;
            case WINDY:
                System.out.println("The orc enjoy the windy weather.");
                break;
            default:
                break;
        }
    }
}
