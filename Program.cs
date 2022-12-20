
using System;

namespace Section_9;
public  class Person
{
    private string _name;
    private int _age;

    public Person(string name, int age)
    {
        SetName(name);
        SetAge(age);
        _name = name;
        _age = age;

    }
    public string GetName() => _name;
    public int GetAge() => _age;
    public void SetName(string name)
    {
        if (name == null || name == "" || name.Length > 32)
        {
            throw new Exception("Invalid name");
        }
        _name = name;
    }
    public void SetAge(int age)
    {
        if (age <= 0 || age > 128)
        {
            throw new Exception("Invalid age");
        }
        _age = age;
    }
    public virtual void Print()
    {
        Console.WriteLine
       ($"Name: {GetName()}, Age: {GetAge()}");
    }
}
public class Student : Person
{
    private int _year;
    private float _gpa;


    public int GetYear() => _year;
    public float GetGpa() => _gpa;

    public void SetYear(int year)
    {
        if(year<1 || year > 5)
        {
            throw new Exception("Invaild Year");
        }
        _year = year;
    }
    public void SetGpa(float gpa)
    {
        if (gpa< 0 || gpa > 4)
        {
            throw new Exception("Invaild GPA");
        }
        _gpa = gpa;
    }
    public Student(string name, int age, int year, float gpa) : base(name, age)
    {
        SetYear(year);
        SetGpa(gpa);
        _year = year;
        _gpa = gpa;
    }
    public override void Print()
    {
        Console.WriteLine
        ($"Name: {GetName()}, Age: {GetAge()}, Gpa: {GetGpa()}");
    }
}

public class Staff : Person
{
    private double _salary;
    private int _joinYear;
    

    
    
    public double GetSalary() => _salary;
    public int GetJoinYear() => _joinYear;
    public void SetSalary(double salary)
    {
        if (salary < 0 || salary > 120000)
        {
            throw new Exception("Invaild Salary");
        }
        _salary = salary;
    }
    public void SetJoinYear(int joinYear)
    {
        if(joinYear - GetAge()  < 21)
        {
            throw new Exception("Invaild JoinYear ");
        }
        _joinYear = joinYear;
    }

    public Staff(string name, int age, double salary, int joinyear) : base(name, age)
    {
        SetJoinYear(joinyear);
        SetSalary(salary);
        _salary = salary;
        _joinYear = joinyear;
    }
   
    public override void Print()
    {
        Console.WriteLine
        ($"Name: {GetName()}, Age: {GetAge()}, Salary: {GetSalary()} , JoinYear : {GetJoinYear()}");
    }

}
public class Database
{
    private int _currentIndex;
    public Person[] People = new Person[50];
    public void AddStudent(Student student)
    {
        People[_currentIndex++] = student;
    }
    public void AddStaff(Staff staff)
    {
        People[_currentIndex++] = staff;
    }
    public void AddPerson(Person person)
    {
        People[_currentIndex++] = person;
    }
    public void PrintAll()
    {
        for(int i = 0; i < _currentIndex; i++) { People[i].Print(); }
    }

}

public class Program
{
    private static void Main()
    {
        var database = new Database();

      
        
        Console.WriteLine("Enter an option\n1) add student:\n2) to add staff :\n3) add people :\n4) to print all:\n0) to stop:");
        var option = Convert.ToInt32(Console.ReadLine());
        while (true)
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine("Done !");
                    return;
                case 1:
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Age: ");
                    var age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Year: ");
                    var year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Gpa: ");
                    var gpa = Convert.ToSingle(Console.ReadLine());
                    try 
                    {
                        
                        var student = new Student(name, age, year, gpa);
                        database.AddStudent(student);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    Console.WriteLine("Enter option\n1--> add student: \n2--> to add staff :\n3--> add people :\n4--> to print all:\n0--> to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Slary: ");
                    var salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("JoinYear: ");
                    var joinyear = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        var staff = new Staff(name, age, salary, joinyear);
                        database.AddStaff(staff);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Enter option\n1--> add student: \n2--> to add staff :\n3--> add people :\n4--> to print all:\n0--> to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    var person = new Person(name, age);
                    database.AddPerson(person);
                    Console.WriteLine("Enter option\n1--> add student: \n2--> to add staff :\n3--> add people :\n4--> to print all:\n0--> to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        person = new Person(name, age);
                        database.AddPerson(person);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 4:
                    database.PrintAll();
                    Console.WriteLine("Enter option\n1--> add student: \n2--> to add staff :\n3--> add people :\n4--> to print all:\n0--> to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    break;
                
                default:
                    return;

            }
        }
            
    }
}



