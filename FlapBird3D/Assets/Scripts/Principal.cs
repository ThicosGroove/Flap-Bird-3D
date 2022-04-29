using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Principal : MonoBehaviour
{
    public GameObject jogador;
    public GameObject obstaculo;
    public GameObject arbusto;
    public GameObject cerca;
    public GameObject nuvem;
    public GameObject pedra;

    private GameObject novoObj;
    private GameObject novoObstaculo;

    public bool comecou = false;
    public bool acabou = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!acabou)
        {
            InvokeRepeating("CriaCerca", 0.1f, 0.4f);
            InvokeRepeating("CriaCenario", 1f, 0.8f);
            InvokeRepeating("CriaObstaculo", 1f, 1.8f);
        }
    }

    void CriaCerca()
    {
        if (comecou)
        {
            Instantiate(cerca);
        }      
    }

    void CriaCenario() 
    {
        if (comecou)
        {
            int sorteiaObj = Random.Range(1, 4);

            float posicaoXrandom = Random.Range(-8f, -2.4f);
            float posicaoYrandom = Random.Range(-1f, 2.3f);
            float rotacaoYrandom = Random.Range(0.0f, 360f);

            switch (sorteiaObj)
            {
                case 1: novoObstaculo = Instantiate(nuvem);
                    novoObstaculo.transform.position = new Vector3(novoObstaculo.transform.position.x, posicaoYrandom, novoObstaculo.transform.position.z);
                    break;
                case 2: novoObj = Instantiate(arbusto);
                    novoObj.transform.position = new Vector3(posicaoXrandom, novoObj.transform.position.y, novoObj.transform.position.z);
                    novoObj.transform.rotation = Quaternion.Euler(-90, rotacaoYrandom, novoObj.transform.rotation.z); 
                    break;
                case 3: novoObj = Instantiate(pedra);
                    novoObj.transform.position = new Vector3(posicaoXrandom, novoObj.transform.position.y, novoObj.transform.position.z);
                    novoObj.transform.rotation = Quaternion.Euler(-90, rotacaoYrandom, novoObj.transform.rotation.z); 
                    break;
                default: break;               
            }          
        }   
        
    }

    void CriaObstaculo()
    {
        if (comecou)
        {
            float posicaoYrandom = Random.Range(-2.5f, 0f);

            novoObstaculo = Instantiate(obstaculo);
            novoObstaculo.transform.position = new Vector3(novoObstaculo.transform.position.x, posicaoYrandom, novoObstaculo.transform.position.z);
        }
    }

}
