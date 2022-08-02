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
    [SerializeField]
    GameObject m_vfx_ExplosionPrefab;
    BoxCollider2D m_collider;
    float m_minDist;
    Vector3 m_prevPos;
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
    void CreateExplosion()
    {
        var obj = Instantiate(m_vfx_ExplosionPrefab);
        obj.transform.position = transform.position;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.transform.CompareTag("Background"))
        {
            
            
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<BoxCollider2D>();
        m_minDist = m_collider.size.y - m_collider.offset.y;
    }

    // Update is called once per frame
    void Update()
    {
        m_prevPos = transform.position;
        var moveVal = m_speed * Time.deltaTime;
        transform.position += m_dir * moveVal;
        var dir = (transform.position - m_prevPos);
        var hit = Physics2D.Raycast(m_prevPos, dir.normalized, moveVal, 1 << LayerMask.NameToLayer("Background" ) | 1 << LayerMask.NameToLayer("Enemy"));
        if(hit.collider != null)
        {
            transform.position = hit.point;
            CreateExplosion();
            Destroy(gameObject);
            if(hit.transform.CompareTag("Enemy"))
            {
                var enemy =  hit.transform.gameObject.GetComponent<EnemyController>();
                enemy.SetDamage();
            }
        }
    }
}
