package com.ale;

public class PrivateClassDataPatternDemo {

    public static void main(String[] args)
    {	// stew is mutable
        Stew stew = new Stew(3, 4, 3, 2);
        stew.mix();
        stew.taste();
        stew.mix();

        //immutable stew protected with Private Class Data pattern
        ImmutableStew immutableStew =  new ImmutableStew(2,4,3,1);
        immutableStew.mix();
    }
}
