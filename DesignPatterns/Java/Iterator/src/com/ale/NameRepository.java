package com.ale;

public class NameRepository implements Container
{
    public String names[] = {"Robert", "Julie", "Chris", "Lora", "Kate"};

    @Override
    public Iterator getIterator() {
        return new NameIterator();
    }

    private class NameIterator implements Iterator
    {
        int index;

        @Override
        public boolean hasNext()
        {
            if (index < names.length)
            {
                return true;
            }
            return false;
        }

        @Override
        public Object next()
        {
            if (this.hasNext())
            {
                return names[index++];
            }
            return null;
        }
    }
}
