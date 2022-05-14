using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionJugador : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Cura")){
            print("curado");
            Destroy(other.gameObject,.5f);
        }
        if (other.CompareTag("Covid"))
        {
            print("Contagiado");
        }
    }
}
