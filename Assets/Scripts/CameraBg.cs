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

public class CameraBg : MonoBehaviour
{
  public Color color1 = Color.red;
  public Color color2 = Color.blue;
  public Color color3 = Color.green;
  public float duration = 3.0F;

  public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
      cam = GetComponent<Camera>();
       cam.clearFlags = CameraClearFlags.SolidColor;

    }

    // Update is called once per frame
    void Update()
    {
      float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(color1, color2, t);

    }
}
