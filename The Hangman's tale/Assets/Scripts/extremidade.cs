using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extremidade : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D colission)
    {
        if (colission.tag.Equals("Player"))
        {
            var jogador = colission.GetComponent<Jogador>();
            jogador.tomaDano(3,"extremidade");
        }
    }
}
