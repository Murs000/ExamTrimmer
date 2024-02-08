using System.IO;
using System.Security.Cryptography.X509Certificates;
string exam = File.ReadAllText(@"C:\Users\asus\Desktop\Steqo.txt");
exam = exam.Replace("\r","");
exam = exam.Replace("\t", "");
//exam = exam.Replace(" ", "");
exam = exam.Replace(".", "");
//exam = exam.Replace("1", "");
//exam = exam.Replace("2", "");
string[] questions = exam.Split('\n');
questions = questions.Select(x => x.Trim()).ToArray();
questions = questions.Where(x => x.StartsWith('3') || x.StartsWith('4') || x.StartsWith('1') || x.StartsWith('2')).ToArray();
questions = questions.Select(x => x.Trim('3','4', '1', '2', ' ')).ToArray();
questions = questions.Where(x => x != String.Empty).ToArray();
string[] uniqueQuestions = new string[questions.Length];
int i = 0;
foreach (string question in questions)
{
    int n = 0;
    foreach (string question1 in questions)
    {
        if(question == question1)
        {
            n++;
        }
    }
    uniqueQuestions[i] = question + $" - {n}";
    i++;
}
uniqueQuestions = uniqueQuestions.Distinct().ToArray();
uniqueQuestions = uniqueQuestions.OrderBy(x => x.Last()).ToArray();
uniqueQuestions = uniqueQuestions.Reverse().ToArray();
//File.Delete(@"C:\Users\asus\Desktop\ITExamQuestions.txt");
File.AppendAllLines(@"C:\Users\asus\Desktop\Steqoquestions.txt", uniqueQuestions);