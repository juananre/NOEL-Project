using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horno_control : MonoBehaviour
{
    [SerializeField] GameObject indicador;
    [SerializeField] GameObject boton_final;
    [SerializeField] GameObject boton_inicio;

    [SerializeField] Renderer color_indicador;
    [SerializeField] Renderer color_boton_incio;
    [SerializeField] Renderer color_boton_final;

    public float tiempo_master = 0;

    bool tiempo_ini = true;
    bool parar = false;
    bool tiempo_contar = false;
    
    public int control_switch = 0;

    // Start is called before the first frame update
    void Start()
    {
        color_indicador = indicador.GetComponent<Renderer>();
        color_boton_incio = boton_inicio.GetComponent<Renderer>();
        color_boton_final = boton_final.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (tiempo_contar == true)
        {
            tiempo_master += Time.deltaTime;
        }

        if (0.001f<=tiempo_master&&tiempo_master<=5)
        {
            color_indicador.material.color = Color.red;
            control_switch = 1;
            
        }

        else if (6 <= tiempo_master && tiempo_master <= 10)
        {
            color_indicador.material.color = Color.green;
            control_switch = 2;
        }

        else if (11 <= tiempo_master && tiempo_master <= 15)
        {
            color_indicador.material.color = Color.red;
            control_switch = 3;
        }
        else if (tiempo_master > 15)
        {
            tiempo_master = 0;
            print("de nuevo");
            
        }
    }
    public void Boton_inicio()
    {
        tiempo_contar = true;

        if (tiempo_ini == true)
        {
            color_boton_incio.material.color = Color.gray;
            color_boton_final.material.color = Color.blue;
            
            tiempo_ini = false;
            

            parar = true;
        }
        
    }
    public void Boton_final()
    {

        if (parar == true)
        {
            switch (control_switch)
            {
                case 1:
                    print("galletas crudas");

                    
                    parar = false;
                    tiempo_contar = false;
                    tiempo_master = 0;
                    break;
            }
            switch (control_switch)
            {
                case 2:
                    print("galletas perfectas");

                    
                    parar = false;
                    tiempo_contar = false;
                    tiempo_master = 0;
                    break;
            }
            switch (control_switch)
            {
                case 3:
                    print("galletas quemadas");

                    
                    parar = false;
                    tiempo_contar = false;
                    tiempo_master = 0;
                    break;
            }
        }
    }

}
