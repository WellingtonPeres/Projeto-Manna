using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    public Transform camera;

    void Update()
    {
        transform.LookAt(camera);
    }
}
