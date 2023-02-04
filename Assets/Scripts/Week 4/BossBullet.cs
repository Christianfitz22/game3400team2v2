using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    int damage;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Boss")
        {
            Debug.Log("Not boss");
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<FPSController>().takeDamage(damage);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Not player");
                Destroy(this.gameObject);
            }
        }
    }

    public void MakeBullet(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
    }
}
