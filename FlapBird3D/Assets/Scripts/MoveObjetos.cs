using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjetos : MonoBehaviour
{
    public GameObject jogador;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -4f);
    }

    // Update is called once per frame
    void Update()
    {
        ApagaObjeto();
    }

    void ApagaObjeto()
    { 
        if (this.transform.position.z < jogador.transform.position.z - 5.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
