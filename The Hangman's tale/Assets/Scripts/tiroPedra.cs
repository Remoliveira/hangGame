using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroPedra : MonoBehaviour
{
    public float velocidade;
    public int dano = 1;
    public GameObject efeitoImpacto;

    public float tempoBala = .6f;

    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * velocidade;

       


    }

    void FixedUpdate()
    {
        tempoBala -= Time.deltaTime;
        if (tempoBala <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("letra"))
        {
            return;
        }
        if (collision.gameObject.tag.Equals("Inimigo"))
        {
            var inimigoObj = collision.GetComponent<compInimigo>();
            inimigoObj.tomaDano(dano);
        }
        Instantiate(efeitoImpacto, transform.position, transform.rotation); 
        Destroy(gameObject);
    }


    


}
