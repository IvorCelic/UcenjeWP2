

// Test 01
//Console.Write("Ime: ");
//string FirstName = Console.ReadLine();

//Console.Write("Prezime: ");
//string LastName = Console.ReadLine();

//Console.WriteLine("Zovem se " + FirstName + " " + LastName);



// Test 02 - CM to MM converter
//Console.WriteLine("CM: ");
//float Centimeters = float.Parse(Console.ReadLine());

//Console.WriteLine("Result: " + Centimeters * 10 + " mm");



// Test 03 - Kalkulator

    Console.WriteLine("Odaberite broj od 1 do 4.");
    Console.WriteLine(" "); 
    Console.WriteLine("Za zbrajanje birajte 1");
    Console.WriteLine("Za oduzimanje birajte 2");
    Console.WriteLine("Za množenje birajte 3");
    Console.WriteLine("Za dijeljenje birajte 4");
        int operation = int.Parse(Console.ReadLine());

    Console.WriteLine("Upišite prvi broj: ");
        int First = int.Parse(Console.ReadLine());

    Console.WriteLine("Upišite drugi broj: ");
        int Second = int.Parse(Console.ReadLine());
    Console.WriteLine("Rezultat: "); 

    var Add = First + Second;
    var Subtract = First - Second;
    var Multiply = First * Second;
    var Divide = First / Second;

    if (operation == 1)
    {
    Console.WriteLine(Add);
    }
    else if (operation == 2)
    {
    Console.WriteLine(Subtract);
    }
    else if (operation == 3)
    {
        Console.WriteLine(Multiply);
    }
    else if (operation == 4)
    {
        Console.WriteLine(Divide);
    }
    else { Console.WriteLine("Greška"); }