using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIStepCounter : MonoBehaviour, Observer {

    Dictionary<GridMovement, int> actorSteps = new Dictionary<GridMovement, int>();
    Dictionary<GridMovement, StepCard> actorCards = new Dictionary<GridMovement, StepCard>();

    [SerializeField]
    StepCard cardPrefab;
    [SerializeField]
    Transform container;

    private readonly List<Subject> subjects = new List<Subject>();

    void Start()
    {
        foreach (GridMovement character in FindObjectsOfType<GridMovement>())
        {
            Subject subject = character.OnWalk;
            subject.AddObserver(this);
            subjects.Add(subject);
        }
    }

    void OnDestroy()
    {
        foreach (Subject subject in subjects)
        {
            subject.RemoveObserver(this);
        }
    }

    public void SubjectUpdate(object sender)
    {
        GridMovement mover = sender as GridMovement;
        if (mover == null)
        {
            return;
        }

        if (!actorSteps.ContainsKey(mover))
        {
            actorSteps.Add(mover, 0);

            var card = Instantiate(cardPrefab, container);
            card.SetName(mover.name);
            card.SetSteps(actorSteps[mover]);
            actorCards.Add(mover, card);
        }
        
        actorCards[mover].SetSteps(++actorSteps[mover]);

    }

}
