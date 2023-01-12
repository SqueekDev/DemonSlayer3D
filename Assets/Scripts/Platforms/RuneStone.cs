using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStone : MonoBehaviour
{
    private void Start()
    {
        Rotate();
    }

    private void Rotate()
    {
        int maxRotationAngle = 360;
        float rotationY = Random.Range(0, maxRotationAngle);
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
