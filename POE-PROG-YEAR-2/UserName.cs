using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UserName
{
    public String GetUsername()
    {
        Console.WriteLine("What is your name?");
        Console.WriteLine();
        String name = Console.ReadLine();

        Console.WriteLine("Welcome, " + name + ": ");
        Console.WriteLine("===================================================");
        return name;
        
    }
}
