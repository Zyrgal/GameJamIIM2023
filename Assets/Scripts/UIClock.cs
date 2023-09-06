using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClock : MonoBehaviour
{
    [SerializeField] private float timeToCompleteDay;

    private Transform hoursHandTransform;
    private Transform minutesHandTransform;
    private float day;

    private void Awake()
    {
        minutesHandTransform = transform.Find("minutes");
        hoursHandTransform = transform.Find("hours");
    }

    private void Update()
    {
        day += Time.deltaTime / timeToCompleteDay;

        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f;
        hoursHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

        float hoursPerDay = 24f;
        minutesHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);
    }
}
