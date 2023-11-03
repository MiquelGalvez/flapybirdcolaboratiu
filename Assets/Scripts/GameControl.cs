using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    //Aquest codi el qeu fa es que depenguen de la vida del player es dona un cas o un altre i en dependencia del cas es restara un cor o un altre, representant aixi la vida del player

    public GameObject heart1, heart2, heart3, gameOver;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        //Inicialitzem l'escena amb tres de vida i activem els tres cors que en aquest cas son tres gameObjects, juntament amb un altre qeu es gamerOver per que quan aquest s'activi es mostrara per pantalla un text de GMAE OVER i es para el joc
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //SWITCH QUE DEPENGUEN DE LA VIDA QUE TINGUEM ENS TREU UN COR O ENS MOSTRA LA PANTALLA DE GAMEOVER
        switch (health)
        {
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver .gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            

        }
    }
}
