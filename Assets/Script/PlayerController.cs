using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody rigidbody;
    [SerializeField]
    float force = 10.0f;
    
    // Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}

    private Vector3 inputVector;
    // Update is called once per frame
	void Update () {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	}

    private void FixedUpdate()
    {
        rigidbody.AddForce(inputVector*force, ForceMode.VelocityChange);
    }

}
