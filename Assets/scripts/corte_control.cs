using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corte_control : MonoBehaviour
{
    public float energy_cortada;
    public int requerido = 10;

    [SerializeField] GameObject maza_no_cortada;
    [SerializeField] GameObject maza_cortada;


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
        energy_cortada += Time.deltaTime;
        if (energy_cortada >= requerido)
        {
            maza_no_cortada.SetActive(false);
            maza_cortada.SetActive(true);
        }
    }
}
