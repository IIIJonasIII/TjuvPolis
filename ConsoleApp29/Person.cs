using System;

namespace ConsoleApp29;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }


}

public class Polis : Person
{
    public string PolisBricka { get; set; }
}

public class Tjuv : Person
{
    public string Kofot { get; set; }
}

public class Civil : Person
{
    public string Plånbok { get; set; }
}

public class inventory
{
    public List<inventory> Items { get; set; }
    public list MyProperty { get; set; }


}
