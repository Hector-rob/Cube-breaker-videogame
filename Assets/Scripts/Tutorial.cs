using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextOne(){
      SceneManager.LoadScene(3);
    }
    public void nextTwo(){
      SceneManager.LoadScene(4);
    }
    public void nextThree(){
      SceneManager.LoadScene(5);
    }
    public void jugar(){
      SceneManager.LoadScene(0);
    }
    public void regresarThree(){
      SceneManager.LoadScene(4);
    }
    public void regresarTwo(){
      SceneManager.LoadScene(3);
    }
    public void regresarOne(){
      SceneManager.LoadScene(2);
    }

}
