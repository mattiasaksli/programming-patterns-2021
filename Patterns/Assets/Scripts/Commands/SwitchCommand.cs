using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class SwitchCommand : Command, IExecutable, IUndoable
    {
        public override KeyCode Key { get; set; }
        public override string Description { get; }

        private List<GridMovement> snakeHeadActors;
        private InputHandler inputHandler;
        private CameraMovement cameraMovement;

        public SwitchCommand(KeyCode key, string description, List<GridMovement> snakeHeadActors, InputHandler inputHandler,
            CameraMovement cameraMovement)
        {
            Key = key;
            Description = description;
            this.snakeHeadActors = snakeHeadActors;
            this.inputHandler = inputHandler;
            this.cameraMovement = cameraMovement;
        }

        public void Execute(MonoBehaviour receiver)
        {
            GridMovement snakeHead = (GridMovement)receiver;
            int index = snakeHeadActors.FindIndex(element => element.Equals(snakeHead));
            index++;
            if (index >= snakeHeadActors.Count)
            {
                index = 0;
            }

            GridMovement nextSnakeHead = snakeHeadActors[index];
            inputHandler.SetCurrentActor(nextSnakeHead);

            cameraMovement.SetTarget(nextSnakeHead.transform);
        }

        public void Undo(MonoBehaviour receiver)
        {
            GridMovement snakeHead = (GridMovement)receiver;
            int index = snakeHeadActors.FindIndex(element => element.Equals(snakeHead));
            index--;
            if (index < 0)
            {
                index = snakeHeadActors.Count - 1;
            }

            GridMovement nextSnakeHead = snakeHeadActors[index];
            inputHandler.SetCurrentActor(nextSnakeHead);

            cameraMovement.SetTarget(nextSnakeHead.transform);
        }
    }
}