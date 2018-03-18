package com.ale;

public class UsageDefault {
    public void print()
    {
        System.out.println(TextDecorator.Instance().UnderlineText("Beginning of the paragraph", "*"));
        System.out.println(TextDecorator.Instance().ListItemText("Element 1", "o "));
        System.out.println(TextDecorator.Instance().ListItemText("Element 2", "o "));
        System.out.println(TextDecorator.Instance().ListItemText("Element 3", "o "));
        System.out.println(TextDecorator.Instance().TextInBox("The Box Text", "#"));
        System.out.println(TextDecorator.Instance().FlankText("END", "/"));
    }
}
