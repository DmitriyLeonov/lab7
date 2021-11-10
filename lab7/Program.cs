using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    enum Exams : byte
    {
        Math,
        OOP,
        Philosophy,
        ComputerNetworks
    }

    struct Lecturer
    {
        public string Name;
        public Exams Subject;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}  Subject: {Subject}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            List<Test> tests = new List<Test>()
            {
                new Test(23),
                new Test(16),
                new Test(21),
                new Test(13),
                new Test(30),
                new Test(21),
            };
            Lecturer math, oop, philosophy, computerNetworks;
            math.Name = "Асмыкович";
            math.Subject = 0;
            oop.Name = "Пацей";
            oop.Subject = (Exams)1;
            philosophy.Name = "Подручный";
            philosophy.Subject = (Exams)2;
            computerNetworks.Name = "Миронов";
            computerNetworks.Subject = (Exams)3;
            Exam mathExam = new Exam("", "Математика", math, DateTime.Now.AddDays(50));
            Exam oopExam = new Exam("", "ООП", oop, DateTime.Now.AddDays(55));
            Exam philosophyExam = new Exam("", "Философия", philosophy, DateTime.Now.AddDays(61));
            Exam computerNetworksExam = new Exam("", "Компьютерные сети", computerNetworks, DateTime.Now.AddDays(66));
            controller.AddExam(mathExam);
            controller.AddExam(oopExam);
            controller.AddExam(philosophyExam);
            controller.AddExam(computerNetworksExam);
            controller.PrintExamList();
            Console.WriteLine(controller.CountExperiments());
            Console.WriteLine(controller.CountTests(tests, 21));
            Console.ReadLine();
        }
    }
    public abstract class Experiment
    {
        public abstract string GetTheme();

        public virtual DateTime GetDate()
        {
            return DateTime.Now.AddDays(7);
        }
    }

    class Test : Experiment, IQuestion
    {
        private string theme = "C#";
        public int QuestinsCount { get; set; }

        public Test(int count)
        {
            QuestinsCount = count;
        }

        public int CheckAnswer(int[] answers)
        {
            return 1;
        }

        string IQuestion.GetTheme()
        {
            return "Hello from interface";
        }

        public override string GetTheme()
        {
            return "Hello from class";
        }

        public override string ToString()
        {
            return theme;
        }
    }

    partial class Exam : Experiment
    {
        public Exam(string theme, string subject, Lecturer lecturer, DateTime examDate)
        {
            Theme = theme;
            Subject = subject;
            Lecturer = lecturer;
            ExamDate = examDate;
        }

        public string Theme { get; set; }
        public string Subject { get; set; }
        public Lecturer Lecturer { get; set; }
        public DateTime ExamDate { get; set; }
    }

    sealed class FinalExam : Exam
    {
        public FinalExam(string theme, string subject, Lecturer lecturer, DateTime examDate) : base(theme, subject, lecturer, examDate)
        {
            Theme = theme;
            Subject = subject;
            Lecturer = lecturer;
        }

        public new string Theme { get; set; }
        public new string Subject { get; set; }
        public new Lecturer Lecturer { get; set; }
        public override string ToString()
        {
            return this.Theme;
        }
    }

    class Printer
    {
        public void IAmPrinting(Experiment obj)
        {
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj.ToString());
        }
    }

    public interface IQuestion
    {
        int CheckAnswer(int[] answers);
        string GetTheme();
    }
}
