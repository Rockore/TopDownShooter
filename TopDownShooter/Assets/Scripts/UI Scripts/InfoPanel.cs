using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    bool isInfoPanelExtended;
    void Start()
    {
        isInfoPanelExtended = false;
        UIManager.TabKeyPressedEvent += SlideInfoPanel;
    }

    void Update()
    {
        
    }

    private void SlideInfoPanel(object source, TabKeyPressedArgs args)
    {
        Debug.Log("SlideInfoPanel");
        if (isInfoPanelExtended == true) 
        {
            Debug.Log(isInfoPanelExtended);
            StartCoroutine(CollapseInfoPanel());
        }
        else
        {
            Debug.Log(isInfoPanelExtended);
            StartCoroutine(ExtendInfoPanel());
        }
    }

    private IEnumerator ExtendInfoPanel()
    {
        Debug.Log("Enter ExtendInfoPanel");
        for (int i = 0; i < 90; i++)
        {
            Debug.Log("Extending Info Panel");
            this.gameObject.transform.position += new Vector3(2, 0);
            yield return new WaitForSecondsRealtime(0.0001f);
        }
        isInfoPanelExtended = true;
    }

    private IEnumerator CollapseInfoPanel()
    {
        Debug.Log("Enter CollapseInfoPanel");
        for (int i = 0; i < 90; i++)
        {
            Debug.Log("Collapsing Info Panel");
            this.gameObject.transform.position -= new Vector3(2, 0);
            yield return new WaitForSecondsRealtime(0.0001f);
        }
        isInfoPanelExtended = false;
    }
}
