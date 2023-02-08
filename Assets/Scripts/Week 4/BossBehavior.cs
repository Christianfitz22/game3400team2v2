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
    [SerializeField]
    private GameObject bigBullet;
    [SerializeField]
    private float bigBulletSpeed;

    private Vector3 startPos;
    private Vector3 targetPos;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float moveRange;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        elapsedTime = 0f;
        targetPos = transform.position;
        startPos = transform.position;
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

        // fire normal bullet
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject nextBullet = Instantiate(bullet, transform.position, Quaternion.FromToRotation(transform.forward, player.transform.position - transform.position));
            nextBullet.GetComponent<BossBullet>().MakeBullet(bulletSpeed, bulletDamage);
        }

        // fire cover killing bullet
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject nextBullet = Instantiate(bigBullet, transform.position, Quaternion.FromToRotation(transform.forward, player.transform.position - transform.position));
            nextBullet.GetComponent<BigBullet>().MakeBullet(bigBulletSpeed);
        }

        // summon darkness AOE in the low position
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Vector3 darknessPos = new Vector3(transform.position.x, darknessLowPos, transform.position.z);
            GameObject nextDarkness = Instantiate(darkness, darknessPos, Quaternion.identity);
            nextDarkness.GetComponent<Darkness>().MakeDarkness(darknessSpeed, darknessDamage, darknessMaxSize);
        }

        // summon darkness AOE in the high position
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 darknessPos = new Vector3(transform.position.x, darknessHighPos, transform.position.z);
            GameObject nextDarkness = Instantiate(darkness, darknessPos, Quaternion.identity);
            nextDarkness.GetComponent<Darkness>().MakeDarkness(darknessSpeed, darknessDamage, darknessMaxSize);
        }

        // sends boss to random location
        if (Input.GetKeyDown(KeyCode.T))
        {
            targetPos = new Vector3(Random.Range(startPos.x - moveRange, startPos.x + moveRange), transform.position.y, Random.Range(startPos.z - moveRange, startPos.z + moveRange));
        }
        // sends boss back to center
        if (Input.GetKeyDown(KeyCode.C))
        {
            targetPos = startPos;
        }

        if (!targetPos.Equals(transform.position))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }

    }
}
