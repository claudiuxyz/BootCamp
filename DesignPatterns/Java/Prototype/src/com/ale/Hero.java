package com.ale;

public class Hero extends Character {
    Hero() {
        m_clonesCount = 0;
    }

    public String ItemInLeftHand;
    public String ItemInRightHand;
    public String HelmetType;
    public String BootsType;
    public String ArmorType;

    @Override
    public Character CharacterClone() throws CloneNotSupportedException{
        m_clonesCount++;
        return (Hero)this.clone();
    }

    public Character createHero(){
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
        return "Name: " + "\t" + this.Name + "\n" +
                "Arms: " + "\t" + ItemInLeftHand + ", " + ItemInRightHand + "\n" +
                "Helmet: " + this.HelmetType + "\n" +
                "Boots: " + "\t" + this.BootsType + "\n" +
                "Armor: " + "\t" + this.ArmorType;
    }
}
