package com.ale;

public class Monster extends Character {
    Monster() {
        m_clonesCount = 0;
    }

    public String ClassType;
    public String Size;
    public String MagicSkills;

    @Override
    public Character CharacterClone() throws CloneNotSupportedException{
        m_clonesCount++;
        return (Monster)this.clone();
    }

    public Character createMonster(){
        try
        {
            return this.CharacterClone();
        } catch (CloneNotSupportedException e)
        {
            return null;
        }
    }

    @Override
    public String toString() {
        return "Name: " + "\t" + "\t" + this.Name + "\n" +
                "ClassType: " + "\t" + ClassType + "\n" +
                "Size: " + "\t" + "\t" + this.Size + "\n" +
                "MagicSkills: " + this.MagicSkills;
    }
}
