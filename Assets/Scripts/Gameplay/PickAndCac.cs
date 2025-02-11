using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndCac : MonoBehaviour
{
    
    public GameObject armaVerdePre;

    
   
    public bool canPickUp = false;

    private void Update()
    {
        
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            
            gameObject.SetActive(false);

            
            if (armaVerdePre != null)
            {
                armaVerdePre.SetActive(true);
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