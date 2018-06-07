package com.ale;

import java.util.Scanner;

public class ATMDispenseChain
{
    private DispenseChain c1;

    public ATMDispenseChain()
    {
        //initialize the chain
        this.c1 = new dispenser100Lei();
        DispenseChain c2 = new dispenser50Lei();
        DispenseChain c3 = new dispenser10Lei();

        //set the chain of responsibility
        c1.setNextChain(c2);
        c2.setNextChain(c3);
    }

    public static void main(String[] args)
    {
        ATMDispenseChain atm = new ATMDispenseChain();
        while(true)
        {
            int amount;
            System.out.println("Enter the amount that you want to withdraw: ");
            Scanner input = new Scanner(System.in);
            amount = input.nextInt();

            if (amount % 10 != 0)
            {
                System.out.println("Please enter an amount multiple with 10.");
                return;
            }
            atm.c1.dispense(new Currency(amount));
        }
    }
}