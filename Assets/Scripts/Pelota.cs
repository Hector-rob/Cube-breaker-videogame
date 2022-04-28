/*
Actividad 2 - segundo prototipo de juego
Héctor Robles Villarreal A01634105
Diego Su Gómez  A01620476
Equipo 8
Miércoles 6 de abril de 2022
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//informar que es INDISPENSABLE este componente
[RequireComponent(typeof(Rigidbody))]
public class Pelota : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private GameObject cubitoAzul;
    [SerializeField]
    private GameObject cubitoRojo;
    [SerializeField]
    private GameObject cubitoVerdeArriba;
    [SerializeField]
    private GameObject cubitoVerdeAbajo;
    [SerializeField]
    private GameObject cubitoMorado;
    [SerializeField]
    private GameObject cubitoTurquesa;
    [SerializeField]
    private GameObject barritaArriba;
    [SerializeField]
    private GameObject barritaAbajo;
    [SerializeField]
    private GameObject pelota;
    [SerializeField]
    public Text puntos;
    [SerializeField]
    private Text info;
    [SerializeField]
    private Text infoT;
    [SerializeField]
    private Text infoBonus;
    public Vector3 vector = new Vector3(0,600,0);
    public float velocidadX = 500;
    public float velocidadY = 500;
    public static int puntuacion;
    private Vector3 posVerdeArriba;
    private Vector3 posVerdeAbajo;
    private Vector3 pos;
    private Vector3 posMorado;
    private Vector3 dobleXbarritas;
    private Vector3 normalBarritas;
    private Vector3 doblePelota;
    private Vector3 normalPelota;
    private bool flagSize;
    public static int contPelotas = 1;
    public int bonusSegs = 0;
    public bool cubosAzules = false;
    public bool cubosMorados = false;
    public bool perdio = false;
    public GameObject cubito;
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public static int maxPunt;


    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.AddForce(vector);
        posVerdeArriba = new Vector3(-3.57f, 2.27f,0);
        posVerdeAbajo = new Vector3(5.13f,-11.31f,0);
        pos = new Vector3(Random.Range(-23,20),Random.Range(-11,2.27f),0);
        dobleXbarritas = new Vector3(1,5,1);
        doblePelota= new Vector3(3,3,3);
        normalPelota= new Vector3(1.5f,1.5f,1.5f);
        normalBarritas = new Vector3(1,3.5f,1);
        StartCoroutine(cuboAzul());
        StopCoroutine(cuboAzul());
        StartCoroutine(cuboMorado());
        StopCoroutine(cuboMorado());
        StartCoroutine(cuboTurquesa());
        StopCoroutine(cuboTurquesa());

    }

    void Update(){


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
      if(c.transform.tag == "Borde"){
        contPelotas = contPelotas-1;
        Destroy(gameObject);
        print(contPelotas.ToString());
        if(contPelotas <=0){
          perdio = true;
          if(puntuacion > maxPunt){
            maxPunt = puntuacion;
          }
          perder();
            info.text = "Perdiste. Fin del Juego";
        }
      }

       if (c.transform.tag == "Rojo"){
         transform.localScale = normalPelota;
         Destroy(c.gameObject);
         StartCoroutine(cuboRojo());
         StopCoroutine(cuboRojo());
         AddOne();
       }
       if (c.transform.tag == "CubitoArriba"){
         Destroy(c.gameObject);
         StartCoroutine(cuboVerdeArriba());
         StopCoroutine(cuboVerdeArriba());
         AddThree();
       }

       if (c.transform.tag == "CubitoAbajo"){
         Destroy(c.gameObject);
         StartCoroutine(cuboVerdeAbajo());
         StopCoroutine(cuboVerdeAbajo());
         AddThree();
       }

       if (c.transform.tag == "Azul"){
          Destroy(c.gameObject);
          cubosAzules = false;
          infoBonus.text = "Barra grande!";
          StartCoroutine(cuboAzul());
          StopCoroutine(cuboAzul());
          barritaAbajo.transform.localScale = dobleXbarritas;
          barritaArriba.transform.localScale = dobleXbarritas;
          flagSize = false;
          if(!flagSize){
           StartCoroutine(ReturnToNormal());
           StopCoroutine(ReturnToNormal());
         }

       }

       if (c.transform.tag == "Morado"){
         Destroy(c.gameObject);
         cubosMorados = false;
         contPelotas+=1;
         infoBonus.text = "Pelota extra!";
         StartCoroutine(cuboMorado());
         StartCoroutine(nuevaPelota());
         StopCoroutine(nuevaPelota());
         StopCoroutine(cuboMorado());
       }

       if(c.transform.tag == "Turquesa"){
         Destroy(c.gameObject);
         transform.localScale = doblePelota;
         infoBonus.text = "Pelota Grande!";
         StartCoroutine(cuboTurquesa());
         StopCoroutine(cuboTurquesa());
       }
   }

   void AddOne(){
     puntuacion+=1;
     puntos.text = "Puntuación: " + puntuacion.ToString();
     info.text = "Destruiste un cubo rojo: + 1 punto!";
     Invoke("delText",2);
   }

   void AddThree(){
     puntuacion+=3;
     puntos.text = "Puntuación: " + puntuacion.ToString();
     info.text = "Destruiste un cubo verde: + 3 puntos!";
     Invoke("delText",2);
   }

   void delText(){
   info.text = "";
   }

   private IEnumerator ReturnToNormal(){
     while(bonusSegs > 0){
       infoT.text = ("Bonus de tamaño: " + bonusSegs.ToString());
       bonusSegs = bonusSegs - 1;
       yield return new WaitForSeconds(1);
     }
     infoT.text = " ";
     barritaAbajo.transform.localScale = normalBarritas;
     barritaArriba.transform.localScale = normalBarritas;
     flagSize = true;
   }

   private IEnumerator cuboVerdeArriba(){
     yield return new WaitForSeconds(2);
     Instantiate(cubitoVerdeArriba,posVerdeArriba,cubitoVerdeArriba.transform.rotation);
   }

   private IEnumerator cuboVerdeAbajo(){
     yield return new WaitForSeconds(2);
     Instantiate(cubitoVerdeAbajo,posVerdeAbajo,cubitoVerdeAbajo.transform.rotation);
   }

   private IEnumerator cuboRojo(){
     yield return new WaitForSeconds(2);
     pos = new Vector3(Random.Range(-23,20),Random.Range(-11,2.27f),0);
     Instantiate(cubitoRojo,pos,cubitoRojo.transform.rotation);
   }

   private IEnumerator cuboAzul(){
     yield return new WaitForSeconds(3);
     infoBonus.text =" ";
     yield return new WaitForSeconds(Random.Range(3,11));
     pos = new Vector3(Random.Range(-23,20),Random.Range(-11,2.27f),0);
     if(!cubosAzules){
     Instantiate(cubitoAzul,pos,cubitoAzul.transform.rotation);
     cubosAzules = true;
     bonusSegs = 5;
   }
 }

   private IEnumerator cuboMorado(){
     yield return new WaitForSeconds(3);
     infoBonus.text =" ";
     yield return new WaitForSeconds(4);
     //yield return new WaitForSeconds(Random.Range(15,20));
     posMorado = new Vector3(Random.Range(-23,20),Random.Range(-11,2.27f),0);
     if(!cubosMorados){
      cubito = Instantiate(cubitoMorado,posMorado,cubitoMorado.transform.rotation);
       cubosMorados = true;
     }
   }

   private IEnumerator nuevaPelota(){
     Instantiate(pelota,posMorado, pelota.transform.rotation,transform.parent);
     //contPelotas+=1;
     yield return new WaitForSeconds(1);
   }

   private IEnumerator cuboTurquesa(){
     yield return new WaitForSeconds(3);
     infoBonus.text =" ";
     yield return new WaitForSeconds(7);
     pos = new Vector3(Random.Range(-23,20),Random.Range(-11,2.27f),0);
     cubito = Instantiate(cubitoTurquesa,pos,cubitoTurquesa.transform.rotation);
   }

   private IEnumerator returnPelota(){
     yield return new WaitForSeconds(3);
     transform.localScale = normalPelota;
   }

   private void perder(){
     if (perdio){
       SceneManager.LoadScene(1);
     }
   }
}
