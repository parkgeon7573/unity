using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;

public class LoadSceneManager : SingletonDontDestroy<LoadSceneManager>
{

    public enum SceneState
    {
        None = -1,
        Title,
        Lobby,
        Game,
        Max
    }
   
    [SerializeField]
    GameObject m_loadingObj;
    UIProgressBar m_loadingBar;
    UILabel m_loadingPregress;
    AsyncOperation m_loadingInfo;
    StringBuilder m_sb = new StringBuilder();
    SceneState m_state;
    SceneState m_loadState = SceneState.None;
    float m_time;

    public void LoadSceneAsync(SceneState state)
    {
        m_loadingObj.SetActive(true);
        if (m_loadState != SceneState.None) return;
        m_loadState = state;
        m_loadingInfo = SceneManager.LoadSceneAsync((int)m_loadState);

    }

    void CloseUI()
    {
        m_loadingObj.SetActive(false);
    }    
    // Start is called before the first frame update
    protected override void Onstart()
    {
        m_loadingObj.SetActive(false);
        m_loadingBar = m_loadingObj.GetComponentInChildren<UIProgressBar>();
        m_loadingPregress = m_loadingObj.GetComponentInChildren<UILabel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_loadingInfo != null)
        {
            if (m_loadingInfo.isDone)
            {                
                m_state = m_loadState;
                m_loadState = SceneState.None;
                m_loadingBar.value = 1;
                m_sb.Append("100%");
                m_loadingPregress.text = m_sb.ToString();
                m_sb.Clear();
                m_time += Time.deltaTime;
                if(m_time > 1f)
                {
                    CloseUI();
                    m_loadingInfo = null;
                    m_time = 0;
                }
            }
            else
            {
                m_loadingBar.value = m_loadingInfo.progress;
                m_sb.Append(Mathf.CeilToInt(m_loadingInfo.progress * 100.0f));
                m_sb.Append('%');
                m_loadingPregress.text = m_sb.ToString();
                m_sb.Clear();
                
            }
        }
    }
}
