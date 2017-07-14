using System;

public class Dice
{
    /// <summary>
    /// The minimum value of any DieType
    /// </summary>
    private const int MinimumDieValue = 1;


    /// <summary>
    /// Instance of Random to save on performance
    /// </summary>
    private static Random _random = null;
    

    /// <summary>
    /// Default constructor
    /// </summary>
    static Dice()
    {
        if (_random == null)
        {
            _random = new Random();
        }
    }


    /// <summary>
    /// Die types, values represent the number of faces and maximum value
    /// </summary>
    public enum DieType { D4 = 4, D6 = 6, D8 = 8, D10 = 10, D12 = 12, D20 = 20 };
    
    /// <summary>
    /// The order in which the dice roll results are returned
    /// </summary>
    public enum SortOrder { Ascending, Descending };


    /// <summary>
    /// Returns the value from a single rolled die of the specified type
    /// </summary>
    /// <param name="dieType">The type of die rolled</param>
    /// <returns>int</returns>
    public static int RollDie(DieType dieType)
    {
        int result = 0;
        int max = (int)dieType;

        result = GetRandomNumber(MinimumDieValue, max);

        return result;
    }

    /// <summary>
    /// Returns the values from the number of specified dice, of the specified type
    /// </summary>
    /// <param name="dieType">The type of die rolled</param>
    /// <param name="numberOfDice">The number of dice to be rolled</param>
    /// <returns>int[]</returns>
    public static int[] Roll(DieType dieType, int numberOfDice)
    {
        int[] results = new int[numberOfDice];

        for (int i = 0; i < numberOfDice; i++)
        {
            results[i] = RollDie(dieType);
        }

        return results;
    }

    /// <summary>
    /// Returns the values from the number of specified dice, of the specified type.  Results are sorted in the specified sort order.
    /// </summary>
    /// <param name="dieType">The type of die rolled</param>
    /// <param name="numberOfDice">The number of dice to be rolled</param>
    /// <param name="sortOrder">The order to sort the results in the returned array</param>
    /// <returns>int[]</returns>
    public static int[] Roll(DieType dieType, int numberOfDice, SortOrder sortOrder)
    {
        int[] results = Roll(dieType, numberOfDice);

        results = Sort(results, sortOrder);

        return results;
    }

    /// <summary>
    /// Returns a newly created "random" number between min and max
    /// </summary>
    /// <param name="min">The minimum value</param>
    /// <param name="max">The maximum value (inclusive)</param>
    /// <returns>int</returns>
    private static int GetRandomNumber(int min, int max)
    {
        return _random.Next(min, max + 1);
    }

    /// <summary>
    /// Sorts the specified int array by the specified sort order
    /// </summary>
    /// <param name="results">The array of dice results to sort</param>
    /// <param name="sortOrder">The order in which to sort the array</param>
    /// <returns>Array</returns>
    /// <remarks>An ArgumentNullException will be thrown if the specified array is null</remarks>
    private static int[] Sort(int[] results, SortOrder sortOrder)
    {
        switch (sortOrder)
        {
            case SortOrder.Ascending:
                Array.Sort<int>(results, new Comparison<int>((i1, i2) => i1.CompareTo(i2)));
                break;
            case SortOrder.Descending:
                Array.Sort<int>(results, new Comparison<int>((i1, i2) => -i1.CompareTo(i2)));
                break;
        }

        return results;
    }
}
