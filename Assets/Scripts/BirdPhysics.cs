using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BirdPhysics : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject objectToSpawn;

    [SerializeField]
    TextMeshProUGUI texttimer;
    [SerializeField]
    AudioClip source1;
    [SerializeField]
    TextMeshProUGUI textpunt;
    [SerializeField]
    TextMeshProUGUI textobs;

    private int punt = 0;
    private int obstacles = 0;
    private int minuts, seconds, cents;

    public float speed = 2;
    public float force = 200;
    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Rigidbody2D birdBody = GetComponent<Rigidbody2D>();
        birdBody.velocity = Vector2.right*speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Pickup")
        {
            punt++;
            textpunt.text = (": " + punt.ToString());
            Destroy(collision.gameObject);

            //L'audio source el que fa es emetre un so per el player en el moment que recull un pickup, s'emet per el player perque el pick up s'elimina al recollir-lo i no dona temps a que el so surti per el mateix
            audioSource.PlayOneShot(source1);


            if (transform.position.x <= 25 )
            {
                Vector3 randomPosition = new Vector3(10 + transform.position.x, Random.Range(2, -2), 0);
                Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            }
            

        }
        if (collision.tag == "Obstacle")
        {
            obstacles++;
            textobs.text = (": " + obstacles.ToString());
        }

        //Aquest dos colision.tag el qeu fan es detectar quin tipus d'enemic es el que colisiona amb el player i en funcio del enemic resta la vida preestablerta

        if (collision.tag == "Enemic")
        {
            GameControl.health -= 1;
        }
        if (collision.tag == "Portal")
        {
            SceneManager.LoadScene(1);
        }
        if (collision.tag == "Portal2")
        {
            SceneManager.LoadScene(2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //El load scene el que fa es carregar l'escena que hi ha en la posció 0, l'ordre de les scenes es pot veure en Unity a Files -> Build Settings
        SceneManager.LoadScene(0);

    }
    // Update is called once per frame
    void Update()
    {
        //Aquest input detecta el clic dret del boto i el que a es impulsar el player cap amunt
        

        if (Application.platform == RuntimePlatform.Android) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody2D birdBody = GetComponent<Rigidbody2D>();
                birdBody.AddForce(Vector2.up * force);

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody2D birdBody = GetComponent<Rigidbody2D>();
                birdBody.AddForce(Vector2.up * force);

            }
        }
        //Aixo el que fa es agafar el temps i posar-les en tres variables, que son: minuts, segons i centesimes de segons
        timeElapsed += Time.deltaTime;
        minuts = (int)(timeElapsed / 60f);
        seconds = (int)(timeElapsed - minuts * 60f);
        cents = (int)((timeElapsed - (int)timeElapsed) * 100f);
        texttimer.text = string.Format("Time: {0}:{1}:{2}", minuts, seconds,cents);
    }
}
