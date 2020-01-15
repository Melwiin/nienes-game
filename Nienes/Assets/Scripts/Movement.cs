using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform bullet;
    public float speed;

    public float rTuning;

    float angle;

    void FixedUpdate()
    {
        angle = bullet.eulerAngles.magnitude * Mathf.Deg2Rad;

        bullet.position += new Vector3((Mathf.Cos(angle + rTuning) * speed) * Time.deltaTime, (Mathf.Sin(angle + rTuning) * speed) * Time.deltaTime, 0);
    }
}