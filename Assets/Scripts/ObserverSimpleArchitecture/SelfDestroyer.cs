﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", 3);
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
