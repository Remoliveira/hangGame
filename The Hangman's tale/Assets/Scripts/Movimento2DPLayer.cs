using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HangmansTale;

[RequireComponent(typeof(Controle2D))]
public class Movimento2DPLayer : MonoBehaviour
{
    public float velocidade = 30f;
    private Controle2D controle;
    private float movimentoHorizontal;
    public bool pulando;

    private void Awake(){
        
        controle = GetComponent<Controle2D>();

    }

    // Update is called once per frame
    void Update()
    {
       movimentoHorizontal = Input.GetAxisRaw("Horizontal") * velocidade;

        if (Input.GetButtonDown("Jump"))
            pulando = true;


        if (Input.GetButtonUp("Jump"))
        {
            controle.cortaPulo();
        }
           

    }

    void FixedUpdate()
    {
        controle.Movimento(movimentoHorizontal * Time.fixedDeltaTime, pulando);
        pulando = false;
    }
}
