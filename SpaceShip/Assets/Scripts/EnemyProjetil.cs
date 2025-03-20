using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyProjetil : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Vector3 direction;
    public float speed;

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
        this.transform.position += this.direction * this.speed * Time.deltaTime; // move o projetil
    }
}
