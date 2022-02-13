using UnityEngine;

namespace Commands
{
    internal interface IExecutable
    {
        public void Execute(MonoBehaviour receiver);
    }
}
