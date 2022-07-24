using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator m_animator;
    [SerializeField]
    SpriteRenderer m_spriteRenderer;
    [SerializeField]
    float m_speed = 0.02f;
    [SerializeField]
    Rigidbody2D m_regidbody;
    Vector3 m_dir;

    public float Speed { get { return m_speed; } set { m_speed = value; } }

    void MovePlayer()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_animator.SetBool("IsMove", false);
            m_dir = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_animator.SetBool("IsMove", true);
            m_spriteRenderer.flipX = false;
            m_dir = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_animator.SetBool("IsMove", true);
            m_spriteRenderer.flipX = true;
            m_dir = Vector3.right;
        }
        gameObject.transform.position += m_dir * Speed * Time.deltaTime;
    }
    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_regidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            m_regidbody.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
            //m_regidbody.velocity += (Vector2)m_dir * m_speed * Time.fixedDeltaTime;
        }

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    #endregion
}
