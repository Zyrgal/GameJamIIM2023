using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestingWord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBool;

    [SerializeField] string word;
    [SerializeField] string letterToSearch;
    [SerializeField] string wordToSearch;

    public List<int> alreadyIndexChoosen;

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

    public void UI_TestEnum()
    {
        textBool.text = GetRandomEnum<EmployeeAccesory>().ToString();
    }

    public static bool SeachForALetter(string wordToSeachIn, string letterToSeach)
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

    public static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        int random = UnityEngine.Random.Range(0, A.Length);
        T V = (T)A.GetValue(random);
        return V;
    }

    public static void GetRandomEnum<T>(out T return1, out int return2,int excludedIndex = -1)
    {
        System.Array A = System.Enum.GetValues(typeof(T));

        int choosenID = -1;
        if (excludedIndex != -1)
        {
            choosenID = UnityEngine.Random.Range(0, A.Length);

            while (choosenID == excludedIndex)
            {
                choosenID = UnityEngine.Random.Range(0, A.Length);
            }
        }

        T V = (T)A.GetValue(choosenID);
        return1 = V;
        return2 = choosenID;
    }
}
