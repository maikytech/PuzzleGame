using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform destination;

	private void OnTriggerEnter(Collider other)
	{
        if(other.CompareTag("Player")){
            other.transform.position = destination.transform.position;
            other.transform.rotation = destination.transform.rotation;
        }
	}

}
