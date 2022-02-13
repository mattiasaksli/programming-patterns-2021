using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject
{
    private readonly object sender;
    private readonly List<Observer> observers = new List<Observer>();

    public Subject(object sender)
    {
        this.sender = sender;
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (Observer observer in observers)
        {
            observer.SubjectUpdate(sender);
        }
    }
}