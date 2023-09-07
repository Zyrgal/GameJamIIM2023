using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void InitDelegate(Rule rule);
public delegate void InitEmployeeDelegate(Rule rule, EmployeeData employeeData);
public delegate bool ValidateDelegate(Rule rule, EmployeeData employeeData);
public struct RuleFunc
{
    public EnumRule enumRules;
    public InitDelegate initFunction;
    public ValidateDelegate validFunction;
    public InitEmployeeDelegate initEmployee;

    public RuleFunc(EnumRule enumRules, InitDelegate initFunction, ValidateDelegate validFunction, InitEmployeeDelegate initEmployee)
    {
        this.enumRules = enumRules;
        this.initFunction = initFunction;
        this.validFunction = validFunction;
        this.initEmployee = initEmployee;
    }
}

[Serializable]
public class Rule
{
    public LetterToSeach letter;
    public WordToSeach word;
    public EntrepriseName entrepriseName;
    public EmployeeClothing employeeClothing;
    public EmployeeAccesory employeeAccesory;

    public override string ToString()
    {
        return $"{letter.ToString()} - {word.ToString()}";
    }
}
