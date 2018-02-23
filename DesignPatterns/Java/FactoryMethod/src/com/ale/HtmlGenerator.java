package com.ale;

public class HtmlGenerator extends DocumentGenerator {
    @Override
    public DocumentType FactoryMethod() {
        return new HtmlFile();
    }
}
