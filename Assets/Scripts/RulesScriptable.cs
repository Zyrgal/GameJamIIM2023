using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
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

    private int doorCount = 3;
    public int rulesCount = 3;
    public int spawnedEmployeeCount = 0;

    [SerializeField] GameObject canvas;
    [SerializeField] GameObject spawnPointSheet;

    public float spawnTimer;
    [SerializeField] float savedSpawnTimer;

    [SerializeField] List<TextMeshProUGUI> listRulesTMP = new List<TextMeshProUGUI>();

    string mergedString = null;
    string mergedString2 = null;
    string mergedString3 = null;
    string savedMergedString_1_Rule_1 = null;
    string savedMergedString_1_Rule_2 = null;
    string savedMergedString_1_Rule_3 = null;

    string savedMergedString_2_Rule_1 = null;
    string savedMergedString_2_Rule_2 = null;
    string savedMergedString_2_Rule_3 = null;

    string savedMergedString_3_Rule_1 = null;
    string savedMergedString_3_Rule_2 = null;
    string savedMergedString_3_Rule_3 = null;

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
                porte.enumRule = DefineRuleType(randomRuleType);
            }
            while (listSelected[porte.id].Contains(porte.enumRule));

            listSelected[porte.id].Add(porte.enumRule);
            dailyRules[(int)porte.enumRule].initFunction(porte.rule);

            string rule = null;
            string targetedThing = null;

            #region SetRuleSheetVisual
            if (porte.enumRule.ToString() == "letter")
            {
                rule = "FirstName or LastName must contains the letter => ";
                targetedThing = porte.rule.letter;
                if (i >= 0 && i <= 2)
                {
                    mergedString = rule + targetedThing;
                }
                else if (i >= 3 && i <= 5)
                {
                    mergedString = null;
                    mergedString2 = rule + targetedThing;
                }
                else if (i >= 6 && i <= 8)
                {
                    mergedString = null;
                    mergedString2 = null;
                    mergedString3 = rule + targetedThing;
                }
            }
            else if(porte.enumRule.ToString() == "word")
            {
                rule = "Description must contains the word => ";
                targetedThing = porte.rule.word;
                if (i >= 0 && i <= 2)
                {
                    mergedString = rule + targetedThing;
                }
                else if (i >= 3 && i <= 5)
                {
                    mergedString = null;
                    mergedString2 = rule + targetedThing;
                }
                else if (i >= 6 && i <= 8)
                {
                    mergedString = null;
                    mergedString2 = null;
                    mergedString3 = rule + targetedThing;
                }
            }
            else if (porte.enumRule.ToString() == "entrepriseName")
            {
                rule = "Service must be => ";
                targetedThing = porte.rule.entrepriseName;
                if (i >= 0 && i <= 2)
                {
                    mergedString = rule + targetedThing;
                }
                else if (i >= 3 && i <= 5)
                {
                    mergedString = null;
                    mergedString2 = rule + targetedThing;
                }
                else if (i >= 6 && i <= 8)
                {
                    mergedString = null;
                    mergedString2 = null;
                    mergedString3 = rule + targetedThing;
                }
            }
            else if (porte.enumRule.ToString() == "employeeCloth")
            {
                rule = "The employee must wear => ";
                targetedThing = porte.rule.employeeClothing;
                if (i >= 0 && i <= 2)
                {
                    mergedString = rule + targetedThing;
                }
                else if (i >= 3 && i <= 5)
                {
                    mergedString = null;
                    mergedString2 = rule + targetedThing;
                }
                else if (i >= 6 && i <= 8)
                {
                    mergedString = null;
                    mergedString2 = null;
                    mergedString3 = rule + targetedThing;
                }
            }
            else if (porte.enumRule.ToString() == "employeeAccessory")
            {
                rule = "The employee must wear => ";
                targetedThing = porte.rule.employeeAccesory;
                if (i >= 0 && i <= 2)
                {
                    mergedString = rule + targetedThing;
                }
                else if (i >= 3 && i <= 5)
                {
                    mergedString = null;
                    mergedString2 = rule + targetedThing;
                }
                else if (i >= 6 && i <= 8)
                {
                    mergedString = null;
                    mergedString2 = null;
                    mergedString3 = rule + targetedThing;
                }
            }

            if (i == 0)
            {
                savedMergedString_1_Rule_1 = mergedString;
                /*Debug.Log("1st = str 1 " + mergedString);
                Debug.Log("1st = str 2 " + mergedString2);
                Debug.Log("1st = str 3 " + mergedString3);*/
            }
            else if (i == 1)
            {
                savedMergedString_1_Rule_2 = mergedString;
            }
            else if (i == 2)
            {
                savedMergedString_1_Rule_3 = mergedString;
            }
            else if (i == 3)
            {
                savedMergedString_2_Rule_1 = mergedString2;
            }
            else if (i == 4)
            {
                savedMergedString_2_Rule_2 = mergedString2;
            }
            else if (i == 5)
            {
                savedMergedString_2_Rule_3 = mergedString2;
            }
            else if (i == 6)
            {
                savedMergedString_3_Rule_1 = mergedString3;
            }
            else if (i == 7) 
            {
                savedMergedString_3_Rule_2 = mergedString3;
            }
            else if (i == 8)
            {
                savedMergedString_3_Rule_3 = mergedString3;
            }

            if (i % doorCount == 0)
            {
                if (savedMergedString_3_Rule_1 != null)
                {
                    listRulesTMP[i % doorCount].text = "Rule to acces stage " + (porte.id + 1) + ": " + savedMergedString_1_Rule_1 + " and " + savedMergedString_2_Rule_1 + " and " + savedMergedString_3_Rule_1;
                }
                else if (savedMergedString_2_Rule_1 != null)
                {
                    listRulesTMP[i % doorCount].text = "Rule to acces stage " + (porte.id + 1) + ": " + savedMergedString_1_Rule_1 + " and " + savedMergedString_2_Rule_1;
                }
                else
                {
                    listRulesTMP[i % doorCount].text = "Rule to acces stage " + (porte.id + 1) + ": " + savedMergedString_1_Rule_1;
                }
            }
            else if (i % doorCount == 1)
            {
                if (savedMergedString_3_Rule_2 != null)
                {
                    listRulesTMP[i % doorCount].text = "Rule to acces stage " + (porte.id + 1) + ": " + savedMergedString_1_Rule_2 + " and " + savedMergedString_2_Rule_2 + " and " + savedMergedString_3_Rule_2;
                }
                else if (savedMergedString_2_Rule_2 != null)
                {
                    listRulesTMP[i % doorCount].text = "Rule to acces stage " + (porte.id + 1) + ": " + savedMergedString_1_Rule_2 + " and " + savedMergedString_2_Rule_2;
                }
                else
                {
                    listRulesTMP[i % doorCount].text = "Rule to acces stage " + (porte.id + 1) + ": " + savedMergedString_1_Rule_2;
                }
            }
            else if (i % doorCount == 2)
            {
                if (savedMergedString_3_Rule_3 != null)
                {
                    listRulesTMP[i % doorCount].text = "Rule to acces stage " + (porte.id + 1) + ": " + savedMergedString_1_Rule_3 + " and " + savedMergedString_2_Rule_3 + " and " + savedMergedString_3_Rule_3;
                }
                else if (savedMergedString_2_Rule_3 != null)
                {
                    listRulesTMP[i % doorCount].text = "Rule to acces stage " + (porte.id + 1) + ": " + savedMergedString_1_Rule_3 + " and " + savedMergedString_2_Rule_3;
                }
                else
                {
                    listRulesTMP[i % doorCount].text = "Rule to acces stage " + (porte.id + 1) + ": " + savedMergedString_1_Rule_3;
                }
            }
            #endregion

            rulesList.Add(porte);
        }

        rulesList.Sort((a, b) => a.id - b.id);

        savedSpawnTimer = spawnTimer;
        spawnTimer = 0;
        StartCoroutine(SpawnEmployee());
    }

    public IEnumerator SpawnEmployee()
    {
        yield return new WaitForSeconds(spawnTimer);
        GameObject instantiateEmployee = EmployeePosManager.instance.SpawnEmployee();
        employeeList.Add(instantiateEmployee);
        GameObject instantiateSheet = Instantiate(sheetPrefab, spawnPointSheet.transform.position, Quaternion.identity,canvas.transform);
        instantiateEmployee.GetComponent<EmployeeData>().sheetData = instantiateSheet.GetComponent<SheetData>();
        int random = UnityEngine.Random.Range(0, rulesList.Count);
        if (spawnedEmployeeCount == 0)
        {

            employeeList[0].GetComponent<EmployeeData>().sheetData.choosen = true;
            employeeList[0].GetComponent<EmployeeData>().sheetData.DisplaySheet();
            employeeList[0].GetComponent<EmployeeData>().alrdyChangedColor = true;
            employeeList[0].GetComponent<EmployeeData>().SetLayerActiveEmployee();
            employeeList[0].GetComponent<EmployeeData>().SetToWhiteColor();
        }
        spawnedEmployeeCount++;
        dailyRules[(int)rulesList[random].enumRule].initEmployee(rulesList[random].rule, instantiateEmployee.GetComponent<EmployeeData>());
        
        if (spawnedEmployeeCount < employeeNbrToSpawn)
        {
            spawnTimer = savedSpawnTimer;
            StartCoroutine(SpawnEmployee());
        }
    }

    public static void InitEmployeLetter(Rule rule, EmployeeData employee)
    {
        bool isValid = false;

        employee.employeeFirstname = DataList.instance.savedFirstNameList[UnityEngine.Random.Range(0, DataList.instance.savedFirstNameList.Count)];

        while (!isValid)
        {
            if (employee.employeeFirstname.Contains(rule.letter.ToString()) || employee.employeeLastname.Contains(rule.letter.ToString()))
            {
                isValid = true;
            }
            else
            {
                employee.employeeFirstname = DataList.instance.savedFirstNameList[UnityEngine.Random.Range(0, DataList.instance.savedFirstNameList.Count)];
                employee.employeeLastname = DataList.instance.savedLastNameList[UnityEngine.Random.Range(0, DataList.instance.savedLastNameList.Count)];
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
        string firstName = employee.employeeFirstname;
        string lastName = employee.employeeFirstname;
        if (firstName.Contains(rule.letter.ToString()) || lastName.Contains(rule.letter.ToString()))
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
            isValid = false; //Le joueur à tapé une combinaison qui ne correspond à aucune porte
            PatronGauge.Instance.BossAngriedGaugeImpact();
        }

        if (isValid)
        {
            Debug.Log("Bonne porte");
            PatronGauge.Instance.BossSatisfiedGaugeImpact();
            employeeList[0].GetComponent<EmployeeMovement>().MoveTo(new Vector3(EmployeePosManager.instance.employeePosList[EmployeePosManager.instance.employeePosList.Count - 1].position.x,
                                                                                                                            employeeList[0].transform.position.y),
                                                                                                                            true);
            EmployeePosManager.instance.RemoveEmployee();
        }
        else
        {
            Debug.Log("Mauvaise porte");
            if (foundDoor)
            {
                PatronGauge.Instance.BossAngriedGaugeImpact();
            }
        }
    }
}
