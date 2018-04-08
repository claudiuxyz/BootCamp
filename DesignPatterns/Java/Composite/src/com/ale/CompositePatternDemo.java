package com.ale;

public class CompositePatternDemo {

    public static void main(String[] args) {

        Employee CEO = new Employee("Crawly", "CEO");

        Employee headMarketing= new Employee("Carson", "Head Marketing");
        Employee headSales = new Employee("Branson", "Head Sales");

        Employee subordinate1 =  new Employee("Chris", "Sales");
        Employee subordinate2 =  new Employee("Mia", "Sales");
        Employee subordinate3 =  new Employee("Sara", "Marketing");
        Employee subordinate4 =  new Employee("Michael", "Marketing");

        CEO.addSubordinates(headSales);
        CEO.addSubordinates(headMarketing);

        headSales.addSubordinates(subordinate1);
        headSales.addSubordinates(subordinate2);
        headMarketing.addSubordinates(subordinate3);
        headMarketing.addSubordinates(subordinate4);

        System.out.println(CEO);
        for (Employee headEmployee : CEO.getSubordinates())
        {
            System.out.println("---> " + headEmployee);

            for (Employee subordinate : headEmployee.getSubordinates())
            {
                System.out.println("---------> " + subordinate);
            }
        }
    }
}
