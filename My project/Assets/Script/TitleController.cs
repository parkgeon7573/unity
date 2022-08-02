using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    void OnGUI()
    {
        if(GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 50) / 2, 200, 50), "START"))
        {
            Debug.Log("버튼 눌림");
        }
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
