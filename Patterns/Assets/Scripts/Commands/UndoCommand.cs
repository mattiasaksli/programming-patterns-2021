using UnityEngine;

namespace Commands
{
    public class UndoCommand : Command
    {
        public override KeyCode Key { get; set; }
        public override string Description { get; }

        public UndoCommand(KeyCode key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}