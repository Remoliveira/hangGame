using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class compInimigo : MonoBehaviour
{
    public int vida = 3;
    public int danoCausado = 1;
    public GameObject efeitoExplosao;
    public bool isLetter = false;
    public string letra;
  

    public void tomaDano(int dano)
    {
        vida -= dano;
 

        if(vida <= 0)
        {
            morre();
        }
    }

    public void morre()
    {
        Instantiate(efeitoExplosao,transform.position,transform.rotation);
        Destroy(gameObject);
     
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (isLetter)
            {
                //Debug.Log("oi");
                collision.gameObject.GetComponent<Jogador>().adicionaLetra(letra);
                Destroy(gameObject);

            }
            else
            {
                collision.gameObject.GetComponent<Jogador>().tomaDano(danoCausado, "inimigo");
            }

        }
    }

    
}
