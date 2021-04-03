using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float ColorChangeSpeed;
    public Color StartColor;
    public Color EndColor;
    public float ResetBlockDelay;
    public float ColorTimer;
    public float DropSpeed;

    private Block[] children;

    // Start is called before the first frame update
    void Start()
    {
        //get children
        var objects = transform.GetComponentsInChildren<Transform>()
            .OrderBy(i => i.gameObject.name)
            .ToArray();

        children = new Block[objects.Count()];

        for (int i = 0; i < objects.Count(); i++)
        {
            children[i] = new Block
            {
                GameObject = objects[i],
                IsFalling = false,
                StartColor = StartColor,
                EndColor = EndColor
            };
        }

        InvokeRepeating("DropRandomBlock", 10f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropRandomBlock()
    {
        //block movement: if not previously selected, then set the timer for color and drop.
        int randomIndex = UnityEngine.Random.Range(0, children.Length);
        Block randomChild = children[randomIndex];

        if (randomChild != null)
        {
            if (!randomChild.IsFalling)
            {
                //change color
                StartCoroutine(randomChild.BlockCoroutine(ColorChangeSpeed, DropSpeed));

                //fall
                randomChild.IsFalling = true;
            }
        }
    }
    
}
