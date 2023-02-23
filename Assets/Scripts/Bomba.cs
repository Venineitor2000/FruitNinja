using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada e = collision.GetComponent<Espada>();
        //!e es una forma corta de decir e == null al parecer
        if (!e)
        {
            return;
        }
        FindObjectOfType<GameManager>().AlTocarBomba();

    }
}
