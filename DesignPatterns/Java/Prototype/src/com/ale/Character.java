package com.ale;

public abstract class Character implements Cloneable{
        public String Name;
        public int Level;
        public abstract Character CharacterClone() throws CloneNotSupportedException;
        protected int m_clonesCount;
}
