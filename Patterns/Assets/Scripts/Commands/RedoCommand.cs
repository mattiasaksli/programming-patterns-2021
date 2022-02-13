using UnityEngine;

namespace Commands
{
    public class RedoCommand : Command
    {
        public override KeyCode Key { get; set; }
        public override string Description { get; }

        public RedoCommand(KeyCode key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}