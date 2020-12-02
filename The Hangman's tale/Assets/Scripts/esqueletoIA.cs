using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HangmansTale;
using System;

public class esqueletoIA : MonoBehaviour
{
    public float velocidade = 600f;
    public LayerMask layersPermitidas;
    public Animator animator;
    public Rigidbody2D rb;
    //private float countdown = 3f;
    public Vector2 raycastOffset;
    public float rangeDetectar;
    public bool modoZumbi = false;
    public Jogador jogador;

    private float movimentoHorizontal;
    private Controle2D controle;
    private int andandoDireita = 1;


    //codigo arcaedion
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        controle = GetComponent<Controle2D>();
        //andandoDireita = -1;
        transform.Rotate(0f, 180f, 0f);
    }

    void Update()
    {   //daqui ir e voltar bordas e paredes
        movimentoHorizontal = andandoDireita * velocidade;
       
        var origemX = transform.position.x + raycastOffset.x;
        var origemY = transform.position.y + raycastOffset.y;

        var raycastParedeDireita = Physics2D.Raycast(new Vector2(origemX, origemY), Vector2.right, 0.5f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x, origemY), Vector2.right, Color.cyan);
        if (raycastParedeDireita.collider != null)
        {
            andandoDireita = -1;
        }

        var raycastParedeEsquerda = Physics2D.Raycast(new Vector2(transform.position.x - raycastOffset.x, origemY), Vector2.left, 0.5f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x, origemY), Vector2.left, Color.cyan);
        if (raycastParedeEsquerda.collider !=null)
        {
            andandoDireita = 1;
        }

        var raycastChaoDireita = Physics2D.Raycast(new Vector2(transform.position.x + raycastOffset.x, transform.position.y), Vector2.down, 2f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x + raycastOffset.x, transform.position.y), Vector2.down, Color.red);
        if (raycastChaoDireita.collider == null)
        {
            andandoDireita = -1;
        }

        var raycastChaoEsquerda = Physics2D.Raycast(new Vector2(transform.position.x - raycastOffset.x, transform.position.y), Vector2.down, 2f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x - raycastOffset.x, transform.position.y), Vector2.down, Color.red);
        if (raycastChaoEsquerda.collider == null)
        {
            andandoDireita = 1;
        }
        //ate aqui
    }

    void FixedUpdate()
    {
        controle.Movimento(movimentoHorizontal * Time.fixedDeltaTime, false);
        animator.SetFloat("velocidade", 1);

        var diferencaParaJogador = jogador.gameObject.transform.position.x - transform.position.x;
        var seguindo = Mathf.Abs(diferencaParaJogador) < rangeDetectar;

        if (modoZumbi && seguindo)
        {
            if (diferencaParaJogador < 0)
            {
                andandoDireita = -1;
            }
            else
            {
                andandoDireita = 1;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,rangeDetectar);
    }







    //void Update()
    //{

    //}

    //codigo cara la indie
    //void FixedUpdate()
    //{
    //    move();
    //}

    //private void move()
    //{
    //    countdown -= Time.deltaTime;
    //    if (countdown <= 0)
    //    {
    //        andandoDireita = andandoDireita * -1;
    //        countdown = 3f;
    //        transform.Rotate(0f, 180f, 0f);
    //    }


    //    rb.velocity = new Vector2(velocidade * andandoDireita, rb.velocity.y);
    //    animator.SetFloat("velocidade", 1);

    //}

}
