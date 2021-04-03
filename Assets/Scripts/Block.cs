using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Block
    {
        public Transform GameObject { get; set; }
        public bool IsFalling { get; set; }
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }


        public void DropBlock(float dropSpeed)
        {
            GameObject.transform.Translate(Vector3.down * Time.deltaTime * dropSpeed, Space.Self);
        }

        public void ChangeColor(float colorChangeSpeed, Renderer render, float startTime)
        {
            float colorTimer = (Time.time - startTime) * colorChangeSpeed;
            render.material.color = Color.Lerp(render.material.color, EndColor, colorTimer);
        }

        public IEnumerator BlockCoroutine(float colorChangeSpeed, float dropSpeed)
        {
            Renderer render = GameObject.GetComponent<Renderer>();
            float timeToStart = Time.time;
            if (render != null)
            {
                while (render.material.color != EndColor)
                {
                    ChangeColor(colorChangeSpeed, render, timeToStart);
                    yield return null;
                }
                while (GameObject.position.y > -50f)
                {
                    DropBlock(dropSpeed);
                    yield return null;
                }
            }

        }
    }
}
