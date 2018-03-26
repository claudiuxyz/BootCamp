package com.ale;

public class TextFile extends DocumentType {
    @Override
    public void SaveInfo(String info) {
        m_info = info;
    }

    @Override
    public String GetDocType() {
        return "TEXT";
    }
}
