using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float velocidadMinimo = 0.1f;
    Vector3 ultimaPosicionMouse;
    Vector3 velocidadMouse;
    Collider2D col;//Collider dela espada
    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        AsociarEspadaAlMouse();
    }

    private void FixedUpdate()
    {
        col.enabled = seMueveElMouse();
    }

    void AsociarEspadaAlMouse()
    {
        

        var mousePosition = Input.mousePosition;
        mousePosition.z = 10; //la z de la camara pero opuesta
        rb2D.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    bool seMueveElMouse()
    {
        
        Vector3 posicionMouseActual = transform.position;
        float desplazamiento = (ultimaPosicionMouse - posicionMouseActual).magnitude;
        print("Desplazamiento " + desplazamiento);
        ultimaPosicionMouse = posicionMouseActual;
        
        if (desplazamiento > velocidadMinimo)
            return true;
        else
            return false;
    }
}
