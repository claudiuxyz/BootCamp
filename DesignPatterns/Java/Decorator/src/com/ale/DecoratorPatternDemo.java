package com.ale;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class DecoratorPatternDemo {

    private static int choice;

    public static void main(String[] args) throws NumberFormatException, IOException {

        do{
            System.out.println("============ MENU ============");
            System.out.println("        1. Vegetarian Food \n");
            System.out.println("        2. Non-Vegetarian Food \n");
            System.out.println("        3. Chinese Food \n");
            System.out.println("        4. EXIT \n");
            System.out.print("Select an option: ");

            BufferedReader br= new BufferedReader(new InputStreamReader(System.in));
            choice = Integer.parseInt(br.readLine());

            switch (choice)
            {
                case 1:
                {
                    VeggieFood vf = new VeggieFood();
                    System.out.println(vf.prepareFood());
                    System.out.println("Price: " + vf.foodPrice());
                }
                break;

                case 2:
                {
                    Food nvf = new NonVegFood((Food) new VeggieFood());
                    System.out.println(nvf.prepareFood());
                    System.out.println("Total price: " + nvf.foodPrice());
                }
                break;

                case 3:
                {
                    Food cf = new ChineseFood((Food) new VeggieFood());
                    System.out.println(cf.prepareFood());
                    System.out.println("Total price: " + cf.foodPrice());
                }
                break;

                default:
                {
                    System.out.println("No other food choices available.");
                }
                return;
            }
        } while (choice != 4);
    }
}
