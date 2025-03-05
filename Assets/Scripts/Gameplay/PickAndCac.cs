using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndCac : MonoBehaviour
{
    public GameObject armaVerdePre;
    private bool canPickUp = false;
    private bool isPickedUp = false; // Para rastrear si el arma está equipada o no

    private void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            isPickedUp = !isPickedUp; // Alternar estado

            if (isPickedUp)
            {
                gameObject.SetActive(true);
                if (armaVerdePre != null)
                {
                    armaVerdePre.SetActive(true);
                }
            }
            else
            {
                gameObject.SetActive(false);
                if (armaVerdePre != null)
                {
                    armaVerdePre.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }
}
