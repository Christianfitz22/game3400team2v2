using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    private float speed;
    private int damage;
    private float maxSize;

    public void MakeDarkness(float speed, int damage, float maxSize)
    {
        this.speed = speed;
        this.damage = damage;
        this.maxSize = maxSize;
    }

    void Update()
    {
        Vector3 change = new Vector3(1f, 0f, 1f);
        change *= speed * Time.deltaTime;
        gameObject.transform.localScale += change;
        if (gameObject.transform.localScale.x > maxSize)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FPSController>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
