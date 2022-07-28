using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Vector3 m_dir = Vector3.left;
    [SerializeReference]
    float m_speed = 10f;
    [SerializeReference]
    Rigidbody2D m_rigidbody2D;
    public void SetBullet(Vector3 position, Vector3 diretcion)
    {
        m_dir = diretcion;
        transform.position = position;
        if (diretcion == Vector3.right)
            transform.eulerAngles = new Vector3(0f, 180f, transform.eulerAngles.z);
        else
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);
        //m_rigidbody2D.AddForce(m_dir * m_speed, ForceMode2D.Impulse);
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_dir * m_speed * Time.deltaTime;
    }
}
