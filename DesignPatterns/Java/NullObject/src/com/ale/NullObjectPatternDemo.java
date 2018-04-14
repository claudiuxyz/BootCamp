package com.ale;

public class NullObjectPatternDemo
{
    public static void main(String[] args)
    {
        AbstractCustomer customer1 = CustomerFactory.getCustomer("Mia");
        AbstractCustomer customer2 = CustomerFactory.getCustomer("Julie");
        AbstractCustomer customer3 = CustomerFactory.getCustomer("Ian");
        AbstractCustomer customer4 = CustomerFactory.getCustomer("Max");
        AbstractCustomer customer5 = CustomerFactory.getCustomer("Chris");
        AbstractCustomer customer6 = CustomerFactory.getCustomer("Kate");

        System.out.println("======= Customers =======");
        System.out.println(customer1.getName());
        System.out.println(customer2.getName());
        System.out.println(customer3.getName());
        System.out.println(customer4.getName());
        System.out.println(customer5.getName());
        System.out.println(customer6.getName());
    }
}
