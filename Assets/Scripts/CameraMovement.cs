﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        Offset = Player.position - transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position - Offset;
        transform.LookAt(Player);
    }
}
