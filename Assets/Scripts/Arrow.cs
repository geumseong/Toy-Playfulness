using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody2D rb;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "target") {
            Debug.Log("target hit");
            ParticleSystem e = Instantiate(ps);
            e.transform.position = new Vector2(transform.position.x, transform.position.y);
            e.Play();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "wall") {
            Debug.Log("wall hit");
            Destroy(gameObject);
        }
    }
}
