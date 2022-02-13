using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;

namespace RecorderStateMachine
{
    public class MacroRecorder : MonoBehaviour
    {
        internal RecorderState state;

        internal bool isPlayingMacro;
        internal bool isRecordingMacro;
        internal float playStartTime;
        internal float recordStartTime;
        internal readonly List<RecordedCommand> records = new List<RecordedCommand>();

        private void Start()
        {
            state = new RecorderIdleState(this);
        }

        public void PlayCommands()
        {
            state.Play();
            state.Enter();
        }

        public void RecordCommands()
        {
            state.Record();
            state.Enter();
        }

        public void Add(RecordedCommand command)
        {
            state.Add(command);
        }

        public void StartMacro()
        {
            StartCoroutine(PlayMacro());
        }

        public void StopMacro()
        {
            StopCoroutine(PlayMacro());
        }

        private IEnumerator PlayMacro()
        {
            if (records.Count == 0)
            {
                isPlayingMacro = false;
            }

            int i = 0;
            while (i < records.Count || isPlayingMacro)
            {
                if (Time.time - playStartTime >= records[i].GetTimestamp() - recordStartTime)
                {
                    records[i].Execute(null);
                    i++;
                }

                if (i == records.Count || !isPlayingMacro)
                {
                    isPlayingMacro = false;

                    state = new RecorderIdleState(this);
                    state.Enter();

                    yield break;
                }

                yield return null;
            }
        }
    }
}