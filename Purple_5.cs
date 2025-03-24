using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static Lab_7.Purple_5;

namespace Lab_7
{
    public class Purple_5
    {

        public struct Response
        {
            //поля 
            private string _animal;
            private string _characterTrait;
            private string _concept;

            private string[] _answers;


            //свойства
            public string Animal => _animal;
            public string CharacterTrait => _characterTrait;
            public string Concept => _concept;
            private string[] Answers
            {
                get
                {
                    if (_answers == null) return null;

                    string[] copy = new string[_answers.Length];
                    Array.Copy(_answers, copy, _answers.Length);
                    return copy;
                }
            }

            //Конструктор 
            public Response(string animal, string characterTrait, string concept)
            {
                _animal = animal;
                _characterTrait = characterTrait;
                _concept = concept;

                _answers = new string[] { animal, characterTrait, concept };

            }

            //методы
            public int CountVotes(Response[] responses, int questionNumber)
            {
                int count = 0;
                if (responses == null || questionNumber < 1 || questionNumber > 3) return 0;
                foreach (Response response in responses)
                {
                    if (response._answers == null) return 0;
                    if (response._answers[questionNumber - 1] != null) count++;
                }
                return count;
            }

            public void Print()
            {
                Console.WriteLine($"{_animal}, {_characterTrait}, {_concept}");
            }

        }

        public class Report
        {
            //поля
            private Research[] _researches;
            private static int _researchId;

            //свойства 
            public Research[] Researches => _researches;

            //конструктор
            public Report()
            {
                _researches = new Research[0];

            }

            //cтатистический конструктор 
            static Report()
            {
                _researchId = 1;
            }

            public Research MakeResearch()
            {
                if (_researches == null || _researchId<1)
                {
                    Research problem = new Research("Хьюстон, у нас проблемы");
                    return problem;
                }

                Research newResearch = new Research($"No_{_researchId}_{DateTime.Now.Month}/{DateTime.Now.Year}");
                Array.Resize(ref _researches, _researches.Length + 1);
                _researches[_researchId-1]=newResearch;
                _researchId++;
                return newResearch;
                
            }

            public (string, double)[] GetGeneralReport(int question)
            {
                if (_researches == null) return null;

                //общее количество непустых ответов
                int count = 0;
                for (int i = 0; i< _researches.Length; i++)
                {
                    count += (_researches[i].Responses[0].CountVotes(_researches[i].Responses, question));
                }

                //получить массив уникальных ответов
                string[] answers = new string[0];
                for (int i = 0; i < _researches.Length; i++)
                {
                    for (int j = 0; j < _researches[i].Responses.Length; j++)
                    {
                        if (question == 1 && _researches[i].Responses[j].Animal != null)
                        {
                            Array.Resize(ref answers, answers.Length + 1);
                            answers[answers.Length - 1] = _researches[i].Responses[j].Animal;
                        }
                        else if (question == 2 && _researches[i].Responses[j].CharacterTrait != null)
                        {
                            Array.Resize(ref answers, answers.Length + 1);
                            answers[answers.Length - 1] = _researches[i].Responses[j].CharacterTrait;

                        }
                        else if (question == 3 && _researches[i].Responses[j].Concept != null)
                        {
                            Array.Resize(ref answers, answers.Length + 1);
                            answers[answers.Length - 1] = _researches[i].Responses[j].Concept;
                        }
                    }
                }

                string[] unic_answers = answers.Distinct().ToArray();

                //создать и заполнить массив кортежей для ответа 

                (string, double)[] result = new (string, double)[0];

                for (int i = 0; i < unic_answers.Length; i++)
                {
                    int count_response = CountAllResonseInQuestion(unic_answers[i],question);
                    (string, double) new_item = (unic_answers[i], (double)count_response / count * 100);
                    Array.Resize(ref result, result.Length+1);
                    result[result.Length - 1] = new_item;

                }

                return result;
            }


            private int CountAllResonseInQuestion(string response, int question)
            {
                if (_researches == null) return 0;

                int count = 0;
                for (int r = 0; r < _researches.Length; r++)
                {
                    if (_researches[r].Responses == null) return 0;

                    if (question == 1)
                    {
                        for (int i = 0; i < _researches[r].Responses.Length; i++)
                        {

                            if (_researches[r].Responses[i].Animal == response) count++;
                        }
                    }
                    else
                    {
                        if (question == 2)
                        {
                            for (int i = 0; i < _researches[r].Responses.Length; i++)
                            {

                                if (_researches[r].Responses[i].CharacterTrait == response) count++;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _researches[r].Responses.Length; i++)
                            {

                                if (_researches[r].Responses[i].Concept == response) count++;
                            }
                        }
                    }
                }
                return count;
            }

        }

        public struct Research
        {
            //поля
            private string _name;
            private Response[] _responses;


            //свойства
            public string Name => _name;
            public Response[] Responses => _responses;
            
            //конструктор 
            public Research(string name)
            {
                _name = name;

                _responses = new Response[0];


            }

            //методы
            public void Add(string[] answers)
            {
                if (answers == null || _responses == null) return;
                Array.Resize(ref _responses, _responses.Length + 1);
                _responses[_responses.Length - 1] = new Purple_5.Response(answers[0], answers[1], answers[2]);

            }
            public string[] GetTopResponses(int question)
            {
                if (_responses == null || question < 1 || question > 3) return null;

                string[] question_responses = new string[_responses.Length];

                if (question == 1)
                {
                    for (int i = 0, j = 0; i < _responses.Length; i++)
                    {

                        if (_responses[i].Animal == null)
                        {
                            continue;
                        }
                        question_responses[j] = _responses[i].Animal;
                        j++;
                        if (i == _responses.Length - 1)
                        {
                            Array.Resize(ref question_responses, j);
                        }
                    }
                }
                else
                {
                    if (question == 2)
                    {
                        for (int i = 0, j = 0; i < _responses.Length; i++)
                        {

                            if (_responses[i].CharacterTrait == null)
                            {
                                continue;
                            }
                            question_responses[j] = _responses[i].CharacterTrait;
                            j++;
                            if (i == _responses.Length - 1)
                            {
                                Array.Resize(ref question_responses, j);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0, j = 0; i < _responses.Length; i++)
                        {

                            if (_responses[i].Concept == null)
                            {
                                continue;
                            }
                            question_responses[j] = _responses[i].Concept;
                            j++;
                            if (i == _responses.Length - 1)
                            {
                                Array.Resize(ref question_responses, j);
                            }
                        }
                    }
                }
                string[] unic_question_responses = question_responses.Distinct().ToArray();


                int[] count_unic_question_responses = new int[unic_question_responses.Length];

                for (int i = 0; i < count_unic_question_responses.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < question_responses.Length; j++)
                    {

                        if (question_responses[j] == unic_question_responses[i]) count++;
                    }
                    count_unic_question_responses[i] = count;

                }

                for (int i = 0; i < count_unic_question_responses.Length - 1; i++)
                {
                    for (int j = 0; j < count_unic_question_responses.Length - 1 - i; j++)
                    {
                        if (count_unic_question_responses[j] < count_unic_question_responses[j + 1])
                        {
                            int copy = count_unic_question_responses[j + 1];
                            count_unic_question_responses[j + 1] = count_unic_question_responses[j];
                            count_unic_question_responses[j] = copy;

                            string copy1 = unic_question_responses[j + 1];
                            unic_question_responses[j + 1] = unic_question_responses[j];
                            unic_question_responses[j] = copy1;
                        }
                    }
                }
                string[] answer;
                if (unic_question_responses.Length > 5)
                {
                    answer = new string[5];
                    for (int i = 0; i < answer.Length; i++)
                    {
                        answer[i] = unic_question_responses[i];
                    }
                }
                else
                {
                    answer = new string[unic_question_responses.Length];
                    Array.Copy(unic_question_responses, answer, unic_question_responses.Length);
                }
                return answer;
            }

            private int CountResonseInQuestion(string response, int question)
            {
                if (_responses == null) return 0;
                int count = 0;
                if (question == 1)
                {
                    for (int i = 0; i < _responses.Length; i++)
                    {

                        if (_responses[i].Animal == response) count++;
                    }
                }
                else
                {
                    if (question == 2)
                    {
                        for (int i = 0; i < _responses.Length; i++)
                        {

                            if (_responses[i].CharacterTrait == response) count++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < _responses.Length; i++)
                        {

                            if (_responses[i].Concept == response) count++;
                        }
                    }
                }

                return count;
            }
            public void Print(int question)
            {
                string[] need = GetTopResponses(question);
                foreach (string s in need)
                {
                    Console.WriteLine($"{s} {CountResonseInQuestion(s, question)}");

                }
                Console.WriteLine("===");
            }
        }
    }
}
