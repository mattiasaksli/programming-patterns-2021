using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Commands;
using RecorderStateMachine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    // The character currently being commanded
    private GridMovement currentActor;

    // A list of all characters in the scene
    private List<GridMovement> allActors;

    [SerializeReference]
    private List<Command> commandHistory = new List<Command>();
    private int currentCommandIndex = -1;

    public readonly List<Command> Keymap = new List<Command>(); // keycode to command mapping

    private MacroRecorder macroRecorder;

    public void SetCurrentActor(GridMovement actor)
    {
        currentActor = actor;
    }

    private void Awake()
    {
        // Find all actors.
        allActors = FindObjectsOfType<GridMovement>().ToList();

        macroRecorder = GetComponent<MacroRecorder>();

        CameraMovement cameraMovement = Camera.main.GetComponentInParent<CameraMovement>();

        Keymap.Add(new MoveCommand(Vector3.up, KeyCode.W, "Move up"));
        Keymap.Add(new MoveCommand(Vector3.down, KeyCode.S, "Move down"));
        Keymap.Add(new MoveCommand(Vector3.left, KeyCode.A, "Move left"));
        Keymap.Add(new MoveCommand(Vector3.right, KeyCode.D, "Move right"));
        Keymap.Add(new SwitchCommand(KeyCode.Tab, "Switch characters", allActors, this, cameraMovement));
        Keymap.Add(new UndoCommand(KeyCode.Z, "Undo"));
        Keymap.Add(new RedoCommand(KeyCode.Y, "Redo"));
        Keymap.Add(new RecordCommand(KeyCode.R, "Start/Stop-recording", macroRecorder));
        Keymap.Add(new PlayCommand(KeyCode.P, "Play-recording", macroRecorder));
    }

    private void Update()
    {
        foreach (Command command in Keymap)
        {
            if (Input.GetKeyDown(command.Key))
            {
                ExecuteCommand(command);
            }
        }
    }

    private void ExecuteCommand(Command command)
    {
        switch (command)
        {
            case UndoCommand:
                ExecuteUndoCommand();
                break;
            case RedoCommand:
                ExecuteRedoCommand();
                break;
            default:
                ExecuteNormalCommand(command);
                break;
        }
    }

    private void ExecuteUndoCommand()
    {
        if (currentCommandIndex == -1) return; // No more commands to undo.

        IUndoable previouslyExecutedCommand = commandHistory[currentCommandIndex] as IUndoable;

        if (previouslyExecutedCommand != null)
        {
            currentCommandIndex--;
            previouslyExecutedCommand.Undo(currentActor);
        }
    }

    private void ExecuteRedoCommand()
    {
        if (currentCommandIndex == commandHistory.Count - 1) return; // No more commands to redo.

        currentCommandIndex++;
        Command commandToExecute = commandHistory[currentCommandIndex];
        (commandToExecute as IExecutable).Execute(currentActor);
    }

    private void ExecuteNormalCommand(Command command)
    {
        if (command as IRecordable != null)
        {
            // MacroRecorder itself will handle if the command gets saved or not, depending on the current recorder state
            macroRecorder.Add(new RecordedCommand(command, Time.time, currentActor));
        }

        if (command as IUndoable != null)
        {
            currentCommandIndex++;

            if (currentCommandIndex != commandHistory.Count - 1)
            {
                // The current command becomes the latest command in the command history.
                commandHistory.RemoveRange(currentCommandIndex, commandHistory.Count - currentCommandIndex);
            }

            commandHistory.Add(command);
        }

        (command as IExecutable).Execute(currentActor);
    }
}