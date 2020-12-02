using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoJogador : MonoBehaviour    
{
    public int danoEspinho = 3;
    public Jogador jogador;
    private float x;
    private float y;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Jogador>().tomaDano(danoEspinho);
            jogador = collision.gameObject.GetComponent<Jogador>();
            jogador.tomaDano(danoEspinho,"espinho");
            x = jogador.getPosX();
            y = jogador.getPosY();
            jogador.moveJogador(x, y);
        }
    }
}



