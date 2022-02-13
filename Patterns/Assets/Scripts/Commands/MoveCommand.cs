using UnityEngine;

namespace Commands
{
    public class MoveCommand : Command, IExecutable, IUndoable, IRecordable
    {
        public override KeyCode Key { get; set; }
        public override string Description { get; }

        private Vector3 direction;

        public MoveCommand(Vector3 direction, KeyCode key, string description)
        {
            this.direction = direction;
            Key = key;
            Description = description;
        }

        public void Execute(MonoBehaviour receiver)
        {
            GridMovement snakePart = (GridMovement)receiver;
            snakePart.Walk(direction);
        }

        public void Undo(MonoBehaviour receiver)
        {
            GridMovement snakePart = (GridMovement)receiver;
            snakePart.Walk(-direction);
        }
    }
}