using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class EmployeePosManager : MonoBehaviour
{
    public static EmployeePosManager instance;

    [SerializeField] private int nbOfEmployeePos;
    [SerializeField] private float offsetFromLastPos;
    [SerializeField] private GameObject employeePosPrefab;
    SerializedProperty m_OrderInLayer;

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
        EmployeeMovement employee = Instantiate(employeePosPrefab, new Vector3(employeePosList[employeePosList.Count-1].position.x, transform.position.y), Quaternion.identity).GetComponent<EmployeeMovement>();
        employeeList.Add(employee);
        UpdateEmployeesColor();

        if (employeePosIndex > employeePosList.Count-1)
            return;
        else
        {
            employee.MoveTo(employeePosList[employeePosIndex].position);
            employeePosIndex++;
        }
    }

    public void RemoveEmployee()
    {
        Destroy(employeeList[0].gameObject);
        employeeList.Remove(employeeList[0]);
        employeePosIndex--;

        GetComponent<EmployeeData>().SetLayerActiveEmployee();
        GetComponent<EmployeeData>().SetToWhiteColor();

        for (int i = 0; i <= employeeList.Count; i++)
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
