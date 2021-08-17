using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opleidingsinstituut
{
    class Program
    {
        static void Main(string[] args)
        {
            // parameters
            double study;
            double lesson;
            double discount = 0;
            double lessonDiscount = 0;
            double cost = 0;

            int courseType = 0;
            int writeCount = 0;
            int oralCount = 0;
            int practiceCount = 0;

            bool free = false;

            DateTime age;
            DateTime now;

            List<string> courses = new List<string>();
            // data
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the registration date");
                    now = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Please enter your birth date");
                    age = Convert.ToDateTime(Console.ReadLine());
                    if (now < age){ break; }
                }
                catch (Exception) { Console.WriteLine("Invalid: please try again..."); }
            }
            while (true)
            {
                try
                {
                    courseType = 0;
                    Console.WriteLine("What is the name of the course?");
                    string cor = Console.ReadLine();
                    while (courseType < 1 || courseType > 3)
                    {
                        Console.WriteLine("What is the nature of the course? Type 1 for oral, Type 2 for writing, Type 3 for practice.");
                        courseType = Convert.ToInt32(Console.ReadLine());
                    }
                    if (courseType == 1) { oralCount++; }
                    else if (courseType == 2) { writeCount++; }
                    else if (courseType == 3) { practiceCount++; }
                    courses.Add(cor);

                    Console.WriteLine("Would you like to add another course?");
                    if (Console.ReadLine() == "no")
                    {
                        break;
                    }
                }
                catch (Exception) { Console.WriteLine("Invalid: please try again..."); }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Are you affiliated with the job center?");
                    if (Console.ReadLine() == "yes")
                    {
                        free = true;
                    }
                    break;
                }
                catch (Exception) { Console.WriteLine("Invalid: please try again..."); }
            }
            // math
            double totalDate = (now - age).TotalDays;
            lesson = (oralCount * 150) + (writeCount * 50) + (practiceCount * 50);
            if (free == true) { study = 0; }
            else { study = (oralCount * 50) + (writeCount * 50) + (practiceCount * 125); }
            if (oralCount + writeCount + practiceCount >= 5) { lessonDiscount = 5; lesson = lesson - (lesson / 100 * lessonDiscount); }
            if (totalDate > 6943) { discount = 2; }

            cost = lesson + study;
            cost = cost - (cost / 100 * discount);

            Console.WriteLine("The registation date is: " + now);
            Console.WriteLine("Your birthday is: " + age);
            Console.WriteLine("");
            Console.WriteLine("The discount for lessons is: " + lessonDiscount + "%.");
            Console.WriteLine("The cost for lessons is: " + lesson);
            Console.WriteLine("The cost for study materials is: " + study);
            Console.WriteLine("");
            Console.WriteLine("The discount overall is: " + discount + "%.");
            Console.WriteLine("The total cost is: " + cost);
            Console.WriteLine("");
            Console.WriteLine("Below here is a list of courses you ordered.");
            courses.ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    }
    // schriftelijk: lesgeld 50 euro, studiemateriaal 50 euro
    // mondelijk: lesgeld 150 euro, studiemateriaal 50 euro
    // praktijk: lesgeld 150 euro, studiemateriaal 125 euro
    // 5 of meer vakken: korting van 5% op lesgeld
    // jonger dan 19 jaar korting van 2% op totaal
    // als cursist dmv arbeidsbureau volgt, is studiemateriaal gratis
    // bedrag voor alle cursussen per cursist
    // leeftijd van cursist aan hand van geboortedatum en peildatum
}
