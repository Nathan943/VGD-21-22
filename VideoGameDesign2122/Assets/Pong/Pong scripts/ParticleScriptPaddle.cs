using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScriptPaddle : MonoBehaviour
{
    
    //On collision with paddle
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Play particles
        GetComponent<ParticleSystem>().Play();
        
    }
}
