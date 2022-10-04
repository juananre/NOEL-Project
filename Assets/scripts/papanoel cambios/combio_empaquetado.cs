using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class combio_empaquetado : MonoBehaviour
{
    [SerializeField] GameObject empaque_1;
    [SerializeField] GameObject empaque_2;
    [SerializeField] GameObject empaque_3;
    int cambio = 2;

    // Start is called before the first frame update
    void Start()
    {
        /*p_empaque_1 = empaque_1.GetComponent<Transform>();
        p_empaque_2 = empaque_2.GetComponent<Transform>();
        p_empaque_3 = empaque_3.GetComponent<Transform>();*/


    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(cambio);
        }*/

        /*if (empaque_1 != enabled && empaque_2 != enabled && empaque_3 != enabled)
        {
            SceneManager.LoadScene(cambio);
        }

        if (p_empaque_1 == refe_empa_1 && p_empaque_2 == refe_empa_2 && p_empaque_3 == refe_empa_3)
        {
            SceneManager.LoadScene(cambio);
        }*/

        if (!empaque_1.activeSelf && !empaque_2.activeSelf && !empaque_3.activeSelf)
        {
            SceneManager.LoadScene(cambio);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(2);
        }
    }
}