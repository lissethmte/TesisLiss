using UnityEngine;
using UnityEngine.VFX;

public class DisparoVFX : MonoBehaviour
{
    public VisualEffect efectoDisparo; // Referencia al VFX del disparo
    public GameObject objetoVFXDisparo; // Referencia al objeto del VFX del disparo
    public float duracionVFXDisparo = 0.5f; // Duración del VFX del disparo

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Detecta el disparo (fire 1)
        {
            Disparar();
        }
    }

    void Disparar()
    {
        if (efectoDisparo != null && objetoVFXDisparo != null)
        {
            objetoVFXDisparo.SetActive(true);
            efectoDisparo.Play();
            Invoke("DetenerVFXDisparo", duracionVFXDisparo);
        }
    }

    void DetenerVFXDisparo()
    {
        if (efectoDisparo != null && objetoVFXDisparo != null)
        {
            efectoDisparo.Stop();
            objetoVFXDisparo.SetActive(false);
        }
    }
}