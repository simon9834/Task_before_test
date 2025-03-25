public class Pantry
{
    private int herbCount;
    private int crystalCount;
    private int essencesCount;

    private int maxHerbCount;
    private int maxCrystalCount;
    private int maxEssences;

    public void refillMaterials(int herbs, int crystals, int essences)
    {
        if(checkMaterialMax(herbs, herbCount, maxHerbCount) &&
        checkMaterialMax(crystals, crystalCount, maxCrystalCount) &&
        checkMaterialMax(essences, essencesCount, maxEssences))
        {
            herbCount += herbs;
            crystalCount += crystals;
            essencesCount += essences;
        }
        else
        {
            Console.WriteLine("Ur delivery sadly exceeded our maximum storage space");
        }
    }
    public bool checkMaterialMax(int item, int baseItem, int itemMax)
    {
        if(baseItem + item <= itemMax)
        {
            return true;
        }
        return false;
    }
    public void brewInvisPot()
    {

    }
}