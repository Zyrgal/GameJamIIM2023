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

    [SerializeField] private List<Transform> employeePosList = new List<Transform>();
    private List<EmployeeMovement> employeeList = new List<EmployeeMovement>();
    private Vector3 offset;
    private int employeePosIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnEmployee()
    {
        EmployeeMovement employee = Instantiate(employeePosPrefab, new Vector3(-10, 0), Quaternion.identity).GetComponent<EmployeeMovement>();
        employeeList.Add(employee);
        employee.MoveTo(employeePosList[employeePosIndex].position);
        UpdateEmployeesColor();

        if (employeePosIndex == 5)
            return;

        employeePosIndex++;
    }

    public void RemoveEmployee()
    {
        Destroy(employeeList[0].gameObject);
        employeeList.Remove(employeeList[0]);
        employeePosIndex--;
        UpdateEmployeesColor();

        for (int i = 0; i < employeeList.Count; i++)
        {
            StartCoroutine(MoveEmployeeCoroutine(i));
        }
    }

    private IEnumerator MoveEmployeeCoroutine(int index)
    {
        yield return new WaitForSeconds(0.7f);
        employeeList[index].MoveTo(employeePosList[index].position);
    }

    private void UpdateEmployeesColor()
    {
        for (int i = 0; i < employeeList.Count; i++)
        {
            if (i == 0)
                employeeList[i].gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            else
                employeeList[i].gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }   
}
