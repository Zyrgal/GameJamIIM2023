using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EmployeeMovement : MonoBehaviour
{
    public Animator animator;
    public Animator door_anim;
    public GameObject doors;

    private void Start()
    {
        door_anim = GameObject.Find("Doors").GetComponent<Animator>();
        doors = door_anim.gameObject;
    }
    public void MoveTo(Vector3 targetPos, bool moveascenc = false)
    {
        StartCoroutine(MoveToCoroutine(targetPos, moveascenc));
    }

    public void trigger_destroy()
    {
        Debug.Log("test " + this.gameObject.name);
        Destroy(this.gameObject.GetComponent<EmployeeData>().sheetData.gameObject);
        Destroy(this.gameObject);
    }

    private IEnumerator MoveToCoroutine(Vector3 targetPos, bool moveascenc = false)
    {
        Vector3 pos = transform.position;
        float t = 0;
        while (!moveascenc && Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.Lerp(pos, targetPos, t);
            t += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        if (moveascenc)
        {
            animator.SetTrigger("Yeet");
            doors.GetComponent<Door_shut>().employee = this.gameObject;
            this.gameObject.name="willtakedoor";
            while (Vector3.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = Vector3.Lerp(pos, targetPos, t);
                t += 0.1f;
                yield return new WaitForSeconds(0.01f);
            }
            door_anim.SetTrigger("Close");
            //Attendre que la porte de l'ascensseur se ferme
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
}
