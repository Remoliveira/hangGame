using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;

public class Jogador : MonoBehaviour
{
    public int vidaTotal = 3;
    public BarraDeVida barraDeVida;
    private float posX;
    private float posY;
    private Rigidbody2D rb;
    public GameObject vCam;

    public List<string> letrasCapturadas = new List<string>();
    

   void FixedUpdate()
    {
        var qtdLetras = letrasCapturadas.Count;
        if(qtdLetras == 4) {
            var cena = SceneManager.GetActiveScene();
            SceneManager.LoadScene(cena.name);
        }
            
        
    }

   public void Awake()
    {
        atualizaVidaUI();
    }

    public void tomaDano(int dano, string tipo)
    {
        vidaTotal -= dano;
        barraDeVida.atualizaVidas(vidaTotal);

        //Shake();
        if(tipo == "inimigo")
        {
            knockback();
        }
        

        if(vidaTotal <= 0)
        {
            morre();
        }
        //quando toma dano de espinho = transform.position para o inicio, de persnagem fica no mesmo lugar
    }

    private void morre()
    {
        Destroy(gameObject);


        var cena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cena.name);
    }

    void Shake()
    {
        vCam.GetComponent<cameraController>().cameraShake();
    }

    void knockback()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.AddForce(new Vector2(15 , 15), ForceMode2D.Impulse);
        //transform.Rotate(0f, 180f, 0f);

    }

      
    public void atualizaVidaUI()
    {
        barraDeVida.atualizaVidas(vidaTotal);
      
    }

    public void moveJogador(float x , float y)
    {
        this.transform.position = new Vector2(x, y);
    }

    public void setPosicao(float x, float y)
    {
        this.posX = x;
        this.posY = y;
    }

    public float getPosX()
    {
        return this.posX;
    }
    public float getPosY()
    {
        return this.posY;
    }

    public void adicionaLetra(string letra)
    {
        letrasCapturadas.Add(letra);
    }

    


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Player"))
    //    {
    //        return;
    //    }
    //    if (collision.gameObject.CompareTag("Inimigo"))
    //    {

    //       this.tomaDano(1);
    //    }

    //}

}
