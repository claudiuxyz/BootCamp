package com.ale;

public class TextDecorator {
    private static TextDecorator m_textDecorator;
 //   private TextDecorator() {}

    public static TextDecorator Instance()
    {
        if ( m_textDecorator == null )
        {
            m_textDecorator = new TextDecorator();
        }
        return m_textDecorator;
    }

    public String UnderlineText ( String text, String cType )
    {
        return text + "\n" + new String(new char[text.length()]).replace("\0", cType) + "\n";
    }

    public String ListItemText ( String text, String cType )
    {
        return cType + text + "\n";
    }

    public String TextInBox(String text, String cType )
    {
        return  new String(new char[text.length() + 4]).replace("\0", cType) + "\n"
                + cType + ' ' + text + ' ' + cType + "\n"
                + new String(new char[text.length() + 4]).replace("\0", cType) + "\n" ;
    }

    public String FlankText ( String text, String cType )
    {
        return new String(new char[3]).replace("\0", cType) + text + new String(new char[3]).replace("\0", cType) + "\n";
    }
}
