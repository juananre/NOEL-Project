using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class papanoel_hola : MonoBehaviour
{
    [SerializeField] int skip;
    [SerializeField] int REINICIO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(skip);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(REINICIO);
        }
    }

   
}
