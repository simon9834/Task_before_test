using System.Runtime.InteropServices;

Pantry pa = new Pantry(50, 30, 20);
int herbs;
int crystals;
int essencess;
int brewOfStrengthCount = 0;
int brewOfInvisibilityCount = 0;
Random ra = new Random();

Task supplies = Task.Run(() =>
{
    for (int i = 0; i < 10; i++)
    {
        herbs = ra.Next(0, 11);
        crystals = ra.Next(0, 11);
        essencess = ra.Next(0, 11);
        pa.refillMaterials(herbs, crystals, essencess);
    }
    Console.WriteLine("SUP all done");
});
await supplies;
Task witchCrafts = Task.Run(() =>
{
    bool res = true;
    for (int i = 0; i < 5; i++)
    {
        res = pa.brewStrengthPot();
        Console.WriteLine($"Witch done? : {res.ToString()}");
        if (res)
        {
            brewOfStrengthCount++;
        }
    }
    Console.WriteLine("WI all done");
});
await witchCrafts;
Task alchemistCrafting = Task.Run(() =>
{
    bool res = true;
    for (int i = 0; i < 4; i++)
    {
        res = pa.brewInvisPot();
        Console.WriteLine($"Alchemist done? : {res.ToString()}");
        if (res)
        {
            brewOfInvisibilityCount++;
        }
    }
    Console.WriteLine("AL1 all done");
});
await alchemistCrafting;
Task randomAlchemist = Task.Run(() =>
{
    bool res = true;
    int randomRoundNum = ra.Next(1, 11);
    for (int i = 0; i < randomRoundNum; i++)
    {
        if (ra.Next(0, 2) == 1)
        {
            res = pa.brewInvisPot();
            Console.WriteLine($"Alchemist done? : {res.ToString()}");
            if (res)
            {
                brewOfInvisibilityCount++;
            }
        }
        else
        {
            res = pa.brewStrengthPot();
            Console.WriteLine($"Alchemist done? : {res.ToString()}");
            if (res)
            {
                brewOfStrengthCount++;
            }
        }
    }
    Console.WriteLine("AL2 all done");
});

await Task.WhenAll(supplies, witchCrafts, alchemistCrafting, randomAlchemist);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"Strength potions count: {brewOfStrengthCount}!");
Console.WriteLine($"Invisibility potions count: {brewOfInvisibilityCount}!");
Console.WriteLine();
Console.WriteLine($"crystals: {pa.CrystalCount}, herbs: {pa.HerbCount}, essencess: {pa.EssencesCount}");


