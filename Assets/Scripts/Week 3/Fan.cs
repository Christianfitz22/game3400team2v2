using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField]
    private float strength;

    private void OnTriggerStay(Collider other)
    {
        //other.gameObject.GetComponent<CharacterController>().Move(transform.up * strength * Time.deltaTime);
        other.gameObject.GetComponent<PlayerController>().AddVelocity(transform.up * strength);
    }
}
