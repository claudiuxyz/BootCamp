package com.ale;

public interface DispenseChain
{
    void setNextChain(DispenseChain nextChain);
    void dispense(Currency currency);
}
