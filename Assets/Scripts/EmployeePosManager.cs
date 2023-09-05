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
    private List<EmployeeMovement> employeeList = new List<EmployeeMovement>();
    private Vector3 offset;
    private int employeePosIndex = 0;

    private void Awake()
    {
        instance = this;
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
    }

    public void SpawnEmployee()
    {
        EmployeeMovement employee = Instantiate(employeePosPrefab, new Vector3(5, 0), Quaternion.identity).GetComponent<EmployeeMovement>();
        employeeList.Add(employee);
        employee.MoveTo(employeePosList[employeePosIndex]);
        employeePosIndex++;
    }

    public void RemoveEmployee()
    {
        Destroy(employeeList[0].gameObject);
        employeeList.Remove(employeeList[0]);
        employeePosIndex--;

        for (int i = 0; i < employeeList.Count; i++)
        {
            employeeList[i].MoveTo(employeePosList[i]);
        }
    }
}
