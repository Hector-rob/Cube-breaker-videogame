/*
Actividad 1 - propuesta y primer prototipo
Héctor Robles Villarreal A01634105
Diego Su Gómez  A01620476
Equipo 8
Viernes 4 de marzo de 2020
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//informar que es INDISPENSABLE este componente
[RequireComponent(typeof(Rigidbody))]
public class Pelota : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    public Vector3 vector = new Vector3(0,600,0);
    public Vector3 cubepos;
    public float velocidadX = 500;
    public float velocidadY = 500;
    private int puntuacion;
    public Text puntos;
    public Text info;
    public Text infoT;
    private string name;
    private GameObject cube;
    [SerializeField]
    private GameObject barritaArriba;
    [SerializeField]
    private GameObject barritaAbajo;
    private Vector3 posVerdeArriba;
    private Vector3 posVerdeAbajo;
    private Vector3 posAzul;
    private Vector3 dobleXbarritas;
    private Vector3 normalBarritas;
    private Vector3 posRojo;
    [SerializeField]
    private GameObject cubitoAzul;
    [SerializeField]
    private GameObject cubitoRojo;
    private bool flagSize;


    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.AddForce(vector);
        posVerdeArriba = GameObject.Find("Verde1").transform.position;
        posVerdeAbajo = GameObject.Find("Verde2").transform.position;
        posAzul = new Vector3(Random.Range(-10,10),Random.Range(-5,5),0);
        dobleXbarritas = new Vector3(1,5,1);
        normalBarritas = new Vector3(1,3.5f,1);
        Instantiate(cubitoAzul,posAzul,transform.rotation);
    }

    void Update(){
      if (transform.position.y > 8 || transform.position.y < -15){
        info.text = "Perdiste. Fin del Juego";
      }
    }

    void OnCollisionEnter(Collision c){
      if(c.transform.name == "BarritaArriba"){
          vector = new Vector3(Random.Range(-500,500),-700,0);
          rb.AddForce(vector);
      }
      else if (c.transform.name == "BarritaAbajo"){
          vector = new Vector3(Random.Range(-500,500),700,0);
          rb.AddForce(vector);
        }

      else if(c.transform.name == "LateralD"){
        if (vector.y > 0){
          vector = new Vector3(Random.Range(-300,-500),500,0);
          rb.AddForce(vector);
        }
        else{
          vector = new Vector3(Random.Range(-300,-500),-500,0);
          rb.AddForce(vector);
        }

      }
      else if(c.transform.name == "LateralI"){
        if (vector.y > 0){
          vector = new Vector3(Random.Range(300,500),500,0);
          rb.AddForce(vector);
        }
        else{
          vector = new Vector3(Random.Range(300,500),-500,0);
          rb.AddForce(vector);
        }
    }
  }

    void OnTriggerEnter(Collider c){
       if (c.transform.tag == "Rojo"){
         name = c.transform.name;
         Destroy(c.gameObject);
         StartCoroutine(cuboRojo(name));
         StopCoroutine(cuboRojo(name));
         AddOne();
       }
       if (c.gameObject.layer == 3){
         cube = GameObject.Find(c.transform.name);
         cube.transform.localScale = new Vector3(0, 0, 0);
         StartCoroutine(cuboVerde(cube));
         StopCoroutine(cuboVerde(cube));
         AddThree();
       }

       if (c.transform.tag == "Azul"){
         cube = GameObject.Find(c.transform.name);
         cube.transform.localScale = new Vector3(0, 0, 0);
         StartCoroutine(cuboAzul(cube));
         StopCoroutine(cuboAzul(cube));
         barritaAbajo.transform.localScale = dobleXbarritas;
         barritaArriba.transform.localScale = dobleXbarritas;
         flagSize = false;
         if(!flagSize){
           StartCoroutine(ReturnToNormal());
           StopCoroutine(ReturnToNormal());
         }
         //Destroy(c.gameObject);
       }
   }

   void AddOne(){
     puntuacion+=1;
     print("+1");
     print(puntuacion);
     puntos.text = "Puntuación: " + puntuacion.ToString();
     info.text = "Destruiste un cubo rojo: + 1 punto!";
     Invoke("delText",2);
   }

   void AddThree(){
     puntuacion+=3;
     print("+3");
     print(puntuacion);
     puntos.text = "Puntuación: " + puntuacion.ToString();
     info.text = "Destruiste un cubo verde: + 3 puntos!";
     Invoke("delText",2);
   }

   void delText(){
   info.text = "";
   }

   private IEnumerator ReturnToNormal(){
     infoT.text = "Bonus de tamaño: 5segs";
     yield return new WaitForSeconds(1);
     infoT.text = "Bonus de tamaño: 4segs";
     yield return new WaitForSeconds(1);
     infoT.text = "Bonus de tamaño: 3segs";
     yield return new WaitForSeconds(1);
     infoT.text = "Bonus de tamaño: 2segs";
     yield return new WaitForSeconds(1);
     infoT.text = "Bonus de tamaño: 1seg";
     yield return new WaitForSeconds(1);
     infoT.text = " ";
     barritaAbajo.transform.localScale = normalBarritas;
     barritaArriba.transform.localScale = normalBarritas;
     flagSize = true;
   }

   private IEnumerator cuboVerde(GameObject cube1){
     yield return new WaitForSeconds(3);
     cube1.transform.localScale = new Vector3(2, 2, 2);
     if(cube1.name.Contains("Verde2")){
       Instantiate(cube1,posVerdeAbajo,cube1.transform.rotation);
     }
     else{
       Instantiate(cube1,posVerdeArriba,cube1.transform.rotation);
     }
     Destroy(cube1);
   }

   private IEnumerator cuboRojo(string name){
     yield return new WaitForSeconds(3);
     cubepos = cubitoRojo.transform.position;
     posRojo = new Vector3(Random.Range(-23,20),Random.Range(-11,2.27f),0);
     Instantiate(cubitoRojo,posRojo,cubitoRojo.transform.rotation);
   }

   private IEnumerator cuboAzul(GameObject cube3){
     yield return new WaitForSeconds(15);
     cube3.transform.localScale = new Vector3(2, 2, 2);
     posAzul = new Vector3(Random.Range(-10,10),Random.Range(-5,5),0);
     Instantiate(cube3,posAzul,cube3.transform.rotation);
     Destroy(cube3);

   }



}
