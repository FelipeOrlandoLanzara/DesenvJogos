using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int vidas = 3; // Número de vidas do jogador
    public GameObject Vida1;
    public GameObject Vida2;
    public GameObject Vida3;
    
    public void TakeDamage() {

        vidas--; // Diminui uma vida

        if (vidas == 2) {
            GameObject vida3 = GameObject.Find("Vida3");
            vida3.GetComponent<SpriteRenderer>().enabled = false;
        } else if (vidas == 1) {
            GameObject vida2 = GameObject.Find("Vida2");
            vida2.GetComponent<SpriteRenderer>().enabled = false;
        } else if (vidas == 0) {
            GameObject vida1 = GameObject.Find("Vida1");
            vida1.GetComponent<SpriteRenderer>().enabled = false;
        }

        Debug.Log("Vidas restantes: " + vidas);

        // Verifica se o jogador perdeu todas as vidas
        if (vidas <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("EndGame");
    }
}
