using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTween : MonoBehaviour
{
    [SerializeField]
    AnimationCurve m_curve = AnimationCurve.Linear(0f, 0, 1f, 1f);
    
    [SerializeField]
    float m_duration = 1;
    float m_time;
    bool m_isStart;
    public Vector3 m_from;
    public Vector3 m_to;
    public void Play()
    {
        m_isStart = true;
        m_time = 0f;
    }
    public void Play(Vector3 from, Vector3 to, float duration)
    {
        m_from = from;
        m_to = to;
        m_duration = duration;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isStart)
        {
            var value = m_curve.Evaluate(m_time);
            var dir = m_from * (1f - value) + m_to * value;
            m_time += Time.deltaTime / m_duration;
            transform.position = dir;
            if (m_time > 1f)
            {
                m_time = 0f;
                m_isStart = false;
            }

        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Play();
        }
    }
}
