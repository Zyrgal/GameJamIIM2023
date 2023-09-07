using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataList : MonoBehaviour
{
    public static DataList instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
        }

        ResetList(savedLetterToSearchList, LetterToSearchList);
        ResetList(savedWordToSearchList, WordToSearchList);
        ResetList(savedFirstNameList, FirstNameList);
        ResetList(savedLastNameList, LastNameList);
        ResetList(savedDescriptionsList, DescriptionsList);
        ResetList(savedEntrepriseNameList, EntrepriseNameList);
        ResetList(savedClothList, ClothList);
        ResetList(savedAccessoryList, AccessoryList);
    }

    public void ResetList(List<string> listToReset, List<string> listToCopyFrom)
    {
        listToReset.Clear();
        for (int i = 0; i < listToCopyFrom.Count; i++)
        {
            listToReset.Add(listToCopyFrom[i]);
        }
    }

    public void Start()
    {
        
    }

    public void ResetAllList()
    {
        ResetList(LetterToSearchList, savedLetterToSearchList);
        ResetList(WordToSearchList, savedWordToSearchList);
        ResetList(FirstNameList, savedFirstNameList);
        ResetList(LastNameList, savedLastNameList);
        ResetList(DescriptionsList, savedDescriptionsList);
        ResetList(EntrepriseNameList, savedEntrepriseNameList);
        ResetList(ClothList, savedClothList);
        ResetList(AccessoryList, savedAccessoryList);
    }

    public List<string> LetterToSearchList;
    public List<string> WordToSearchList;
    public List<string> FirstNameList;
    public List<string> LastNameList;
    public List<string> DescriptionsList;
    public List<string> EntrepriseNameList;
    public List<string> ClothList;
    public List<string> AccessoryList;
    
    [HideInInspector] public List<string> savedLetterToSearchList = new List<string>();
    [HideInInspector] public List<string> savedWordToSearchList = new List<string>();
    [HideInInspector] public List<string> savedFirstNameList = new List<string>();
    [HideInInspector] public List<string> savedLastNameList = new List<string>();
    [HideInInspector] public List<string> savedDescriptionsList = new List<string>();
    [HideInInspector] public List<string> savedEntrepriseNameList = new List<string>();
    [HideInInspector] public List<string> savedClothList = new List<string>();
    [HideInInspector] public List<string> savedAccessoryList = new List<string>();

}
