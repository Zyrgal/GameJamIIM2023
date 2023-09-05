using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeMovement : MonoBehaviour
{

    public void MoveTo(Vector3 targetPos)
    {
        StartCoroutine(MoveToCoroutine(targetPos));
    }

    private IEnumerator MoveToCoroutine(Vector3 targetPos)
    {
        Vector3 pos = transform.position;
        float t = 0;
        while (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.Lerp(pos, EmployeePosManager.instance.gameObject.transform.position, t);
            t += 0.006f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
