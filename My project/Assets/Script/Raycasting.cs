using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    Camera m_maincam;
    Ray m_ray;
    RaycastHit m_rayHit;
    GameObject m_selectObj;
    GameObject GetSelectedObject()
    {
        m_ray = m_maincam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(m_ray, out m_rayHit, 1000f))
        {
            return m_rayHit.collider.gameObject;
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            m_selectObj = GetSelectedObject();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(m_selectObj != null)
                m_selectObj.transform.localScale = Vector3.one;
            m_selectObj = null;
        }
        if(m_selectObj != null)
        {
            m_selectObj.transform.localScale = Vector3.one * 1.2f;
            Debug.DrawRay(m_ray.origin, m_ray.direction.normalized * m_rayHit.distance, Color.magenta);
        }
        else
        {
            Debug.DrawRay(m_ray.origin, m_ray.direction * 1000f, Color.green);

        }

    }
}
