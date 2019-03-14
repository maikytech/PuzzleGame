using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float velocity;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //Rotar en el eje y, a la velocidad de 120, rotar en las coordenadas del mundo.
        transform.Rotate(Vector3.up, Time.deltaTime * velocity, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.PickCoin();
            Destroy(gameObject);
        }
    }
}
