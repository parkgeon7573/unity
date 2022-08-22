using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : SingletonDontDestroy<PopupManager>
{
    [SerializeField]
    GameObject m_popupOkCancelPrefab;
    [SerializeField]
    GameObject m_popupOkPrefab;
    const int m_startDepth = 1000;
    const int m_popupDepthGap = 10;
    List<GameObject> m_popupList = new List<GameObject>();

    public void Open_PopupOkCancel(string title, string body, string okBtnText = "Ok", string cancelBtnText = "Cancel")
    {
        var obj = Instantiate(m_popupOkCancelPrefab);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
        var panels = obj.GetComponentsInChildren<UIPanel>();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].depth = m_startDepth + m_popupList.Count * m_popupDepthGap + i;
        }
        var popup = obj.GetComponent<Popup_OkCancel>();
        popup.SetUI(title, body, okBtnText, cancelBtnText);
        m_popupList.Add(obj);
    }
    // Start is called before the first frame update
    protected override void Onstart()
    {
        m_popupOkCancelPrefab = Resources.Load<GameObject>("Popup/Popup_OkCancel");
        m_popupOkPrefab = Resources.Load<GameObject>("Popup/Popup_Ok");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Open_PopupOkCancel("Notice", "안녕하세요. 수업을 종료하시겠습니까?", "예", "아니오");
        }
    }
}
