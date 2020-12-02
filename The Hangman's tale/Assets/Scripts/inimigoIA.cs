using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HangmansTale;

public class inimigoIA : MonoBehaviour
{
    public float velocidade;
    //public LayerMask layersPermitidas;
    public Animator animator;
    public Rigidbody2D rb;
    public float tempoAndando = 3f;
    private float countdown;

    //private float movimentoHorizontal;
    //private Rigidbody2D rb;
    //private Controle2D controle;
    private int andandoDireita = 1;


    //codigo arcaedion
    //private void OnEnable()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    controle = GetComponent<Controle2D>();
    //    andandoDireita = 1;
    //}

    //void Update()
    //{
    //    movimentoHorizontal = andandoDireita * velocidade;
    //}

    //void FixedUpdate()
    //{
    //    controle.Movimento(movimentoHorizontal * Time.fixedDeltaTime, false);
    //    animator.SetFloat("velocidade", 1);
    //}


    void Update()
    {
        
    }

    //codigo cara la indie
    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        //countdown = tempoAndando;
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            andandoDireita = andandoDireita * -1;
            countdown = tempoAndando;
            transform.Rotate(0f, 180f, 0f);
        }


        rb.velocity = new Vector2(velocidade * andandoDireita, rb.velocity.y);
        animator.SetFloat("velocidade", 1);

    }

}
