using UnityEngine;
using RecorderStateMachine;

namespace Commands
{
    public class PlayCommand : Command, IExecutable
    {
        public override KeyCode Key { get; set; }
        public override string Description { get; }

        private readonly MacroRecorder Recorder;

        public PlayCommand(KeyCode key, string description, MacroRecorder recorder)
        {
            Key = key;
            Description = description;
            Recorder = recorder;
        }

        public void Execute(MonoBehaviour receiver)
        {
            Recorder.PlayCommands();
        }
    }
}