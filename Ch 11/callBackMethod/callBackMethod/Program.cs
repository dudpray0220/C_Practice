using System;
using System.Collections.Generic;

namespace callBackMethod
{
    class Student
    {   // 변수선언
        public string Name { get; set; }
        public double Score { get; set; }

        // 생성자
        public Student(string name, double score)
        {
            this.Name = name;
            this.Score = score;
        }

        // ToString() 메서드 오버라이딩
        public override string ToString()
        {
            return this.Name + " : " + this.Score;
        }
    }

    class Students
    {
        private List<Student> listOfStudents = new List<Student>(); // 리스트 생성

        public delegate void PrintProcess(Student list); // 델리게이터 선언

        public void Add(Student student) // list에 Student 형태의 학생을 추가하는 메서드
        {
            listOfStudents.Add(student);
        }

        public void Print()
        {
            Print((student) =>
            {
                Console.WriteLine(student);
            });
        }

        public void Print(PrintProcess process) // 콜백 메서드
        {
            foreach (var item in listOfStudents)
            {
                process(item); // 콜백 메서드에 매개변수를 전달해 호출
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Students students = new Students();
            students.Add(new Student("byh", 100.1));
            students.Add(new Student("jch", 100.3));

            students.Print(); // 단순 출력
            students.Print((student) => // 출력방식 별도 지정
            {
                Console.WriteLine();
                Console.WriteLine("name: " + student.Name);
                Console.WriteLine("score: " + student.Score);
            });
        }
    }
}
