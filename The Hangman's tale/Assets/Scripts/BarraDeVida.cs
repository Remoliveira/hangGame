using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite imagemVida;
    public GameObject vida;
    private List<GameObject> listaVidas = new List<GameObject>();
  
    public void atualizaVidas(int totalVidas)
    {
        resetaLista();
        for (int i = 0; i < totalVidas; i++)
        {
            
            var posicao = transform.position.x + (i * 61);
            var vidas = Instantiate(vida, new Vector3(posicao, transform.position.y, 0),Quaternion.identity,this.transform);
            listaVidas.Add(vidas);
        }   
    }

    private void resetaLista()
    {
        foreach(var vidaUnica in listaVidas)
        {
            Destroy(vidaUnica);
        }
    }
}
