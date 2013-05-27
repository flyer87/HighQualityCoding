using System;
using System.Collections.Generic;

public class Course
{
    private List<Student> students = new List<Student>(30);

    public void AddStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException("Why do you sent me empty brain student ?!");
        }

        students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException("no student given as parameter!");
        }

        students.Remove(student);
    }

    public int  getStudentsCount()
    {
        return students.Count;
    }
}