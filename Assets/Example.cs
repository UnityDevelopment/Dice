using UnityEngine;

public class Example : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        // Usage example - multiple dice
        int[] results = Dice.Roll(Dice.DieType.D4, 5, Dice.SortOrder.Descending);

        for (int i = 0; i < results.Length; i++)
        {
            Debug.Log(results[i].ToString());
        }

        // Usage example - single die
        // Debug.Log(Dice.RollDie(Dice.DieType.D12));
    }
}
