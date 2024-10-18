using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntegerHelper
{
    public static string ConvertPrizeToText(int value)
    {
        return (value >= 100000 && value % 100000 == 0) ? (value / 100000 > 1 ? value / 100000 + " Lakhs" : value / 100000 + " Lakh") : value.ToString();
    }
}
