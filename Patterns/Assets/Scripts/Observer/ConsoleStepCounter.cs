using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConsoleStepCounter : MonoBehaviour, Observer
{
    Dictionary<GridMovement, int> actorSteps = new Dictionary<GridMovement, int>();

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
        }

        actorSteps[mover]++;
        Debug.LogFormat("{0} has made step #{1}", mover.name, actorSteps[mover]);
    }
}