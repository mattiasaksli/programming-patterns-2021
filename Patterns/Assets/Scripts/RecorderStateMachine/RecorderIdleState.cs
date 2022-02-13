using Commands;

namespace RecorderStateMachine
{
    public class RecorderIdleState : RecorderState
    {
        public RecorderIdleState(MacroRecorder recorder) : base(recorder) { }

        public override void Enter()
        {
            Recorder.isRecordingMacro = false;
            Recorder.isPlayingMacro = false;
            Recorder.StopMacro();
        }

        public override void Play()
        {
            Recorder.state = new RecorderPlayState(Recorder);
        }

        public override void Record()
        {
            Recorder.state = new RecorderRecordState(Recorder);
        }

        public override void Add(RecordedCommand recordedCommand) { }
    }
}