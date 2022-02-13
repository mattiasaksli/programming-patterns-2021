using UnityEngine;

namespace Commands
{
    [System.Serializable]
    public abstract class Command
    {
        public abstract KeyCode Key { get; set; }
        public abstract string Description { get; }
    }
}