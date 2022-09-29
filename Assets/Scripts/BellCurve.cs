using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellCurve
{
    private float mean;
    private float randomNumber;
    private int randomIndex = 0;
    private bool isPositive = false;

    public int GetProbability(int level, int max)
    {
        return BellCurveProbability(level, max);
    }

    private int BellCurveProbability(int level, int max)
    {
        mean = level / 100;
        randomNumber = UnityEngine.Random.Range(0f, 101f);

        if (mean > max)
        {
            mean = max;
        }

        do
        {
            if (randomNumber <= 68.27)
            {
                randomIndex = (int)System.MathF.Round(UnityEngine.Random.Range(mean - 1, mean + 1));
            }

            else if (68.27 < randomNumber && randomNumber < 99.73)
            {
                randomIndex = (int)System.MathF.Round(UnityEngine.Random.Range(mean - 2, mean + 2));
            }

            else if (randomNumber >= 99.73)
            {
                randomIndex = (int)System.MathF.Round(UnityEngine.Random.Range(mean - 3, mean + 3));
            }

            if (randomIndex < 0)
            {
                randomIndex = 0;
            }

            if (randomIndex > max)
            {
                randomIndex = max;
            }

            if (randomIndex >= 0 || randomIndex <= max)
            {
                isPositive = true;
            }
        } while (isPositive == false);

        return randomIndex;
    }
}
