using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlacenaInteraccion : MonoBehaviour
{
    [SerializeField] GameObject harina;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Selec_Harian()
    {
        harina.SetActive(true);
    }
}
