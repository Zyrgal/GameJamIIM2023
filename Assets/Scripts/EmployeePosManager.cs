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

    [SerializeField] public List<Transform> employeePosList = new List<Transform>();
    public List<EmployeeMovement> employeeList = new List<EmployeeMovement>();
    private Vector3 offset;
    private int employeePosIndex = 0;
    public Transform posAscensseur;

    private void Awake()
    {
        instance = this;
    }

    public GameObject SpawnEmployee()
    {
        EmployeeMovement employee = Instantiate(employeePosPrefab, new Vector3(employeePosList[employeePosList.Count-2].position.x, transform.position.y), Quaternion.identity).GetComponent<EmployeeMovement>();
        employeeList.Add(employee);

        if (employeePosIndex < employeePosList.Count-1)
        {
            employee.MoveTo(employeePosList[employeePosIndex].position);
            employeePosIndex++;
        }

        return employee.gameObject;
    }

    public void RemoveEmployee()
    {
        //Destroy(employeeList[0].gameObject);
        employeeList[0].GetComponent<EmployeeData>().sheetData.HideSheet();
        employeeList.Remove(employeeList[0]);
        employeePosIndex--;

        employeeList[0].GetComponent<EmployeeData>().SetLayerActiveEmployee();
        employeeList[0].GetComponent<EmployeeData>().SetToWhiteColor();
        employeeList[0].GetComponent<EmployeeData>().sheetData.DisplaySheet();

        for (int i = 0; i < employeeList.Count; i++)
        {
            StartCoroutine(MoveEmployeeCoroutine(i));
        }
    }

    private IEnumerator MoveEmployeeCoroutine(int index)
    {
        yield return new WaitForSeconds(0.7f);

        if (index > employeePosList.Count - 1)
        {
            employeeList[index].MoveTo(employeePosList[4].position);
        }
        else
        {
            employeeList[index].MoveTo(employeePosList[index].position);
        }
    }

    private void UpdateEmployeesColor()
    {
        for (int i = 0; i < employeeList.Count; i++)
        {
            if (i == 0)
            {
                //employeeList[i].gameObject.transform.Find("Body").GetComponent<SpriteRenderer>().color = Color.white;
                //employeeList[i].gameObject.transform.position.Set(employeeList[i].gameObject.transform.position.x, employeeList[i].gameObject.transform.position.y, 0);
            }
            else
            {
                //employeeList[i].gameObject.transform.Find("Body").GetComponent<SpriteRenderer>().color = Color.black;
                //employeeList[i].gameObject.transform.position.Set(employeeList[i].gameObject.transform.position.x, employeeList[i].gameObject.transform.position.y, 1);
            }
        }
    }   
}
