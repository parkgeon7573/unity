using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_OkCancel : MonoBehaviour
{
    [SerializeField]
    UILabel m_title;
    [SerializeField]
    UILabel m_body;
    [SerializeField]
    UILabel m_okBtnLabel;
    [SerializeField]
    UILabel m_cancelBtnLabel;
    // Start is called before the first frame update
    public void SetUI(string title, string body, string okBtnText = "Ok", string cancelBtnText = "Cancel")
    {
        m_title.text = title;
        m_body.text = body;
        m_okBtnLabel.text = okBtnText;
        m_cancelBtnLabel.text = cancelBtnText;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
   
}
