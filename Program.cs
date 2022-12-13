
public abstract class Person
{
    public string Name;

    public int Age;
    
    public Person (string name , int age)
    {
        Name = name;
        Age = age;
    }
    public abstract void print();
} 
public class Staff: Person { 

    public double Salary;
    public int joinYear ;

    public Staff(string name, int age, double salary ,int joinYear):base(name,age)
    {
        Salary = salary;

    }
    public override void print()
    {
        Console.WriteLine($"My name is {Name} my age is {Age}+ my salary is {Salary} my joinyear is {joinYear}");
    }
}

