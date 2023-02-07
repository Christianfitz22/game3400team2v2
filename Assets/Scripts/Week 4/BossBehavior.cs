using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    private float elapsedTime;

    private GameObject player;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private int bulletDamage;
    [SerializeField]
    private GameObject darkness;
    [SerializeField]
    private float darknessSpeed;
    [SerializeField]
    private int darknessDamage;
    [SerializeField]
    private float darknessMaxSize;
    [SerializeField]
    private float darknessLowPos;
    [SerializeField]
    private float darknessHighPos;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= fireRate)
        {
            GameObject nextBullet = Instantiate(bullet, transform.position, Quaternion.FromToRotation(transform.forward, player.transform.position - transform.position));
            nextBullet.GetComponent<BossBullet>().MakeBullet(bulletSpeed, bulletDamage);
            elapsedTime = 0f;
        }
        */
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject nextBullet = Instantiate(bullet, transform.position, Quaternion.FromToRotation(transform.forward, player.transform.position - transform.position));
            nextBullet.GetComponent<BossBullet>().MakeBullet(bulletSpeed, bulletDamage);
            elapsedTime = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Vector3 darknessPos = new Vector3(transform.position.x, darknessLowPos, transform.position.z);
            GameObject nextDarkness = Instantiate(darkness, darknessPos);
            //Finish this
        }

    }
}
