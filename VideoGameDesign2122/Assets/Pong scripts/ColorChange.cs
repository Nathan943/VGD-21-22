using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public SpriteRenderer bg;
    public float red = 255;
    public float blue = 0;
    public float green = 0;
    float colorChangeSpeed = 0.1f;
    bool reverseColor = false;

    // Update is called once per frame
    void Update()
    {
        Colors();
        bg.material.color = new Color(red, green, blue);
        Debug.Log("y");
    }

    void Colors()
    {
        if (!reverseColor)
        {
            if (red < (254 - (colorChangeSpeed - 1)))
            {
                red += colorChangeSpeed;
            }
            else if (blue < 254 - (colorChangeSpeed - 1))
            {
                blue += colorChangeSpeed;
            }
            else if (green < 254 - (colorChangeSpeed - 1))
            {
                green += colorChangeSpeed;
            }
            else
            {
                reverseColor = true;
            }
        }

        if (reverseColor)
        {
            if (red > colorChangeSpeed)
            {
                red -= colorChangeSpeed;
            }
            else if (blue > colorChangeSpeed)
            {
                blue -= colorChangeSpeed;
            }
            else if (green > colorChangeSpeed)
            {
                green -= colorChangeSpeed;
            }
            else
            {
                reverseColor = false;
            }
        }
    }
}
