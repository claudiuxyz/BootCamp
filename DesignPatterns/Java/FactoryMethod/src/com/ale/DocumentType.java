package com.ale;

public abstract class DocumentType {
    protected String m_info;
    public abstract void SaveInfo(String info);
    public abstract  String GetDocType();
    public String GetContent(){
        return m_info;
    }
}
