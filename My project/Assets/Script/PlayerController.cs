using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Inventory m_myInven;
    [SerializeField]
    GameObject m_bulletPrefab;
    [SerializeField]
    Transform m_FirePos;
    [SerializeField]
    Animator m_animator;
    [SerializeField]
    SpriteRenderer m_spriteRenderer;
   
    [SerializeField]
    float m_speed = 0.02f;
    [SerializeField]
    Rigidbody2D m_regidbody;
    Vector3 m_dir;
    float m_jumpPower = 2f;
    bool m_isGrounded;
    bool m_isFall;
    int m_jumpCount;
    

    public float Speed { get { return m_speed; } set { m_speed = value; } }
    #region Animaiton Event Methods
    void AnimEvent_CreateBUllet()
    {
        var obj = Instantiate(m_bulletPrefab);
        var bullet = obj.GetComponent<BulletController>();
        bullet.SetBullet(m_FirePos.position, transform.eulerAngles.y != 0f ? Vector3.right : Vector3.left);

    }
    #endregion

    void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (m_myInven.gameObject.activeSelf)            
                m_myInven.HideUI();            
            else            
                m_myInven.ShowUI();            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_animator.SetBool("IsFire", true);
            //CreateBUllet();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            m_animator.SetBool("IsFire", false);
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (m_jumpCount > 1) return; 
            m_regidbody.AddForce(Vector3.up * m_jumpPower, ForceMode2D.Impulse);
            m_animator.SetInteger("JumpState", 1);
            m_isFall = false;
            m_jumpCount++;
            
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_animator.SetBool("IsMove", false);
            m_dir = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_animator.SetBool("IsMove", true);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            m_dir = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_animator.SetBool("IsMove", true);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            m_dir = Vector3.right;
        }
        var stateInfo = m_animator.GetCurrentAnimatorStateInfo(0);
        if(!stateInfo.IsName("Fire"))
            gameObject.transform.position += m_dir * Speed * Time.deltaTime;
    }
    void JumpProcess()
    {
        if(m_regidbody.velocity.y < 0f && !m_isGrounded)
        {
            if(!m_isFall)
            {
                m_animator.SetInteger("JumpState", 2);
                m_isFall = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Ground"))
        {
            m_isGrounded = true;
            m_isFall = false;
            m_animator.SetInteger("JumpState", 0);
            m_jumpCount = 0;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            m_isGrounded = false;
        }
    }
    #region Unity Methods

    private void OnGUI()
    {
        if(GUI.Button(new Rect(5, 5, 100, 50), "TItle"))
        {
            LoadSceneManager.Instance.LoadSceneAsync(LoadSceneManager.SceneState.Title);
        }
    }
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
        PlayerControl();
        JumpProcess();
    }
    #endregion
}
