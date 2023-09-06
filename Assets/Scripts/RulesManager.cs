using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RulesManager : MonoBehaviour
{
    public static RulesManager instance;
    [SerializeField] int employeeNbrToSpawn;
    [SerializeField] GameObject employeeToSpawn;

    private void Start()
    {
        for (int i = 0; i < employeeNbrToSpawn; i++)
        {
            Instantiate(employeeToSpawn.transform, new Vector3((-8 + (i * 1.125f)), 0, 0), Quaternion.identity);
        }
    }
}
