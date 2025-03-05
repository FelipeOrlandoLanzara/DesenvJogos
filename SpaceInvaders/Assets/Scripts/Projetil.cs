using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; // Importante para usar o TextMeshPro

public class Projetil : MonoBehaviour {

    private Rigidbody2D rb2d;
    public Vector3 direction;
    public float speed;
    public static int pontuacao = 0;
    public static int invasores = 33;

    // Referência para o texto de pontuação (TextMeshPro)

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        this.transform.position += this.direction * this.speed * Time.deltaTime; // move o projetil
    }

    // Detectar colisão com a parede invisível
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Barreira")) {
            Destroy(gameObject);
        }
        else if (other.CompareTag("InvasorBaixo")) {
            Destroy(gameObject); // Destruir o projétil
            Destroy(other.gameObject); // Destruir o invasor
            pontuacao += 10;
            invasores--;
            Debug.Log(invasores);
            WinGame();
        }
        else if (other.CompareTag("InvasorMeio")) {
            Destroy(gameObject);
            Destroy(other.gameObject);
            pontuacao += 20;
            invasores--;
            Debug.Log(invasores);
            WinGame();
        }
        else if (other.CompareTag("InvasorCima")) {
            Destroy(gameObject);
            Destroy(other.gameObject);
            pontuacao += 30;
            invasores--;
            Debug.Log(invasores);
            WinGame();
        }
        else if (other.CompareTag("Nave")) {
            Destroy(gameObject);
            Destroy(other.gameObject);
            pontuacao += 50;
        }
        // qualquer outro que queira adicionar
    }

    private void WinGame() {
        if (invasores == 0) {
            SceneManager.LoadScene("WinGame");
        }
    }

}
