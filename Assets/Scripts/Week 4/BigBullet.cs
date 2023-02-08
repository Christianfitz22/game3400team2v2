using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    [SerializeField]
    float speed;

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
            if (other.gameObject.tag == "Cover")
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Not cover");
                Destroy(this.gameObject);
            }
        }
    }

    public void MakeBullet(float speed)
    {
        this.speed = speed;
    }
}
