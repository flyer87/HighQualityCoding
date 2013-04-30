using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade cannot be negative!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Minimum grade cannot be negative!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("Maximum grade should be bigger than minimal grade!");
        }

        if (comments == null || comments == "")
        {
            throw new ArgumentNullException("Comment cannot be empty string or null!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
