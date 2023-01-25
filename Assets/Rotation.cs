using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Rotation : MonoBehaviour
{
    public Vector3 omega = new Vector3(0 , 10 , 0 );

    public Vector3 alpha = new Vector3(0 , 0, 0);

    public int stepCnt = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var position = transform.position;
        for (int i = 0; i < stepCnt; i++)
        {
            var dt = Time.fixedDeltaTime / stepCnt;
            Vector3 vel = Vector3.Cross(omega, position);
            Vector3 acc = Vector3.Cross(alpha, position) + Vector3.Cross(omega, vel);
            position += vel * dt + 0.5f * dt * dt * acc;
            omega += alpha * dt;
        }

        transform.position = position;
    }
}