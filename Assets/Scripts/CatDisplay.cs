using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatDisplay : MonoBehaviour
{
    public void UpdateCatText(double catcount, TextMeshProUGUI textToChange, string optionalEndText = null)
    {
        string[] suffixes = { "", "k", "M", "B", "T", "Q" };
        int index = 0;

        while (catcount >= 1000 && index < suffixes.Length - 1)
        {
            catcount /= 1000;
            index++;

            if (index >= suffixes.Length - 1 && catcount >= 1000)
            {
                break;
            }
        }

        string formattedText;

        if (index == 0)
        {
            formattedText = catcount.ToString();
        }
        else
        {
            formattedText = catcount.ToString("F1") + suffixes[index];
        }
        textToChange.text = formattedText + optionalEndText;


    }
}
