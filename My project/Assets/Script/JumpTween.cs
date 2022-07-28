using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTween : MonoBehaviour
{
    [SerializeField]
    AnimationCurve m_curveX = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    [SerializeField]
    AnimationCurve m_curveY = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    [SerializeField]
    float m_duration = 1f;
    [SerializeField]
    float m_height = 2f;
    float m_time;
    bool m_isStart;
    public Vector3 m_from;
    public Vector3 m_to;

    void Play()
    {
        m_isStart = true;
        m_time = 0f;
    }
    void Play(Vector3 from, Vector3 to, float duration, float height)
    {
        m_from = from;
        m_to = to;
        m_duration = duration;
        m_height = height;
        Play();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_isStart)
        {
            var valueX = m_curveX.Evaluate(m_time);
            var valueY = m_curveY.Evaluate(m_time);
            var dir = (m_from * (1f - valueX) + m_to * valueX) + Vector3.up * valueY * m_height;
            m_time += Time.deltaTime / m_duration;
            transform.position = dir;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_from = transform.position;
            m_to = transform.position + Vector3.right * 6f;
            Play();
        }
    }
}
