public class Pantry
{
    private int herbCount;
    private int crystalCount;
    private int essencesCount;

    public int HerbCount
    {
        get { return herbCount; }
        set { herbCount = value; }
    }

    public int CrystalCount
    {
        get { return crystalCount; }
        set { crystalCount = value; }
    }

    public int EssencesCount
    {
        get { return essencesCount; }
        set { essencesCount = value; }
    }

    private int maxHerbCount;
    private int maxCrystalCount;
    private int maxEssences;
    private readonly object lockObj = new object();

    public Pantry(int maxHerbCount, int maxCrystalCount, int maxEssences)
    {
        this.maxHerbCount = maxHerbCount;
        this.maxCrystalCount = maxCrystalCount;
        this.maxEssences = maxEssences;
    }

    public void refillMaterials(int herbs, int crystals, int essences)
    {
        lock (lockObj)
        {
            if (checkMaterialMax(herbs, herbCount, maxHerbCount) &&
            checkMaterialMax(crystals, crystalCount, maxCrystalCount) &&
            checkMaterialMax(essences, essencesCount, maxEssences))
            {
                herbCount += herbs;
                crystalCount += crystals;
                essencesCount += essences;
                Console.WriteLine("done delivery");
            }
            else
            {
                Console.WriteLine("Ur delivery sadly exceeded our maximum storage space");
            }
        }
    }
    private bool checkMaterialMax(int item, int baseItem, int itemMax)
    {
        if (baseItem + item <= itemMax)
        {
            return true;
        }
        return false;
    }
    public bool brewInvisPot()
    {
        lock (lockObj)
        {
            if (checkAvailability(herbCount, 2) &&
        checkAvailability(crystalCount, 3) &&
        checkAvailability(essencesCount, 2))
            {
                substractItemsForPot(ref herbCount, 2);
                substractItemsForPot(ref crystalCount, 3);
                substractItemsForPot(ref essencesCount, 2);
                return true;
            }
            return false;
        }
    }
    public bool brewStrengthPot()
    {
        lock (lockObj)
        {
            if (checkAvailability(herbCount, 5) &&
        checkAvailability(crystalCount, 2) &&
        checkAvailability(essencesCount, 1))
            {
                substractItemsForPot(ref herbCount, 5);
                substractItemsForPot(ref crystalCount, 2);
                substractItemsForPot(ref essencesCount, 1);
                return true;
            }
            return false;
        }
    }
    private bool checkAvailability(int item, int desiredCountOfItem)
    {
        if (item >= desiredCountOfItem) return true;
        return false;
    }
    private void substractItemsForPot(ref int item, int substractCount)
    {
        item -= substractCount;
    }
}