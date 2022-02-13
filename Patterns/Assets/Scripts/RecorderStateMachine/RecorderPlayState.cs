using Commands;
using UnityEngine;

namespace RecorderStateMachine
{
    public class RecorderPlayState : RecorderState
    {
        public RecorderPlayState(MacroRecorder recorder) : base(recorder) { }

        public override void Enter()
        {
            Recorder.playStartTime = Time.time;
            Recorder.isPlayingMacro = true;
            Recorder.isRecordingMacro = false;
            Recorder.StartMacro();
        }

        public override void Play()
        {
            Recorder.state = new RecorderIdleState(Recorder);
        }

        public override void Record()
        {
            Recorder.state = new RecorderRecordState(Recorder);
        }

        public override void Add(RecordedCommand recordedCommand) { }
    }
}