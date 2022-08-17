using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    IEnumerator Coroutine_DrawMessage()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Hello world");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        Debug.Log("End");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
