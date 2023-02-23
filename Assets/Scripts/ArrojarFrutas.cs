using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrojarFrutas : MonoBehaviour
{
    public GameObject bombaPrefab;
    public GameObject[] frutasArrojadaPrefab;
    public float esperaMinima = 0.3f;
    public float esperaMaxima = 1;
    public Transform[] lugaresLanzamiento;
    public float fuerzaMinima = 12;
    public float fuerzaMaxima = 17;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Arrojador());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Arrojador()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(esperaMinima, esperaMaxima));
            Transform t = lugaresLanzamiento[Random.Range(0, lugaresLanzamiento.Length)];
            GameObject ObjetoArrojado = null;
            float random = Random.Range(0, 100);
            if (random < 30)
                ObjetoArrojado = bombaPrefab; //En 0 pone la bomba
            else
            {
                ObjetoArrojado = frutasArrojadaPrefab[Random.Range(0, frutasArrojadaPrefab.Length)];
            }
            GameObject fruta = Instantiate(ObjetoArrojado, t.position, t.rotation);
            fruta.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(fuerzaMinima,fuerzaMaxima), ForceMode2D.Impulse);
            Destroy(fruta, 5);
        }
            
    }
}
