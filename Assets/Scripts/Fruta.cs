using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    //La fruta tiene q tener comportamiento 2d por eso usa rigidbody 2d, pero la fruta cortada
    //tiene q rotar tomando en cuenta el eje z, por eso es rigid body 3d
    public GameObject frutaCortadaPrefab;
    [SerializeField] AudioSource CORTE;
    // Start is called before the first frame update
    void Start()
    {
        CORTE = GameObject.FindGameObjectWithTag("Corte").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CrearFrutaCortada()
    {
        GameObject frutaCortada = Instantiate(frutaCortadaPrefab, transform.position,transform.rotation);
        Rigidbody[] rbsDeCortado = frutaCortada.GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbsDeCortado)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(500,1000), transform.position, 5);
        }
        Destroy(frutaCortada, 5);
        FindObjectOfType<GameManager>().AumentarPuntaje();
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada e = collision.GetComponent<Espada>();
        
        if(!e)
        {
            return;
        }
        CORTE.Play();
        CrearFrutaCortada();
        

    }
}
