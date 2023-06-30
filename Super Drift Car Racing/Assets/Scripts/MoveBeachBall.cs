using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveBeachBall : MonoBehaviour
{
    public float time = 0;
    public float amplitude = 0.25f;
    public float frequency = 2;
    public float offset = 0;
    public Vector3 startPosititon;

    private void Start()
    {
        startPosititon = transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime;
        offset = amplitude * Mathf.Sin(time * frequency);

        transform.position = startPosititon + new Vector3(0, offset, 0); ;
    }
}
