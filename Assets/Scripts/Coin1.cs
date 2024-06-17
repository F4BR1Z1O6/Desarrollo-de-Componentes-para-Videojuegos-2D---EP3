using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin1 : MonoBehaviour
{
    public float rotationSpeed;
    private float actualRotation;
    public GameObject puerta;
    public RoomLightController roomLightController;

    void Update()
    {
        actualRotation += (rotationSpeed * Time.deltaTime) * 100;
        transform.eulerAngles = new Vector3(0, actualRotation, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (roomLightController != null)
            {
                roomLightController.StartIllumination();
            }

            Destroy(this.gameObject);
            puerta.SetActive(false);
        }
    }
}



