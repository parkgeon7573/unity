using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_Ok : MonoBehaviour
{
    [SerializeField]
    UILabel m_title;
    [SerializeField]
    UILabel m_body;
    [SerializeField]
    UILabel m_okBtnLabel;
    
    // Start is called before the first frame update
    public void SetUI(string title, string body, string okBtnText = "Ok")
    {
        m_title.text = title;
        m_body.text = body;
        m_okBtnLabel.text = okBtnText;        
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
