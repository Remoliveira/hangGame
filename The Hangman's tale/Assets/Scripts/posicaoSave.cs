using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicaoSave : MonoBehaviour
{
    public float x;
    public float y;
    public Jogador jogador;
    private void OnCollisionEnter2D(Collision2D collision)
    { 
       
    
        if (collision.gameObject.CompareTag("Player"))
        {
            jogador = collision.gameObject.GetComponent<Jogador>();
            jogador.setPosicao(jogador.transform.position.x,jogador.transform.position.y);


        }
    }
}
