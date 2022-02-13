using UnityEngine;

namespace Commands
{
    internal interface IUndoable
    {
        public void Undo(MonoBehaviour receiver);
    }
}
