package com.ale;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {

        Hero theHero = new Hero();
        theHero.Name = "BraveMan";
        theHero.ItemInLeftHand = "ElfishShieldOrSomething";
        theHero.ItemInRightHand = "SharpestSword";
        theHero.Level = 111;
        theHero.ArmorType = "GreatestArmorAndVeryChic";
        theHero.HelmetType = "MagicHelmetNotSoFlattering";
        theHero.BootsType = "AppropriateForTheSeason";


        Monster theMonster = new Monster();
        theMonster.Name = "TheSuperDuperEvilMonsterAndAlsoUgly";
        theMonster.ClassType = "HideousBeast";
        theMonster.Level = 122;
        theMonster.MagicSkills = "SuperPowerfulPuzzleSolvingSkills";
        theMonster.Size = "HumongousSizeDoesNotMatter";

        List<Hero> armyOfBraveHeroes = new ArrayList<>();
        List<Monster> armyOfMeanMonsters = new ArrayList<>();


        for (int i = 0; i < 10; i++)
        {
            armyOfBraveHeroes.add((Hero)theHero.createHero());
            armyOfMeanMonsters.add((Monster) theMonster.createMonster());
        }

        System.out.println("=======Here comes the army of heroes=======");
        for (Hero hero : armyOfBraveHeroes)
        {
            System.out.println(hero);
            System.out.println("************************");
        }
        System.out.println(theHero.m_clonesCount);

        System.out.println("=======And the monsters. Boooooo=======");
        for (Monster monster : armyOfMeanMonsters)
        {
            System.out.println(monster);
            System.out.println("###########################");
        }
        System.out.println(theMonster.m_clonesCount);

    }
}
