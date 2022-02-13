using Commands;

namespace RecorderStateMachine
{
    public abstract class RecorderState
    {
        protected readonly MacroRecorder Recorder;

        protected RecorderState(MacroRecorder recorder)
        {
            Recorder = recorder;
        }

        public abstract void Enter();
        public abstract void Play();
        public abstract void Record();
        public abstract void Add(RecordedCommand recordedCommand);
    }
}