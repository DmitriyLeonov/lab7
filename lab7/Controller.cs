using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Controller
    {
        private Session session = new Session();

        public void AddExam(Exam exam)
        {
            try
            {
                session.SetExams(exam);
            }
            finally { }
        }

        public void AddCredit(Test test)
        {
            try
            {
                session.SetCredits(test);
            }
            finally { }
        }

        public void DeleteExam(Exam exam)
        {
            try
            {
                session.DeleteExam(exam);
            }
            finally { }
        }

        public void DeleteCredit(Test test)
        {
            try { 
                session.DeleteCredit(test);
            }
            finally { }
        }

        public List<Experiment> GetExamList()
        {
            try
            {
                return session.GetExamList();
            }
            finally { }
        }

        public List<Experiment> GetCreditList()
        {
            try
            {
                return session.GetCreditList();
            }
            finally { }
        }

        public void PrintExamList()
        {
            try
            {
                session.PrintExams();
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { }
        }

        public void PrintCreditList()
        {
            try
            {
                session.PrintCreditList();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { }
        }

        public int CountExperiments()
        {
            try
            {
                return session.Exams.Count() + session.Credits.Count();
            }
            finally { }
        }

        public int CountTests(List<Test> tests, int questionsCount)
        {
            try
            {
                int counter = 0;
                foreach (Test test in tests)
                {
                    if (test.QuestinsCount == questionsCount)
                    {
                        counter++;
                    }
                }
                return counter;
            }
            finally { }
        }
    }
}
