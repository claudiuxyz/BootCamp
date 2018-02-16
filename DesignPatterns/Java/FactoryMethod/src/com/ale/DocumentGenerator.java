package com.ale;

public abstract class DocumentGenerator {

    public abstract DocumentType FactoryMethod();
    private DocumentType m_document;

    public void NewDocument(String text){
        m_document = FactoryMethod();
        m_document.SaveInfo(text);
    }

    public void PrintDocument(){
        System.out.println(m_document.GetDocType());
        System.out.println(m_document.GetContent());
    }
}
