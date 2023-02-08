using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private GameObject lightSource;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        lightSource = transform.GetChild(0).gameObject;
        lightSource.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(player.position, transform.position) < 3f)
            {
                lightSource.SetActive(true);
            }
        }
    }
}
