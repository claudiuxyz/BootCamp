package com.ale;

public class ObserverPatternDemo
{
    public static void main(String[] args)
    {
        Weather weather = new Weather();
        weather.addObserver(new Hobbits());
        weather.addObserver(new Orcs());

        System.out.println("Current weather: " + weather.getCurrentWeather());
        weather.timePasses();
        weather.timePasses();
        weather.timePasses();
        weather.timePasses();
    }
}
