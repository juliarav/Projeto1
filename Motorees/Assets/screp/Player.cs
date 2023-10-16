using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;
    private Rigidbody rb;
    public bool noChao;

    void Start()
    {
       TryGetComponent (out rb);
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

        // aplica força para cima
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }

        if (transform.position.y <= -10) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
