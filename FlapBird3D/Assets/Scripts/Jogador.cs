using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    [SerializeField] 
    PauseMenu pauseMenu;

    [SerializeField] 
    Principal principal;

    public GameObject particle;
    public AudioClip somPula;
    public AudioClip somBate;
    public Text score;
    public Text highScore;

    Rigidbody rb;

    int pontos;
    float velocidade = 300f;


    void Awake()
    {
        principal = GameObject.FindObjectOfType<Principal>();
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        score.text = "Score: ";
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.isGamePaused == false)
        {        
            if (Input.GetButtonDown("Fire1"))
            {
                principal.comecou = true;
                pauseMenu.TextoInicio();

                rb.isKinematic = false;
                rb.useGravity = true;

                rb.AddForce(new Vector3(0f, velocidade, 0f));

                GetComponent<AudioSource>().PlayOneShot(somPula);

                GameObject novaPartcitula = Instantiate(particle);
                novaPartcitula.transform.position = this.gameObject.transform.position;
            }
        }   
        transform.rotation = Quaternion.Euler(rb.velocity.y * (-5f), 0f, 0f);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            principal.acabou = true;
            rb.velocity = Vector3.zero;
            rb.velocity = new Vector3(0.0f, -10.0f, -10.0f);
            rb.AddTorque(new Vector3(100.0f, 100.0f, -100.0f));

            GameOver();
            GetComponent<AudioSource>().PlayOneShot(somBate);
        }        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GameController") 
        {
            pontos += 2000;
            score.text = "Score: " + pontos.ToString();

            if (pontos > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", pontos);
            }
        }
    }

    void GameOver()
    {
        Invoke("RestartScene", 1f);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
