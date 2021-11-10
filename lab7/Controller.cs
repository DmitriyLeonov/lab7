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
            session.SetExams(exam);
        }

        public void AddCredit(Test test)
        {
            session.SetCredits(test);
        }

        public void DeleteExam(Exam exam)
        {
            session.DeleteExam(exam);
        }

        public void DeleteCredit(Test test)
        {
            session.DeleteCredit(test);
        }

        public List<Experiment> GetExamList()
        {
            return session.GetExamList();
        }

        public List<Experiment> GetCreditList()
        {
            return session.GetCreditList();
        }

        public void PrintExamList()
        {
            session.PrintExams();
        }

        public void PrintCreditList()
        {
            session.PrintCreditList();
        }

        public int CountExperiments()
        {
            return session.Exams.Count() + session.Credits.Count();
        }

        public int CountTests(List<Test> tests, int questionsCount)
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
    }
}
