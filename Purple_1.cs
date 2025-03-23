using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_7.Purple_1;

namespace Lab_7
{
    public class Purple_1 //обязательно публичный класс при выполнении заданий 
    {

        public class Participant
        {
            //поля всегда приватные
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;

            private int _jump;
            private double _totalscore;

            //свойства - публичные для чтения приватных полей 
            public string Name { get { return _name; } } //так же как переменную но с большой буквы
            public string Surname { get { return _surname; } }
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    double[] copy = new double[_coefs.Length];
                    Array.Copy(_coefs, copy, _coefs.Length);
                    return copy;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public double TotalScore
            {
                get
                {
                    if (_jump < 4) return 0; //если не всё еще отпрыгал 
                    return _totalscore;
                }
            }

            //конструктор для инициализации полей
            public Participant(string name, string surname) //также как имя структурры 
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                for (int i = 0; i < _coefs.Length; i++)
                {
                    _coefs[i] = 2.5;
                }
                _marks = new int[4, 7];//прыжок/судья

                _jump = 0;
                _totalscore = 0;
            }

            //методы
            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || _coefs == null) return;
                for (int i = 0; i < 4; i++)
                {
                    if (coefs[i] < 2.5 || coefs[i] > 3.5) return;
                    _coefs[i] = coefs[i];
                }
            }

            public void Jump(int[] marks)
            {
                if (marks == null || _marks == null) return;
                for (int i = 0; i < 7; i++)
                {
                    _marks[_jump, i] = marks[i];
                }

                int[] copy = new int[7];
                for (int i = 0; i < copy.Length; i++)
                {
                    copy[i] = marks[i];
                }
                Array.Sort(copy);
                _totalscore += (copy.Sum() - copy[0] - copy[6]) * _coefs[_jump];

                _jump += 1;
            }

            public void Print()
            {
                Console.Write($"Name");
                Console.Write($" {Surname}");
                Console.Write($" {TotalScore}");
                Console.WriteLine();
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant copy = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = copy;
                        }
                    }
                }
            }
        }

        public class Judge
        {
            //поля
            private string _name;
            private int[] _marks;

            private int _markCounter;

            //свойства
            public string Name => _name;

            //конструктор 
            public Judge(string name, int[] marks)
            {
                _name = name;
                _marks = marks;
            }

            //методы
            public int CreateMark()
            {
                if (_marks == null) return 0;
                _markCounter++;
                return _marks[(_markCounter-1)%_marks.Length];
            }

            public void Print()
            {
                Console.Write(Name);
                foreach (int i in _marks)
                {
                    Console.Write($" {i}");
                }
                Console.WriteLine();
            }

        }

        public class Competition
        {
            //поля
            private Participant[] _participants;
            private Judge[] _judges;

            //свойтсва 
            public Participant[] Participants => _participants;
            public Judge[] Judges => _judges;

            //конструктор 
            public Competition(Judge[] judges)
            {
                _judges = judges;
                _participants = new Participant[0];
            }

            //методы
            public void Evaluate(Participant jumper)
            {
                if (_judges == null) return;

                int[] marks = new int[Judges.Length];
                for (int i = 0; i< Judges.Length; i++)
                {
                    marks[i] = Judges[i].CreateMark();
                }
                jumper.Jump(marks);
            }

            public void Add(Participant participant)
            {
                if (_participants == null) return;

                for (int i = 0; i < participant.Marks.GetLength(0); i++)
                {
                    this.Evaluate(participant);
                }

                Array.Resize(ref _participants, _participants.Length + 1);
                _participants[_participants.Length - 1] = participant;
            }

            public void Add(Participant[] participants)
            {
                if (_participants == null || participants==null) return;

                for (int j = 0; j < participants.Length; j++)
                {
                    for (int i = 0; i < participants[j].Marks.GetLength(0); i++)
                    {
                        this.Evaluate(participants[j]);
                    }

                    Array.Resize(ref _participants, _participants.Length + 1);
                    _participants[_participants.Length - 1] = participants[j];
                }
            }

            public void Sort()
            {
                Participant.Sort(_participants);
                
            }
        }
    }
}
