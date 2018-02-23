package com.ale;

public class XmlGenerator extends DocumentGenerator {
    @Override
    public DocumentType FactoryMethod() {
        return new XmlFile();
    }
}
