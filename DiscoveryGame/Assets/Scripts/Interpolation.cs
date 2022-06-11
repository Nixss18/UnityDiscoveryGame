using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolation : MonoBehaviour
{
private Vector3 endPosition = new Vector3(-46, 0, -50);
private Vector3 startPosition;
private float duration = 3f;
private float elapsedTime;

public GameObject monster;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / duration;
        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete); //interpolācija
    }
}
