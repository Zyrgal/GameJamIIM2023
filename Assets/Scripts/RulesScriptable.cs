using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[Serializable]
public struct RuleDoor
{
    public Rule rule;
    public EnumRule enumRule;
    public int id;
}

public class RulesScriptable : MonoBehaviour
{
    [SerializeField] public GameObject sheetPrefab;

    public static RuleFunc[] dailyRules = new RuleFunc[5] 
    { 
        new RuleFunc(EnumRule.letter,InitLetterRule,ValidateLetterRule,InitEmployeLetter),
        new RuleFunc(EnumRule.word,InitWordRule,ValidateWordRule,InitEmployeWord),
        new RuleFunc(EnumRule.entrepriseName,InitEntrepriseRule,ValidateEntrepriseRule,InitEmployeEntreprise),
        new RuleFunc(EnumRule.employeeCloth,InitClothingRule,ValidateClothingRule, InitEmployeClothing),
        new RuleFunc(EnumRule.employeeAccessory,InitAccessoryRule,ValidateAccessoryRule, InitEmployeAccessory)
    };

    [SerializeField] List<RuleDoor> rulesList = new List<RuleDoor>();

    [SerializeField] int employeeNbrToSpawn;
    [SerializeField] GameObject employeeToSpawn;
    [SerializeField] List<GameObject> employeeList;

    [SerializeField] int doorCount = 3;
    [SerializeField] int rulesCount = 3;

    [SerializeField] GameObject canvas;

    public void Start()
    {
        List<List<EnumRule>> listSelected = new List<List<EnumRule>>();

        for (int i = 0; i < doorCount; i++)
        {
            listSelected.Add(new List<EnumRule>());
        }

        for (int i = 0; i < rulesCount; i++)
        {
            var porte = new RuleDoor();
            porte.id = i % doorCount;
            porte.rule = new Rule();

            do
            {
                int randomRuleType = UnityEngine.Random.Range(0, 5);
                porte.enumRule = DefineRuleType(0);
            }
            while (listSelected[porte.id].Contains(porte.enumRule));

            listSelected[porte.id].Add(porte.enumRule);
            dailyRules[(int)porte.enumRule].initFunction(porte.rule);
            rulesList.Add(porte);
        }

        rulesList.Sort((a, b) => a.id - b.id);

        for (int i = 0; i < employeeNbrToSpawn; i++)
        {
            GameObject instantiateEmployee = Instantiate(employeeToSpawn.transform, new Vector3((-8 + (i * 1.125f)), 0, 0), Quaternion.identity).gameObject;
            employeeList.Add(instantiateEmployee);
            GameObject instantiateSheet = Instantiate(sheetPrefab, canvas.transform);
            instantiateEmployee.GetComponent<EmployeeData>().sheetData = instantiateSheet.GetComponent<SheetData>();
            int random = UnityEngine.Random.Range(0, rulesList.Count);
            dailyRules[(int)rulesList[random].enumRule].initEmployee(rulesList[random].rule, instantiateEmployee.GetComponent<EmployeeData>());
        }
    }

    public static void InitEmployeLetter(Rule rule, EmployeeData employee)
    {
        string employeeName = employee.employeeFirstname;
        bool isValid = false;


        employeeName = DataList.instance.savedFirstNameList[UnityEngine.Random.Range(0, DataList.instance.savedFirstNameList.Count)];

        while (!isValid)
        {
            if (employeeName.Contains(rule.letter.ToString()))
            {
                isValid = true;
            }
            else
            {
                employeeName = DataList.instance.savedFirstNameList[UnityEngine.Random.Range(0, DataList.instance.savedFirstNameList.Count)];
            }
        }
    }

    public static void InitEmployeWord(Rule rule, EmployeeData employee)
    {
        bool isValid = false;

        employee.employeeDescription = DataList.instance.savedDescriptionsList[UnityEngine.Random.Range(0, DataList.instance.savedDescriptionsList.Count)];

        while (!isValid)
        {
            if (employee.employeeDescription.Contains(rule.word.ToString()))
            {
                isValid = true;
            }
            else
            {
                employee.employeeDescription = DataList.instance.savedDescriptionsList[UnityEngine.Random.Range(0, DataList.instance.savedDescriptionsList.Count)];
            }
        }
    }

    public static void InitEmployeEntreprise(Rule rule, EmployeeData employee)
    {
        bool isValid = false;
        
        employee.employeeEntreprise = DataList.instance.savedEntrepriseNameList[UnityEngine.Random.Range(0, DataList.instance.savedEntrepriseNameList.Count)];

        while (!isValid)
        {
            if (employee.employeeEntreprise.Contains(rule.entrepriseName.ToString()))
            {
                isValid = true;
            }
            else
            {
                employee.employeeEntreprise = DataList.instance.savedEntrepriseNameList[UnityEngine.Random.Range(0, DataList.instance.savedEntrepriseNameList.Count)];
            }
        }
    }

    public static void InitEmployeClothing(Rule rule, EmployeeData employee)
    {
        bool isValid = false;
        
        employee.employeeCloth = DataList.instance.savedClothList[UnityEngine.Random.Range(0, DataList.instance.savedClothList.Count)];

        while (!isValid)
        {
            if (employee.employeeCloth.Contains(rule.employeeClothing.ToString()))
            {
                isValid = true;
            }
            else
            {
                employee.employeeCloth = DataList.instance.savedClothList[UnityEngine.Random.Range(0, DataList.instance.savedClothList.Count)];
            }
        }
    }

    public static void InitEmployeAccessory(Rule rule, EmployeeData employee)
    {
        bool isValid = false;
        
        employee.employeeAccessory = DataList.instance.savedAccessoryList[UnityEngine.Random.Range(0, DataList.instance.savedAccessoryList.Count)];

        while (!isValid)
        {
            if (employee.employeeAccessory.Contains(rule.employeeAccesory.ToString()))
            {
                isValid = true;
            }
            else
            {
                employee.employeeAccessory = DataList.instance.savedAccessoryList[UnityEngine.Random.Range(0, DataList.instance.savedAccessoryList.Count)];
            }
        }
    }

    public void UI_DebugRule()
    {
        //Debug.Log("rulePorteA letter = " + rulePorteA);
        /*Debug.Log("rulePorteA word = " + rulePorteA.word);
        Debug.Log("rulePorteA entreprise = " + rulePorteA.entrepriseName);
        Debug.Log("rulePorteA cloth = " + rulePorteA.employeeClothing);
        Debug.Log("rulePorteA accessory = " + rulePorteA.employeeAccesory);*/

        //Debug.Log("rulePorteB letter = " + rulePorteB);
        /*Debug.Log("rulePorteB word = " + rulePorteB.word);
        Debug.Log("rulePorteB entreprise = " + rulePorteB.entrepriseName);
        Debug.Log("rulePorteB cloth = " + rulePorteB.employeeClothing);
        Debug.Log("rulePorteB accessory = " + rulePorteB.employeeAccesory);*/

        //Debug.Log("rulePorteC letter = " + rulePorteC);
        /*Debug.Log("rulePorteC word = " + rulePorteC.word);
        Debug.Log("rulePorteC entreprise = " + rulePorteC.entrepriseName);
        Debug.Log("rulePorteC cloth = " + rulePorteC.employeeClothing);
        Debug.Log("rulePorteC accessory = " + rulePorteC.employeeAccesory);*/
    }

    public EnumRule DefineRuleType(int randomRuleType)
    {
        //return (EnumRule)randomRuleType;
        if (randomRuleType == 0)
        {
            return EnumRule.letter;
        }
        else if (randomRuleType == 1)
        {
            return EnumRule.word;
        }
        else if (randomRuleType == 2)
        {
            return EnumRule.entrepriseName;
        }
        else if (randomRuleType == 3)
        {
            return EnumRule.employeeCloth;
        }
        else if (randomRuleType == 4)
        {
            return EnumRule.employeeAccessory;
        }

        Debug.Log("Setting Rule issue");
        return EnumRule.letter;

    }

    public static void InitLetterRule(Rule rule)
    {
        int random = UnityEngine.Random.Range(0, DataList.instance.LetterToSearchList.Count);
        string choosen = DataList.instance.LetterToSearchList[random];
        DataList.instance.LetterToSearchList.Remove(choosen);
        rule.letter = choosen;
    }

    public static bool ValidateLetterRule(Rule rule, EmployeeData employee) 
    {
        string name = employee.employeeFirstname;
        if (name.Contains(rule.letter.ToString()))
        {
            return true;
        }
        return false;
    }

    public static void InitWordRule(Rule rule)
    {
        int random = UnityEngine.Random.Range(0, DataList.instance.WordToSearchList.Count);
        string choosen = DataList.instance.WordToSearchList[random];
        DataList.instance.WordToSearchList.Remove(choosen);
        rule.word = choosen;
    }

    public static bool ValidateWordRule(Rule rule, EmployeeData employee)
    {
        string name = employee.employeeDescription; // A voir pour remplacer par la description plutot 
        if (name.Contains(rule.word.ToString()))
        {
            return true;
        }
        return false;
    }

    public static void InitEntrepriseRule(Rule rule)
    {
        int random = UnityEngine.Random.Range(0, DataList.instance.EntrepriseNameList.Count);
        string choosen = DataList.instance.EntrepriseNameList[random];
        DataList.instance.EntrepriseNameList.Remove(choosen);
        Debug.Log("Entreprise Choosen = " + choosen);
        rule.entrepriseName = choosen;
    }

    public static bool ValidateEntrepriseRule(Rule rule, EmployeeData employee) //
    {
        string name = employee.employeeEntreprise;
        if (name.Contains(rule.entrepriseName.ToString()))
        {
            return true;
        }
        return false;
    }

    public static void InitClothingRule(Rule rule)
    {
        int random = UnityEngine.Random.Range(0, DataList.instance.ClothList.Count);
        string choosen = DataList.instance.ClothList[random];
        DataList.instance.ClothList.Remove(choosen);
        rule.employeeClothing = choosen;
    }

    public static bool ValidateClothingRule(Rule rule, EmployeeData employee) //
    {
        string name = employee.employeeCloth;
        if (name.Contains(rule.employeeClothing.ToString()))
        {
            return true;
        }
        return false;
    }

    public static void InitAccessoryRule(Rule rule)
    {
        int random = UnityEngine.Random.Range(0, DataList.instance.AccessoryList.Count);
        string choosen = DataList.instance.AccessoryList[random];
        DataList.instance.AccessoryList.Remove(choosen);
        rule.employeeAccesory = choosen;
    }

    public static bool ValidateAccessoryRule(Rule rule, EmployeeData employee)
    {
        string name = employee.employeeAccessory;
        if (name.Contains(rule.employeeAccesory.ToString()))
        {
            return true;
        }
        return false;
    }

    public void CheckChoosenDoor(List<InputSymbol> playerInput)
    {
        EmployeeData employee = employeeList[0].GetComponent<EmployeeData>();
        bool isValid = true;
        bool foundDoor = false;

        for (int i = 0; i < employee.allCombinaisons.Count; i++)
        {
            if (Enumerable.SequenceEqual(playerInput, employee.allCombinaisons[i]))
            {
                for (int j = 0; j < rulesList.Count; j++)
                {
                    if (rulesList[j].id == i)
                    {
                        isValid &= dailyRules[(int)rulesList[j].enumRule].validFunction(rulesList[j].rule, employee);
                    }
                }
                foundDoor = true;
                break;
            }
        }

        if (!foundDoor) //Garder
        {
            Debug.Log("Mauvaise combinaison");
            isValid = false; //Le joueur à tapé un mauvais mdp
        }

        if (isValid)
        {
            Debug.Log("Bonne porte");
            //La porte bonne porte
        }
        else
        {
            Debug.Log("Mauvaise porte");
            //La mauvaise
        }
    }
}
