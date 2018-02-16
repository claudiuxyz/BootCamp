package com.ale;

public class HtmlFile extends DocumentType {

    @Override
    public void SaveInfo(String info) {
        m_info = String.format("<!DOCTYPE html>\\n\" +\n" +
                "                \"<html>\\n\" +\n" +
                "                \"   <body>\" + body + \"\\n\" +\n" +
                "                \"   </body>\\n\" +\n" +
                "                \"</html>", info);
    }

    @Override
    public String GetDocType() {
        return "HTML";
    }
}
