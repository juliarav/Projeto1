using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 5;
    public int forcaPulo = 6;
    private Rigidbody rb;
    private AudioSource source;
    public bool noChao;

    void Start()
    {
       TryGetComponent (out rb);
       TryGetComponent(out source);
    }

    public void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "chão") {
            noChao = true;
        }
    }

    void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direcao =  new Vector3 (h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);
        
        // pulo
        if (Input.GetKeyDown(KeyCode.Space) && noChao) { // se apertou espaço

            // pulo
            source.Play();

        // aplica força para cima
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }

        if (transform.position.y <= -10) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
