using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6f;

    private Rigidbody rb;

    private Vector3 movement;

    private float vertical;
    private float horizontal;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
      
	}

	private void FixedUpdate()
	{
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        Move(vertical, horizontal);
        Turn(vertical, horizontal);

	}

    void Move(float v, float h){
        movement.Set(h, 0, v);

        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Turn(float v,float h){
        Vector3 direction = new Vector3(h, 0f, v);

        //Si el personaje tuvo un cambio de rotacion
        if(direction != Vector3.zero){
            //Direccion a donde debe girar el personaje
            Quaternion newRotation = Quaternion.LookRotation(direction);
            rb.rotation = newRotation;
        }

    }


}
