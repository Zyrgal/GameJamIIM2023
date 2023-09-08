using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIClock : MonoBehaviour
{
    public static UIClock Instance;

    [SerializeField] private float timeToCompleteDay;

    private Transform hoursHandTransform;
    private Transform minutesHandTransform;
    [SerializeField] GameObject winPanel;
    private float day;

    private void Awake()
    {
        Instance = this;
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

        if (hoursHandTransform.eulerAngles.z < 2)
        {
            winPanel.SetActive(true);
        }
    }
}
