using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HangmansTale;
using System;

public class gatoIA : MonoBehaviour
{
    public float velocidade = 20f;
    public LayerMask layersPermitidas;
    public Vector2 raycastOffset;
    public float rangeDetectar;
    public bool podePular = false;
    public Jogador jogador;
    public bool seguindo;

    private bool estaPulando;
    private Rigidbody2D rb;
    private Controle2D controle;
    private int andandoDireita;
    private float movimentoHorizontal;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        controle = GetComponent<Controle2D>();
        andandoDireita = 1;
        transform.Rotate(0f, 180f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        movimentoHorizontal = andandoDireita * velocidade;


     
        var origemX = transform.position.x + raycastOffset.x;
        var origemY = transform.position.y + raycastOffset.y;

        var raycastParedeDireita = Physics2D.Raycast(new Vector2(origemX, origemY), Vector2.right, 1f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x, origemY), Vector2.right, Color.cyan);
        if (raycastParedeDireita.collider != null)
        {
            andandoDireita = -1;
            
        }

        var raycastParedeEsquerda = Physics2D.Raycast(new Vector2(transform.position.x - raycastOffset.x, origemY), Vector2.left, 1f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x, origemY), Vector2.left, Color.cyan);
        if (raycastParedeEsquerda.collider != null)
        {
            andandoDireita = 1;
        }

        var rayCastChaoDireita = Physics2D.Raycast(new Vector2(transform.position.x + raycastOffset.x, transform.position.y), Vector2.down, 0.7f, layersPermitidas);
        Debug.DrawRay(new Vector2(origemX, transform.position.y), Vector2.down, Color.red);
        if (rayCastChaoDireita.collider == null)
        {
            andandoDireita = -1;
        }
        var rayCastChaoEsquerda = Physics2D.Raycast(new Vector2(transform.position.x - raycastOffset.x, transform.position.y), Vector2.down, 0.7f, layersPermitidas);
        Debug.DrawRay(new Vector2(transform.position.x - raycastOffset.x, transform.position.y), Vector2.down, Color.red);
        if (rayCastChaoEsquerda.collider == null)
        {
            andandoDireita = 1;
        }

    }

    void FixedUpdate()
    {
        controle.Movimento(movimentoHorizontal * Time.fixedDeltaTime,estaPulando);
        if (estaPulando)
        {
            estaPulando = false;
        }

        var diferencaParaJogador = jogador.gameObject.transform.position.x - transform.position.x;
        seguindo = Mathf.Abs(diferencaParaJogador) < rangeDetectar;

        if (seguindo)
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
        Gizmos.DrawWireSphere(transform.position, rangeDetectar);
    }

  
}
