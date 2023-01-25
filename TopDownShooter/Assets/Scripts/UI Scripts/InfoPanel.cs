using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    bool isInfoPanelExtended;
    void Start()
    {
        isInfoPanelExtended = false;
        
        InputManager.InputTabEvent += SlideInfoPanel;
    }

    void Update()
    {
        
    }

    private void SlideInfoPanel(object source, InputTabArgs args)
    {
        if (isInfoPanelExtended == true) 
        {
            StartCoroutine(CollapseInfoPanel());
        }
        else
        {
            StartCoroutine(ExtendInfoPanel());
        }
    }

    private IEnumerator ExtendInfoPanel()
    {
        for (int i = 0; i < 90; i++)
        {
            this.gameObject.transform.position += new Vector3(2, 0);
            yield return new WaitForSecondsRealtime(0.0001f);
        }
        isInfoPanelExtended = true;
    }

    private IEnumerator CollapseInfoPanel()
    {
        for (int i = 0; i < 90; i++)
        {
            this.gameObject.transform.position -= new Vector3(2, 0);
            yield return new WaitForSecondsRealtime(0.0001f);
        }
        isInfoPanelExtended = false;
    }
}
