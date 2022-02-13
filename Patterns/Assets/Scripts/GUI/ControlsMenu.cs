using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{

    [Header("Widgets")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject scrollContent;
    [SerializeField] private RebindMenu rebindMenu;

    [Header("Prefabs")]
    [SerializeField] private ControlCard controlCardPrefab;

    private InputHandler inputHandler;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = FindObjectOfType<InputHandler>();
        if (inputHandler == null)
        {
            gameObject.SetActive(false);
            return;
        }
        foreach (Command command in inputHandler.Keymap)
        {
            ControlCard card = Instantiate(controlCardPrefab, scrollContent.transform);
            card.Populate(command, rebindMenu);
        }
        Close();
    }

    public void Open()
    {
        mainPanel.SetActive(true);
        inputHandler.enabled = false;
    }

    public void Close()
    {
        mainPanel.SetActive(false);
        rebindMenu.Close();
        inputHandler.enabled = true;
    }

}
