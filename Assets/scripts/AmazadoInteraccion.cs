using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmazadoInteraccion : MonoBehaviour
{
    public float energy;
    public int requerido =10;

    [SerializeField] GameObject maza_1;
    [SerializeField] GameObject maza_2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        energy+=Time.deltaTime;
        if (energy>=requerido)
        {
            maza_1.SetActive(false);
            maza_2.SetActive(true);
        }
    }

}
