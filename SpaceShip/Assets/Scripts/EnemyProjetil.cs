using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyProjetil : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Vector3 direction;
    public float speed = 10f;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Barreira")) {
            Destroy(gameObject);
            //Debug.Log("AAAAAAAAAAAAA");

        }
        else if (other.CompareTag("Player")) {
            Destroy(gameObject); // Destruir o projétil
            SceneManager.LoadScene("Lose");
            Debug.Log("AAA");
        }

    }

    private void Update() {
        Reduce();
        this.transform.position += this.direction * this.speed * Time.deltaTime; // move o projetil
    }

    private void Reduce() {
        if (Projetil.pontuacao == 500) {
            speed = 8f;
        }
        else if (Projetil.pontuacao == 600) {
            speed = 6f;
        }
        else if (Projetil.pontuacao == 700) {
            speed = 5f;
        }
        else if (Projetil.pontuacao == 800) {
            speed = 4f;
        }
        else if (Projetil.pontuacao == 900) {
            speed = 3f;
        }
    }
}
