package com.ale;

public class XmlFile extends DocumentType {
    @Override
    public void SaveInfo(String info) {
        m_info = String.format("<?xml version=1.0 encoding=UTF-8?>\\n\" +\n" +
                "                \"   <note>\\n\" +\n" +
                "                \"   <to></to>\\n\" +\n" +
                "                \"   <from></from>\\n\" +\n" +
                "                \"   <heading></heading>\\n\" +\n" +
                "                \"   <body>\" + body + \"</body>\\n\" +\n" +
                "                \"</note>", info);
    }

    @Override
    public String GetDocType() {
        return "XML";
    }
}
