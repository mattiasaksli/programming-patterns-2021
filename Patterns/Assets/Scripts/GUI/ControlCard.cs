using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;
using UnityEngine.UI;

public class ControlCard : MonoBehaviour
{

    public Command MyCommand;

    [SerializeField] private Text description;
    [SerializeField] private Text key;
    
    private RebindMenu rebindMenu;

    public void Populate(Command command, RebindMenu rebindMenu)
    {
        this.rebindMenu = rebindMenu;
        MyCommand = command;
        Refresh();
    }

    public void Rebind()
    {
        rebindMenu.Open(this);
    }

    public void Refresh()
    {
        description.text = MyCommand.Description;
        key.text = MyCommand.Key.ToString();
    }

}