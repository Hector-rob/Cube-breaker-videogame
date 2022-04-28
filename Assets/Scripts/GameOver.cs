using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text textoPuntos;
    [SerializeField]
    private Text maxPuntos;
    // Start is called before the first frame update
    void Start()
    {
      textoPuntos.text = "Puntaje final: " + Pelota.puntuacion.ToString();
      maxPuntos.text = "Máxima puntuación: " + Pelota.maxPunt.ToString();
      Pelota.puntuacion = 0;
      Pelota.contPelotas = 1;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Again(){
      SceneManager.LoadScene(0);
    }
}
