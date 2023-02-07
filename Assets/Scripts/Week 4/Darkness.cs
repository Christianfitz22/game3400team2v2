using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    private float speed = 1f;
    private int damage = 1;
    private float maxSize = 20f;

    public void MakeDarkness(float speed, int damage, float maxSize)
    {
        this.speed = speed;
        this.damage = damage;
        this.maxSize = maxSize;
    }

    void Update()
    {
        Vector3 change = new Vector3(1f, 0f, 1f);
        change *= Time.deltaTime;
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
        }
    }

}
