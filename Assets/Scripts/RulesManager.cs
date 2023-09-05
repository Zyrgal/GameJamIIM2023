using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RulesManager : MonoBehaviour
{
    public static RulesManager instance;

    [SerializeField] private TextMeshProUGUI textBool;

    [SerializeField] string word;
    [SerializeField] string letterToSearch;
    [SerializeField] string wordToSearch;

    public void UI_ResetText()
    {
        textBool.text = null;
    }

    public void UI_TestLetter()
    {
        textBool.text = SeachForALetter(word, letterToSearch).ToString();
    }

    public void UI_TestWord()
    {
        textBool.text = SeachForAWord(word, wordToSearch).ToString();
    }

    private bool SeachForALetter(string wordToSeachIn, string letterToSeach)
    {
        if (wordToSeachIn.Contains(letterToSeach))
        {
            return true;
        }
        return false;
    }

    private bool SeachForAWord(string wordToSeachIn, string wordToSeach)
    {
        if (wordToSeachIn.Contains(wordToSeach))
        {
            return true;
        }
        return false;
    }
}
