using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atira : MonoBehaviour
{
    [SerializeField]
    private Transform posicao;
    [SerializeField]
    private GameObject pedra;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            cmdAtira();
        }
    }

    private void cmdAtira()
    {
        Instantiate(pedra, posicao.position, posicao.rotation);
    }
}
