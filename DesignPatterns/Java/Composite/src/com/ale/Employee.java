package com.ale;

import java.util.ArrayList;
import java.util.List;

public class Employee {
    private String name;
    private String dept;
    private List<Employee> subordinates;

    public Employee(String name, String dept) {
        this.name = name;
        this.dept = dept;
        subordinates = new ArrayList<Employee>();
    }

    public void addSubordinates(Employee emp)
    {
        subordinates.add(emp);
    }

    public void removeSubordinates(Employee emp)
    {
        subordinates.remove(emp);
    }

    public List<Employee> getSubordinates()
    {
        return subordinates;
    }

    @Override
    public String toString() {
        return ("Employee - Name: " + name + " from department: " + dept);
    }
}
