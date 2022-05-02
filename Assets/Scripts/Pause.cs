/*
Actividad 3 - último prototipo de juego
Héctor Robles Villarreal A01634105
Diego Su Gómez  A01620476
Equipo 8
Viernes 29 de abril de 2022
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    [SerializeField]
    private Text texto;
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 0;
      texto.text = "Pulsa cualquier tecla para jugar";


    }

    // Update is called once per frame
    void Update()
    {
      if (Input.anyKey) {
        Time.timeScale = 1;
        texto.text ="";
      }

    }
}
