using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    [SerializeField] private float speedY;
    [SerializeField] private float speedX;
    [SerializeField] private float speedZ;

    private void Update()
    {
        transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);
    }

}
