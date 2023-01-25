using Exam_Task.Classes;
using Exam_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Captain captain = new Captain("Tomas Frank");
            Captain captain1 = new Captain("James Smith");
            Battleship battleship = new Battleship("Titanik", 300, 150, 25, captain);

            IVessel target = new Battleship("Linkoln", 200, 100, 10, captain1);

            battleship.ToggleSonarMode();
            battleship.Attack(target);
            Console.WriteLine(battleship);
            Console.WriteLine(new String('=', 20));

            captain.AddVessel(battleship);
            Console.WriteLine(captain.Report());


            Console.ReadLine();
        }
    }
}
