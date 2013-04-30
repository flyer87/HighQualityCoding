using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }        
        public DateTime Birthday { get; private set; }
        public string Town { get; private set; }
        public string Hobby { get; private set; }
        public string OtherInfo { get; private set; }

        public Student(string firstName, string lastName, DateTime birthday, string town = "", string hobby = "", string otherInfo = "")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
            this.Town = town;
            this.Hobby = hobby;
            this.OtherInfo = otherInfo;
        }

        public bool IsOlderThan(Student student)
        {
            return this.Birthday > student.Birthday;
        }
    }
}
