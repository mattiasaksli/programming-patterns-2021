using Commands;
using UnityEngine;

namespace RecorderStateMachine
{
    public class RecorderRecordState : RecorderState
    {
        public RecorderRecordState(MacroRecorder recorder) : base(recorder) { }

        public override void Enter()
        {
            Recorder.records.Clear();
            Recorder.isRecordingMacro = true;
            Recorder.isPlayingMacro = false;
            Recorder.recordStartTime = Time.time;
        }

        public override void Play()
        {
            Recorder.state = new RecorderPlayState(Recorder);
        }

        public override void Record()
        {
            Recorder.state = new RecorderIdleState(Recorder);
        }

        public override void Add(RecordedCommand recordedCommand)
        {
            if (Recorder.isRecordingMacro)
            {
                Recorder.records.Add(recordedCommand);
            }
        }
    }
}