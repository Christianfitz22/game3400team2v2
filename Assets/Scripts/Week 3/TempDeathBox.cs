using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDeathBox : MonoBehaviour
{
    [SerializeField]
    private float offTime;
    [SerializeField]
    private float onTime;
    [SerializeField]
    private bool active;
    [SerializeField]
    private float elapsedTime;

    private MeshRenderer render;
    private BoxCollider boxCollider;

    void Start()
    {
        render = gameObject.GetComponent<MeshRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        elapsedTime = 0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (active)
        {
            if (elapsedTime >= onTime)
            {
                render.enabled = false;
                boxCollider.enabled = false;
                active = false;
                elapsedTime = 0f;
            }
        }
        else
        {
            if (elapsedTime >= offTime)
            {
                render.enabled = true;
                boxCollider.enabled = true;
                active = true;
                elapsedTime = 0f;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerController>().Respawn();
    }
}
