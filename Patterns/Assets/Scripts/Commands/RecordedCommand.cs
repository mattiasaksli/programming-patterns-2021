using UnityEngine;

namespace Commands
{
    public class RecordedCommand : Command, IExecutable
    {
        public override KeyCode Key { get; set; }
        public override string Description { get; }

        private Command recordedCommand;
        private float timestamp;
        private MonoBehaviour receiver;

        public RecordedCommand(Command recordedCommand, float timestamp, MonoBehaviour receiver)
        {
            this.recordedCommand = recordedCommand;
            this.timestamp = timestamp;
            this.receiver = receiver;
        }

        public float GetTimestamp()
        {
            return timestamp;
        }

        public Command GetRecordedCommand()
        {
            return recordedCommand;
        }

        public void Execute(MonoBehaviour _ignored)
        {
            (recordedCommand as IExecutable).Execute(receiver);
        }
    }
}