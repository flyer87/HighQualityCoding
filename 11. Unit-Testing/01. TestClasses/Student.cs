using System;
using System.Collections.Generic;

public class Student
{
    private string name;
    private int id;
    private List<int> notes = new List<int>();

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Name can't be empty!");
            }
            name = value;
        }
    }

    public int Id
    {
        get { return id; }
        set
        {
            if (value < 10000 || value > 99999)
            {
                throw new ArgumentOutOfRangeException("ID should be in interval [10000;99999]");
            }

            id = value;
        }
    }

    public void AddNote(int note)
    {
        notes.Add(note);
    }

    public float CalcAverageNote()
    {
        float sum = 0;
        for (int i = 0; i < notes.Count; i++)
        {
            sum += notes[i];
        }

        return sum / notes.Count;
    }
}
