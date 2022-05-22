using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterControler : MonoBehaviour
{
    public Animator anim;
    public Transform camara;
    public Image barraDeVida;
    private float referenciaSmooth;
    private float smoothAngulo = 20f;
    public float vidaActual = 90;
    public float vidaMaxima = 100;
    public GameObject WarningTextPrefab;


    void OnTriggerEnter(Collider other)
    {

        Debug.Log(other);
        if (other.CompareTag("Cura"))
        {
            print("curado");
            Destroy(other.gameObject, .5f);
            vidaActual = vidaActual + 50;
        }

        if (other.CompareTag("Refuerzo"))
        {
            print("curado");
            Destroy(other.gameObject, .5f);
            vidaActual = vidaActual + 50;
            SceneManager.LoadScene("Winner");
        }

        if (other.CompareTag("Cubrebocas"))
        {
            print("curado");
            Destroy(other.gameObject, .5f);
            vidaActual = vidaActual + 10;
        }

        if (other.CompareTag("Gel"))
        {
            print("curado");
            Destroy(other.gameObject, .5f);
            vidaActual = vidaActual + 20;
        }

        if (other.CompareTag("Covid"))
        {
            print("Contagiado");
            vidaActual = vidaActual - 15;
            MostrarAdvertencia();
        }

        if (other.CompareTag("Infectado"))
        {
            print("Contagiado");
            vidaActual = vidaActual - 15;
            MostrarAdvertencia();
        }
    }

    void Update()
    {
        Caminar();
        Agacharse();
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
        if(vidaActual <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void Caminar()
    {
        Vector3 direccion = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        Vector3 inputDirec= new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if(direccion.magnitude > 0.1f)
        {
            float medirAngulo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.eulerAngles.y;

            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, medirAngulo, ref referenciaSmooth, smoothAngulo * Time.deltaTime);

            transform.rotation = Quaternion.Euler(0f, angulo, 0f);

            anim.SetFloat("Mag", inputDirec.magnitude);

            Saltar();
        }
    }


    void Agacharse()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Agacharse", true);
        }
        else
        {
            anim.SetBool("Agacharse", false);
        }

    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }

    public void MostrarAdvertencia()
    {
        GameObject texto = Instantiate(WarningTextPrefab);
        texto.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z);
        texto.transform.Rotate (0,180,0);
    }
}
