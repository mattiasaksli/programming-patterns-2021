using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebindMenu : MonoBehaviour
{

    [SerializeField] private Text instruction;

    private ControlCard controlCard;

    public void Open(ControlCard keybindCard)
    {
        controlCard = keybindCard;
        instruction.text = $"Enter new key for\n" +
                           $"{controlCard.MyCommand.Description}";
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    //On GUI provides a convenient method to get keycodes through Event data
    void OnGUI()
    {
        if(!(Event.current.isKey && Input.anyKeyDown))
            return;
        
        controlCard.MyCommand.Key = Event.current.keyCode;
        controlCard.Refresh();
        Close();
    }

}
