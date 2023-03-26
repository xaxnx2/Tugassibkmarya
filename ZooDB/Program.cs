
class Animalidname
{
    public string _Name { get; set; }
    public string _Species { get; set; }
    public string _Gender { get; set; }
    public string _Amount { get; set; }
    public Animalidname(string name, string species, string gender, string amount)
     {
        _Name = name;
        _Species = species;
        _Gender = gender;
        _Amount = amount;

    }

    public void IDgiveback()
    {
        Console.WriteLine("Its weight is " + _Amount + " It is a " + _Gender + " " + _Species + " Named " + _Name);

    }

}

class Animalreturn : Animalidname
{

    public Animalreturn(string name, string species, string gender, string amount) : base(name, species, gender, amount)
    {
    }

}


class Animal 
{
    static String[] name = new string[2];
    static String[] species = new string[2];
    static String[] gender = new string[2];
    static String[] amount = new string[2];
    public static void Main()
    {
        for (int i = 0; i < 2; i++)
        {   
            Console.WriteLine("Enter Name?");
            name[i] = Console.ReadLine();
            Console.WriteLine("Enter species?");
            species[i] = Console.ReadLine();
            Console.WriteLine("Enter gender?");
            gender[i] = Console.ReadLine();
            Console.WriteLine("Enter Weight amount?");
            amount[i] = Console.ReadLine();
        }
        /*Animalidname animal1 = new Animalidname("bart", "dog", "male", "2");*/
        Animalreturn animal1 = new Animalreturn(name[0], species[0], gender[0] ,amount[0]);
        Animalreturn animal2 = new Animalreturn(name[1], species[1], gender[1], amount[1]);
        Animalidname[] animal = { animal1, animal2 };

        foreach(Animalidname animalidname in animal)
        {
           animalidname.IDgiveback();
        }
        
    }


}

