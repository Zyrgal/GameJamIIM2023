using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EmployeePosManager : MonoBehaviour
{
    public static EmployeePosManager instance;

    [SerializeField] private int nbOfEmployeePos;
    [SerializeField] private float offsetFromLastPos;
    [SerializeField] private GameObject employeePosPrefab;

    private List<Vector3> employeePosList = new List<Vector3>();
    private Vector3 offset;
    private int employeePosIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        offset = new Vector3(1, 0, 0);


        for (int i = 0; i < nbOfEmployeePos; i++)
        {
            Vector3 newPos = gameObject.transform.position + offset;
            employeePosList.Add(newPos);
            offset += new Vector3(offsetFromLastPos,0);
        }

        SpawnEmployee();
    }

    public void SpawnEmployee()
    {
        EmployeeMovement employee = Instantiate(employeePosPrefab, new Vector3(5, 0), Quaternion.identity).GetComponent<EmployeeMovement>();
        employee.MoveTo(employeePosList[employeePosIndex]);
        employeePosIndex++;
    }
}
