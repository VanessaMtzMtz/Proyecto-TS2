using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCubrebocas : MonoBehaviour
{
    public AudioSource efectoSonido;

    // Start is called before the first frame update
    void Start()
    {
        efectoSonido = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.tag == "Cubrebocas")
            {
                efectoSonido.Play();
                Destroy(collision.gameObject);
            }
        }
    }
}
