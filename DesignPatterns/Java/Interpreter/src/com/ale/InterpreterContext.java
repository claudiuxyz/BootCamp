package com.ale;

public class InterpreterContext
{
    public String getBinaryFormat(int i)
    {
        return Integer.toBinaryString(i);
    }

    public String getHexazecimalFormat(int i)
    {
        return Integer.toHexString(i);
    }
}
