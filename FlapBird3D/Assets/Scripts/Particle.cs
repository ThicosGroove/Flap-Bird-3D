using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{  
    private void Start()
    {
        Invoke("ApagaObjeto", 1f);
    }
    
    void ApagaObjeto()
    {
        Destroy(this.gameObject);
    }
}
