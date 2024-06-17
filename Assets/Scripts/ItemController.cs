using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public RoomLightController roomLightController; // Asigna el controlador de luz de la habitaci�n correspondiente en el inspector
    public GameObject puerta; // Asigna la puerta correspondiente en el inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (roomLightController != null)
            {
                roomLightController.StartIllumination(); // Inicia la iluminaci�n solo de la luz de esta habitaci�n
            }

            if (puerta != null)
            {
                puerta.SetActive(false); // Desactiva la puerta correspondiente
            }

            Destroy(gameObject); // Destruye el �tem
        }
    }
}

