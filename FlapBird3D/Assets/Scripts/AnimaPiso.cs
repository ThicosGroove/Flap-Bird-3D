using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaPiso : MonoBehaviour
{
    [SerializeField]
    private Principal principal;

    [SerializeField]
    private Jogador jogador;

    public Material materialPiso;
    private float velocidade = 0.40f;

    void Awake()
    {
        principal = GameObject.FindObjectOfType<Principal>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (principal.acabou == false)
        {
            float offset = Time.time * velocidade;
            materialPiso.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
        }
    }
}
