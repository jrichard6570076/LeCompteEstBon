// See https://aka.ms/new-console-template for more information
using LeCompteEstBon;
using System.Xml.Linq;


List<int> listnumbers = new List<int>() { 0,0,0,0,0 ,0};
Console.WriteLine("Here is numbers :");
for (int i =  0; i < listnumbers.Count; i++)
{ 
    Console.WriteLine($"Please enter the number  {i + 1}");
    int K = int.Parse(Console.ReadLine());
    listnumbers[i] = K;
}
Console.WriteLine("Please enter the number you want find");
int Number = int.Parse(Console.ReadLine());
while (Number != 0)
{
    GetBestResult result = new(listnumbers, Number);

    Console.WriteLine("Please enter the number you want find");
    Number = int.Parse(Console.ReadLine());
}


