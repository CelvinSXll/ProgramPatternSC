using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPatternC
{
    class Program
    {
        static void Main(string[] args)
        {
            LineCook lineCook = new LineCook();
            HeadChef headChef = new HeadChef();
            GeneralManager generalManager = new GeneralManager();

            Employees employees= new Employees();
            employees.Attach(lineCook);
            employees.Attach(headChef);
            employees.Attach(generalManager);

            IncomeVisitor incomeVisitor = new IncomeVisitor();
            PaidTimeOffDays paidTimeOffDays = new PaidTimeOffDays();

            employees.Accept(incomeVisitor);
            employees.Accept(paidTimeOffDays);

            Console.ReadKey();


            

        }
    }

    interface IVisitor
    {
        void Visitor(Element element);
    }

    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    class Employee : Element
    {
        public string Name { get; set; }
        public double AnnualSalary { get; set; }
        public int PaidTimeOffDays { get; set; }

        public Employee(string name, double annualSalary, int paidTimeOffDays)
        {
            Name = name;
            AnnualSalary = annualSalary;
            PaidTimeOffDays = paidTimeOffDays;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visitor(this);
        }
    }

    class IncomeVisitor : IVisitor
    {
        public void Visitor(Element element)
        {
            Employee employee = element as Employee;
            employee.AnnualSalary *= 1.1;
            Console.WriteLine("{0}{1}'s new income:{2:C}", employee.GetType().Name, employee.Name, employee.AnnualSalary);
        }
    }
    class PaidTimeOffDays : IVisitor
    {
        public void Visitor(Element element)
        {
            Employee employee = element as Employee;
            employee.PaidTimeOffDays += 3;
            Console.WriteLine("{0}{1}'s new vacation days : {2}", employee.GetType().Name, employee.Name, employee.PaidTimeOffDays);
        }
    }

    class Employees
    {
        private List<Employee> _employees = new List<Employee>();
        public void Attach(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            _employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach(Employee e in _employees)
            {
                e.Accept(visitor);
            }
            Console.WriteLine();
        }


    }

    class LineCook :Employee
    {
        public LineCook() : base("Dimitri", 32000, 7) { }
    }

    class HeadChef :Employee
    {
        public HeadChef() : base("Jackson", 69015, 21) { }
    }

    class GeneralManager :Employee
    {
        public GeneralManager ():base("Amanda", 78000, 24) { }
    }

}
