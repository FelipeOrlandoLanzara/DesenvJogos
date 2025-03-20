using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    private float lenght;
    private float movingSpeed = 5f;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start() {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update() {
        transform.position += Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect;
        if(transform.position.x < -lenght ) {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }
        Buff();
    }

    void Buff() {
        if (Projetil.pontuacao == 500) {
            movingSpeed = 4f;
        }
        else if(Projetil.pontuacao == 600) {
            movingSpeed = 3.5f;
        }
        else if(Projetil.pontuacao == 700) {
            movingSpeed = 3f;
        }
        else if(Projetil.pontuacao == 800) {
            movingSpeed = 2f;
        }
        else if(Projetil.pontuacao == 900) {
            movingSpeed = 1f;
        }
    }
}
