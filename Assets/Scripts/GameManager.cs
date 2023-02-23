using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int puntaje;
    int mejorPuntaje;
    public Text textoPuntaje;
    public Text textoPuntajeMaximo;
    public Text textoPuntajeMaximoFinal;
    public Text textoPuntajeFinal;
    public GameObject panelGameOver;
    // Start is called before the first frame update
    void Awake()
    {
        panelGameOver.SetActive(false);
        CargarMejorPuntaje();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AumentarPuntaje()
    {
        puntaje++;
        textoPuntaje.text = puntaje.ToString();
    }

    public void AlTocarBomba()
    {
        Time.timeScale = 0;
        panelGameOver.SetActive(true);
        textoPuntajeFinal.text = "Punataje: " + puntaje.ToString();
        textoPuntaje.gameObject.SetActive(false);
        textoPuntajeMaximo.gameObject.SetActive(false);
        GuardarmejorPuntaje();
        textoPuntajeMaximoFinal.text = "Mejor: " + mejorPuntaje.ToString();
    }

    public void Reniciar()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    void GuardarmejorPuntaje()
    {
        if(puntaje > mejorPuntaje)
        {
            mejorPuntaje = puntaje;
            PlayerPrefs.SetInt("MejorPuntaje", puntaje);            
        }
            
    }

    void CargarMejorPuntaje()
    {
        mejorPuntaje = PlayerPrefs.GetInt("MejorPuntaje");        
        textoPuntajeMaximo.text = "Mejor: " + mejorPuntaje.ToString();
    }
}
