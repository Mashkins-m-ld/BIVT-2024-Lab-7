using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Purple_2
    {
        public struct Participant
        {

            // приватные поля
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            private int _result;
            // публичные свойства только для чтения 

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Distance { get { return _distance; } }
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int Result { get { return _result; } }

            //конструктор паблик 
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;

                _distance = 0;
                _marks = new int[5];

                _result = 0;

            }

            //методы 

            public void Jump(int distance, int[] marks, int target)
            {
                if (_marks == null || marks == null) return;
                _distance = distance;
                for (int i = 0; i < _marks.Length; i++)
                {
                    _marks[i] = marks[i];
                }

                int[] copy = new int[_marks.Length];
                Array.Copy(_marks, copy, _marks.Length);
                Array.Sort(copy);
                _result += (copy.Sum() - copy[0] - copy[copy.Length - 1]);
                _result += 60;
                if (_distance > target) _result += (_distance - target) * 2;
                else
                {
                    if (_result - (target - _distance) * 2 < 0) _result = 0;
                    else _result -= (target - _distance) *2;
                }



            }


            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Result < array[j + 1].Result)
                        {
                            Participant copy = array[j + 1];
                            array[j + 1] = array[j];
                            array[j] = copy;

                        }
                    }
                }

            }

            public void Print()
            {
                Console.WriteLine($"{this.Name} {this.Surname}: {this.Result}");
            }


        }

        public abstract class SkiJumping
        {
            //поля
            private string _name;
            private int _standart;
            private Participant[] _participants;

            private int _jumperCount;

            //свойства 
            public string Name => _name;
            public int Standart => _standart;
            public Participant[] Participants => _participants;

            //констуктор 
            public SkiJumping(string name, int standart)
            {
                _name = name;
                _standart = standart;

                _participants = new Participant[0];

                _jumperCount = 0;
            }

            //методы
            public void Add(Participant participant)
            {
                if (_participants == null) return;

                Array.Resize( ref _participants, _participants.Length + 1);
                _participants[_participants.Length - 1] = participant;
            }

            public void Add(Participant[] participants)
            {
                if (participants == null || _participants==null) return;
               
                for (int i = 0; i < participants.Length; i++)
                {
                    Array.Resize(ref _participants, _participants.Length + 1);
                    _participants[_participants.Length - 1] = participants[i];
                }
                
            }

            public void Jump(int distanse, int[] marks)
            {
                if (_participants == null) return;

                _participants[_jumperCount].Jump(distanse, marks, _standart);
                _jumperCount++;
            }

            public void Print()
            {
                Console.WriteLine(Name);
                Console.WriteLine(Standart);
                foreach (Participant participant in Participants)
                { 
                    participant.Print();
                }    
            }

        }

        public class JuniorSkiJumping : SkiJumping
        {
            //переопределенный конструктор 
            public JuniorSkiJumping() : base("100m", 100)
            { }
        }

        public class ProSkiJumping : SkiJumping
        {
            //переопределенный конструктор 
            public ProSkiJumping() : base("150m", 150)
            { }
        }
    }
}
