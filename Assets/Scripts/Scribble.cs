using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scribble : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.rotation *= new Quaternion(0, 0, 0.0001f, 0);
    }
}
