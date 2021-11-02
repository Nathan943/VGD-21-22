using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScriptPaddle : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<ParticleSystem>().Play();
        
    }

  
    
}
