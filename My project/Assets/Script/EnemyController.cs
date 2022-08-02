using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator m_animator;
    int m_hp = 5;
    public void SetDamage()
    {
        m_hp--;
        m_animator.Play("Hit", 0, 0f); 
        if(m_hp <= 0f)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
}
