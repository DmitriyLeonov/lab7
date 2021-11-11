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
        public string name;
        public Exams subject;

        public Lecturer(string name, Exams subject)
        {
            if((int)subject > 3 || (int)subject < 0)
            {
                throw new SubjectNotExistException("Данного предмета не существует");
            }
            this.name = name;
            this.subject = subject;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Subject: {subject}");
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
            int test = 1000;
            try
            {
                Lecturer math = new Lecturer("Асмыкович", 0);
                Lecturer oop = new Lecturer("Пацей", (Exams)1);
                Lecturer philosophy = new Lecturer("Подручный", (Exams)2);
                Lecturer computerNetworks = new Lecturer("Миронов", (Exams)6);
                Exam mathExam = new Exam("", "Математика", math, DateTime.Now.AddDays(-50));
                Exam oopExam = new Exam("", "ООП", oop, DateTime.Now.AddDays(55));
                Exam philosophyExam = new Exam("", "", philosophy, DateTime.Now.AddDays(61));
                Exam computerNetworksExam = new Exam("", "Компьютерные сети", computerNetworks, DateTime.Now.AddDays(66));
                controller.AddExam(null);
                controller.AddExam(oopExam);
                controller.AddExam(philosophyExam);
                controller.AddExam(computerNetworksExam);
                controller.PrintExamList();
                Console.WriteLine(controller.CountExperiments());
                Console.WriteLine(controller.CountTests(tests, 21));
                test = test / 0;
                throw new InvalidCastException();
            }
            catch(DateException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(SubjectMissingException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(SubjectNotExistException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch {
                Console.WriteLine("Возникла непредвиденная ошибка");
            }
            finally {
                Console.ReadLine(); 
            }
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
            if (subject == null || subject == "")
            {
                throw new SubjectMissingException("Не указан предмет экзамена");
            }
            Subject = subject;
            Lecturer = lecturer;
            if (examDate <= DateTime.Now)
            {
                throw new DateException("Дата проведения экзамена должна быть позже сегодняшней");
            }
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
