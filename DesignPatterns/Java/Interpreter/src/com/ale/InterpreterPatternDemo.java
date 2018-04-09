package com.ale;

import java.util.Scanner;

public class InterpreterPatternDemo
{
    public InterpreterContext ic;

    public InterpreterPatternDemo(InterpreterContext i)
    {
        this.ic = i;
    }

    public String interpret(String str)
    {
        Expression exp = null;
        if (str.contains("Hexadecimal"))
        {
            exp = new IntToHexExpression(Integer.parseInt(str.substring(0, str.indexOf(" "))));
        }else if (str.contains("Binary"))
        {
            exp = new IntToBinaryExpression(Integer.parseInt(str.substring(0,str.indexOf(" "))));
        }
        return exp.interpret(ic);
    }

    public static void main(String[] args)
    {
        String str1;

        System.out.println("Enter the string to be interpreted (in the format 'number Binary/Hexadecimal'): ");
        Scanner input = new Scanner(System.in);
        str1 = input.nextLine();

        InterpreterPatternDemo interp = new InterpreterPatternDemo(new InterpreterContext());
        System.out.println(str1 + " = " + interp.interpret(str1));
    }
}
