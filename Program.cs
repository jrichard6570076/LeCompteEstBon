// See https://aka.ms/new-console-template for more information
using LeCompteEstBon;
using System.Xml.Linq;
using System.Text.RegularExpressions;

List<int> listnumbers = new List<int>() { 0,0,0,0,0 ,0};
Console.WriteLine("Here is numbers :");
for (int i =  0; i < listnumbers.Count; i++)
{ 
    Console.WriteLine($"Please enter the number  {i + 1}");
    string K = Console.ReadLine();
    string pattern = @"^(1|2|3|4|5|6|7|8|9|10|25|50|75|100)$";
    Regex regex = new Regex(pattern);

    while (!regex.IsMatch(K))
    {
        Console.WriteLine($"Wrong number please enter the number  {i + 1}");
        K = Console.ReadLine();
    }
    listnumbers[i] = int.Parse(K);
}
Console.WriteLine("Please enter the number you want find");
int Number = int.Parse(Console.ReadLine());


// Create a Regex object

while (Number != 0)
{
    GetBestResult result = new(listnumbers, Number);

    Console.WriteLine("Please enter the number you want find");
    Number = int.Parse(Console.ReadLine());
}


