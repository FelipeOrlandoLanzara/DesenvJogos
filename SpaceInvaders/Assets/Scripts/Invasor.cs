using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invasor : MonoBehaviour {
    public Sprite[] animacaoSprites; // array de sprites
    public float tempoAnimacao = 1.0f; // quanto tempo demora para mudar de sprite 1sec
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame; // saber em qual sprit estamos

    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 1.0f;

    private static float limiteDireita = 8.0f;
    private static float limiteEsquerda = -8.0f;
    private static float distanciaDescida = (-0.5f / 3); 
    private static bool mudarDirecao = false;

    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), this.tempoAnimacao, this.tempoAnimacao);

        rb2d = GetComponent<Rigidbody2D>();
        var vel = rb2d.velocity;
        vel.x = speed; // comeca indo para a direita
        rb2d.velocity = vel;
    }

    private void AnimateSprite() {
        _animationFrame++;

        if (_animationFrame >= this.animacaoSprites.Length) {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animacaoSprites[_animationFrame];
    }

    void Update() {
        timer += Time.deltaTime;

        if (timer >= waitTime) {
            VerificarLimite();
            timer = 0.0f;
        }

        if (mudarDirecao) {
            DescerENovamente();
        }
    }

    void VerificarLimite() {
        if (transform.position.x >= limiteDireita || transform.position.x <= limiteEsquerda) {
            mudarDirecao = true; // qualquer invasor que tocar uma das bordas, muda direcao
        }
    }

    void DescerENovamente() {
        mudarDirecao = false; 

        Invasor[] invasores = FindObjectsOfType<Invasor>();

        foreach (Invasor invasor in invasores) {
            var vel = invasor.rb2d.velocity;
            vel.x *= -1; // inverte a direcao de X
            invasor.rb2d.velocity = vel;

            // invasores vao descer junto
            invasor.transform.position = new Vector2(invasor.transform.position.x, invasor.transform.position.y + distanciaDescida);
        }
    }
}
