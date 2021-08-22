using System;
using System.Collections.Generic;

namespace QMediatR.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator medtr = new Mediator();
            Teacher teacher = new Teacher(medtr);
            teacher.Name = "Atakan";
            medtr.Teacher = teacher;
            Student belis = new Student(medtr);
            belis.Name = "Belinay";
            Student busra = new Student(medtr);
            busra.Name = "Büşra";
            var liststnd = medtr.Students = new List<Student>();
            liststnd.Add(belis);
            liststnd.Add(busra);
            teacher.SendNewImage("url1.jpg");
            teacher.RecieveQuestion("is a true?", busra);
            Console.ReadLine();

        }
    }
    abstract class CourseMember
    {
        protected   Mediator _mediator;
        public CourseMember(Mediator mediator)
        {
            _mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher reieved a question from {0}, {1}", student.Name, question);
        }
        public void SendNewImage(string url)
        {
            Console.WriteLine("Teacher changed slide:{0}", url);
            _mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answeered question{0},{1}", answer, student.Name);
        }
    }
    class Student:CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }
        public string Name { get; set; }
        public void RecieveImage(string imageUrl)
        {
            Console.WriteLine("Student recevied image: {0}", imageUrl);
        }

        public void RecieveAnswer(string answer, Student student)
        {
            Console.WriteLine("Student recevied answer: {0} {1}", answer, student.Name);
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }

        public void UpdateImage(string ImageUrl)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(ImageUrl);
            }
        }
        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer, student);
        }
    }

}
