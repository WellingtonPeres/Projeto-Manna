using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roda : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 0));
    }
}
