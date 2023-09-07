using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeMovement : MonoBehaviour
{
    public Animator animator;

    public void MoveTo(Vector3 targetPos)
    {
        StartCoroutine(MoveToCoroutine(targetPos));
    }

    private IEnumerator MoveToCoroutine(Vector3 targetPos, bool moveascenc = false)
    {
        Vector3 pos = transform.position;
        float t = 0;
        while (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.Lerp(pos, targetPos, t);
            t += 0.01f;
            yield return new WaitForSeconds(0.01f);
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (moveascenc && !stateInfo.IsName("Yeet"))
            {
                animator.SetTrigger("Yeet");
            }
        }

        if (moveascenc)
        {
            //Truc de layer
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
}
