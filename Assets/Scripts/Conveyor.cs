using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<CharacterController>().Move(transform.forward * speed * Time.deltaTime);
        //other.gameObject.transform.position += transform.forward * speed * Time.deltaTime;
        //other.gameObject.GetComponent<PlayerController>().AddVelocity(transform.forward * speed * Time.deltaTime);
        //other.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
    }
}
