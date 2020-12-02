using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gerenciaJogo : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var cena = SceneManager.GetActiveScene();
            SceneManager.LoadScene(cena.name);
        }       
    }
}
