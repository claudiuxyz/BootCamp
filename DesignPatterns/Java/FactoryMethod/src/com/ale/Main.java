package com.ale;

public class Main {

    public static void main(String[] args) {

        HtmlGenerator html = new HtmlGenerator();
        System.out.println("=============HTML File=============");
        html.NewDocument("Body of the HTML File");
        html.PrintDocument();

        XmlGenerator xml = new XmlGenerator();
        System.out.println("=============XML File=============");
        xml.NewDocument("Body of the XML File");
        xml.PrintDocument();

        TextGenerator text = new TextGenerator();
        System.out.println("=============Text File=============");
        text.NewDocument("Body of the Text File");
        text.PrintDocument();

    }
}
