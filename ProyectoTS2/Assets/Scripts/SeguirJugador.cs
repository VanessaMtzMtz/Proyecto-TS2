using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;
    public float velAcercamiento;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, jugador.position, velAcercamiento * Time.deltaTime);
    }
}
