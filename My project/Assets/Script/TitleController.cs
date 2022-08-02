using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    
    bool[] m_isActive = { false, false };
    bool m_isopen;
    string m_id = "아이디를 입력하세요";
    string m_pass = string.Empty;
    
    string[] m_weaponList = { "단검", "한손검", "양손검", "양손도끼", "할버드", "레이저건" };
    float m_height = 30;
    int m_weaponIndex;
    void OnGUI()
    {
        if(GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 50) / 2, 200, 50), "START"))
        {
            Debug.Log("버튼 눌림");
        }
        GUILayout.BeginArea(new Rect(10, Screen.height - 300, 200, 300),GUI.skin.box);
        GUILayout.Space(10);
        GUILayout.Button("START");
        m_isActive[0] = GUILayout.Toggle(m_isActive[0], "무적모드");
        if(m_isActive[0])
        {
            GUILayout.TextArea("무적모드 활성화");
        }        
        m_isActive[1] = GUILayout.Toggle(m_isActive[1], "파워모드");
        if (m_isActive[1])
        {
            GUILayout.TextArea("파워모드 활성화");
        }
        GUILayout.Label("Id");
        m_id = GUILayout.TextField(m_id, 20);
        GUILayout.Label("Pass");
        m_pass = GUILayout.PasswordField(m_pass, '*', 8);        
        GUILayout.EndArea();
        GUILayout.BeginArea(new Rect(Screen.width - 10 - 200, Screen.height - m_height, 200, 300), GUI.skin.box);
        m_isopen = GUILayout.Toggle(m_isopen, "무기목록", GUI.skin.button);
        if(m_isopen)
        {
            m_height = 300;
            m_weaponIndex = GUILayout.SelectionGrid(m_weaponIndex, m_weaponList, 1);
        }
        else
        {
            m_height = 30;
        }
        GUILayout.EndArea();
    

    }
    // Start is called before the first frame update
    void Start()
    {
        // Screen.SetResolution(640, 480, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
