using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float rotationSpeed = 20;

	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
	}
}
