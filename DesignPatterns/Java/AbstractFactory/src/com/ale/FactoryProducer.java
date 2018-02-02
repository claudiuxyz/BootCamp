package com.ale;

public class FactoryProducer {
    public static AbstractFactory getFactory(Seasons season){
        switch (season) {
            case SPRING:
                return new SpringFactory();
            case SUMMER:
                return new SummerFactory();
            case AUTUMN:
                return new AutumnFactory();
            case WINTER:
                return new WinterFactory();
            default:
                return null;
        }
    }
}
