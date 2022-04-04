using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    [SerializeField]
    private GameObject cubitoAzul;
    [SerializeField]
    private IEnumerator ponerCubitoAzul;
    [SerializeField]
    private Vector3 vector;
    private bool flagR = false;
    // Start is called before the first frame update
    void Start()
    {
      vector = new Vector3(Random.Range(-10,10),Random.Range(-5,5),0);
      ponerCubitoAzul = cuboAzul();

    }

    // Update is called once per frame
    void Update()
    {
      if(!flagR){
        StartCoroutine(ponerCubitoAzul);
      }
      else{
        StopCoroutine(ponerCubitoAzul);
      }


    }

    private IEnumerator cuboAzul(){
      while(true){
        Instantiate(cubitoAzul,vector,transform.rotation);
        flagR = true;
        yield return new WaitForSeconds(1);
      }
    }
}
