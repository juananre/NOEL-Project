using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tazon_control : MonoBehaviour
{
    public int conter;
    public int necesario = 0;
    public float energy_tazon;
    public int requerido = 10;

    [SerializeField] GameObject batidora;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("hola");

        if (other.CompareTag("ingredientes"))
        {
            conter++;
            Destroy(other.gameObject);

            if (conter == necesario)
            {
                batidora.SetActive(true);
            }

        }

    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("batidora") && conter == necesario)
        {
            energy_tazon += Time.deltaTime;
            if (energy_tazon >= requerido)
            {
                print("exito");
            }
        }
    }
}
