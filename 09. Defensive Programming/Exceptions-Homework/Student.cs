﻿using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IList<Exam> Exams { get; set; }

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (firstName == null)
        {
            throw new ArgumentNullException("First name cannot be empty or null!");
        }

        if (lastName == null)
        {
            throw new ArgumentNullException("Last name cannot be empty or null!");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException(string.Format(
                "There are no exams for student {0} to calculate average!", this.FirstName + " " + this.LastName));
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentOutOfRangeException(string.Format(
                "There are no exams for student {0} to calculate average!", this.FirstName + " " + this.LastName));
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {

        if (this.Exams == null)
        {
            throw new ArgumentNullException("There is no exams for student {0}", this.FirstName + " " + this.LastName);
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentNullException("There is no exams for student {0}", this.FirstName + " " + this.LastName);
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
