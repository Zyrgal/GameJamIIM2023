using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_shut : MonoBehaviour
{
    public GameObject employee;

    public void destroy_employee()
    {
        employee.GetComponent<EmployeeMovement>().trigger_destroy();
    }
}
