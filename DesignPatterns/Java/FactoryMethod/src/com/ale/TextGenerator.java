package com.ale;

public class TextGenerator extends DocumentGenerator {
    @Override
    public DocumentType FactoryMethod() {
        return new TextFile();
    }
}
