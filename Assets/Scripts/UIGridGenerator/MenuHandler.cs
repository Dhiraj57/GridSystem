using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GridHandler gridHandler;
    [SerializeField] GameObject menuPanel;
    [SerializeField] Slider slider_AOI;
    [SerializeField] Slider slider_Columns;
    [SerializeField] Slider slider_Rows;
    [SerializeField] Text text_AOI;
    [SerializeField] Text text_Columns;
    [SerializeField] Text text_Rows;


    void Start()
    {
        // Binding functions to OnValueChanged function to update row, column and AOI values.
        if(gridHandler && slider_AOI && slider_Columns && slider_Rows)
        {
            slider_AOI.onValueChanged.AddListener(delegate { UpdateAOINumber(); });
            slider_Columns.onValueChanged.AddListener(delegate { UpdateColumnNumber(); });
            slider_Rows.onValueChanged.AddListener(delegate { UpdateRowNumber(); });

            SetInitialValues();
        }
    }

    // To set initial values of row, column and AOI of slider.
    void SetInitialValues()
    {
        slider_AOI.value = gridHandler.GetAreaOfInterest();
        slider_Columns.value = gridHandler.GetColumnNumber();
        slider_Rows.value = gridHandler.GetRowNumber();

        text_AOI.text = "Area Of Interest : " + slider_AOI.value;
        text_Columns.text = "Columns : " + slider_Columns.value;
        text_Rows.text = "Rows : " + slider_Rows.value;
    }

    // To update AOI value as per slider value.
    void UpdateAOINumber()
    {
        if(gridHandler && text_AOI)
        {
            gridHandler.SetAreaOfInterest((int)slider_AOI.value);
            text_AOI.text = "Area Of Interest : " + slider_AOI.value;
        }
    }

    // To update column number as per slider value.
    void UpdateColumnNumber()
    {
        if(gridHandler && text_Columns)
        {
            gridHandler.SetColumnNumber((int)(slider_Columns.value));
            text_Columns.text = "Columns : " + slider_Columns.value;
        }
    }

    // To update row number as per slider value.
    void UpdateRowNumber()
    {
        if(gridHandler && text_Rows)
        {
            gridHandler.SetRowNumber((int)(slider_Rows.value));
            text_Rows.text = "Rows : " + slider_Rows.value;
        }
    }

    // To open menu panel.
    public void MenuButton()
    {
        if(menuPanel && gridHandler)
        {
            gridHandler.canOpenTile = false;
            menuPanel.SetActive(true);
        }
    }

    // To create new grid.
    public void NewGrid()
    {
        if(gridHandler)
        {
            gridHandler.GenerateUIGrid();
            Back();
        }
    }

    // To close menu panel.
    public void Back()
    {
        if(menuPanel)
        {
            menuPanel.SetActive(false);
            StartCoroutine(ChangeTileState());
        }
    }

    IEnumerator ChangeTileState()
    {
        yield return null;
        gridHandler.canOpenTile = true;
    }
}
