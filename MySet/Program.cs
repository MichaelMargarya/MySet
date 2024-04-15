using MySet;
using System;
internal class Program
{
    static void Main(string[] args)
    {
        Sets<int> bazm = new Sets<int>();
        bazm.Add(1);
        bazm.Add(2);
        bazm.Add(3);
        bazm.Add(4);
        bazm.Add(5);
        bazm.Add(6);
        bazm.Add(7);
        bazm.Add(8);
        bazm.Add(9);
        Sets<int> ints = new Sets<int>();
       
        var result = bazm.Union(ints);
        foreach (int i in result)
        {
            Console.WriteLine(i);
        }
        var result2 = ints.Intersection(bazm);
        foreach (int j in result2)
        {
            Console.WriteLine(j);
        }
        var result3 = bazm.Difference(ints);
        foreach (var item in result3)
        {
            Console.WriteLine(item);
        }
        var result4 = ints.SymmetricDifference(bazm);
        foreach (var item in result4)
        {
            Console.WriteLine(item);
        }
    }
}