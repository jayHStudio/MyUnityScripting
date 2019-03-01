using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideByZero : MonoBehaviour
{
    public int zero;

    // Start is called before the first frame update
    void Start()
    {
        int error = 10 / zero;
    }
}
