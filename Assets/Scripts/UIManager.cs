using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text planetNameText;
    public GameObject planetInfoPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void ClosePanel()
    {
        planetInfoPanel.SetActive(false);
    }

    public void OpenPanel(string planetName)
    {
        planetInfoPanel.SetActive(true);
        planetNameText.text = planetName;
    }

}
