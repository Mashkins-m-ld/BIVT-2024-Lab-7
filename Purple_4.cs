using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_7.Purple_4;

namespace Lab_7
{
    public class Purple_4
    {
        public class Sportsman
        {
            //поля 
            private string _name;
            private string _surname;
            private double _time;

            private static double[] _timeAll;

            private int _timeFlag;


            //свойтсва 
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public double Time => _time;


            //конструктор 
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;

                _time = 0;

                _timeFlag = 0;

                Array.Resize(ref _timeAll, _timeAll.Length + 1);



            }
            static Sportsman()
            {

                _timeAll = new double[0];
            }

            //методы
            public void Run(double time)
            {
                if (time <= 0 || _timeFlag == 1) return;
                _time = time;
                _timeFlag = 1;

                _timeAll[_timeAll.Length - 1] = time;
            }

            //public void Rerun(double time)
            //{
            //    if (_time == 0) return;
            //    if (_time < _timeAll.Sum() / _timeAll.Length * 0.1)
            //    {
            //        _time = time;
            //    }
            //}

            public void Print()
            {
                Console.Write($"{this.Name} {this.Surname} {_time}");

                Console.WriteLine();
            }

            public static void Sort(Sportsman[] array)
            {
                if (array == null) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j + 1].Time < array[j].Time)
                        {
                            Sportsman copy = array[j+1];
                            array[j + 1] = array[j];
                            array[j] = copy;
                        }
                    }
                }
            }

        }

        public class SkiMan : Sportsman
        {
            //конструкторы
            public SkiMan(string name,string surname):base(name, surname) { }
            public SkiMan(string name,string surname,double time) : base(name, surname) 
            {
                this.Run(time);
            }

        }

        public class SkiWoman : Sportsman
        {
            //конструкторы
            public SkiWoman(string name, string surname) : base(name, surname) { }
            public SkiWoman(string name, string surname, double time) : base(name, surname)
            {
                this.Run(time);
            }

        }

        public class Group
        {
            //поля
            private string _name;
            private Sportsman[] _sportsmen;

            private static Sportsman[] _twoGroups;

            //свойства
            public string Name { get { return _name; } }
            public Sportsman[] Sportsmen => _sportsmen;
            

            //конструкторы
            public Group(string name)
            {
                _name = name;

                _sportsmen = new Sportsman[0];

            }

            public Group(Group group)
            {

                _name = group.Name;
                _sportsmen = group.Sportsmen;

            }

            static Group()
            {
                _twoGroups = new Sportsman[0];
            }
            //методы
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null) return;
                Array.Resize(ref this._sportsmen, this._sportsmen.Length + 1);
                this._sportsmen[this._sportsmen.Length - 1] = sportsman;

                Array.Resize(ref _twoGroups, _twoGroups.Length + 1);
                _twoGroups[_twoGroups.Length - 1] = sportsman;
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null) return;
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    Array.Resize(ref this._sportsmen, this._sportsmen.Length + 1);
                    this._sportsmen[this._sportsmen.Length - 1] = sportsmen[i];

                    Array.Resize(ref _twoGroups, _twoGroups.Length + 1);
                    _twoGroups[_twoGroups.Length - 1] = sportsmen[i];
                }
            }

            public void Add(Group group)
            {
                if (_sportsmen == null) return;
                for (int i = 0; i < group._sportsmen.Length; i++)
                {
                    Array.Resize(ref this._sportsmen, this._sportsmen.Length + 1);
                    this._sportsmen[this._sportsmen.Length - 1] = group._sportsmen[i];

                    Array.Resize(ref _twoGroups, _twoGroups.Length + 1);
                    _twoGroups[_twoGroups.Length - 1] = group._sportsmen[i];
                }
            }

            public void Sort()
            {
                if (_sportsmen == null) return;
                for (int i = 0; i < _sportsmen.Length - 1; i++)
                {
                    for (int j = 0; j < _sportsmen.Length - 1 - i; j++)
                    {
                        if (_sportsmen[j].Time > _sportsmen[j + 1].Time)
                        {
                            Sportsman copy = _sportsmen[j + 1];
                            _sportsmen[j + 1] = _sportsmen[j];
                            _sportsmen[j] = copy;
                        }

                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                if (group1.Sportsmen == null || group2.Sportsmen == null) return new Group("У вас проблемки");
                Group Finalists = new Group("Финалисты");
                Finalists._sportsmen = new Sportsman[group1._sportsmen.Length + group2._sportsmen.Length];
                Console.WriteLine("===");
                int i = 0, j = 0, k = 0;
                while (i < group1._sportsmen.Length && j < group2._sportsmen.Length)
                {
                    if (group1._sportsmen[i].Time <= group2._sportsmen[j].Time)
                        Finalists._sportsmen[k++] = group1._sportsmen[i++];
                    else
                        Finalists._sportsmen[k++] = group2._sportsmen[j++];
                }
                while (i < group1._sportsmen.Length)
                    Finalists._sportsmen[k++] = group1._sportsmen[i++];
                while (j < group2._sportsmen.Length)
                    Finalists._sportsmen[k++] = group2._sportsmen[j++];


                return Finalists;
            }

            public void Print()
            {
                Console.WriteLine(_name);
                foreach (Sportsman i in _sportsmen)
                {
                    Console.WriteLine($"{i.Name} {i.Surname} {i.Time} {i is SkiMan}");
                }

            }

            public void Split(out Sportsman[] men, out Sportsman[] women)
            {
                men = new Sportsman[0];
                women = new Sportsman[0];
                if (_sportsmen == null) return;

                foreach (Sportsman sportsman in _sportsmen)
                {
                    if (sportsman is SkiMan)
                    {
                        Array.Resize(ref men, men.Length + 1);
                        men[men.Length - 1] = sportsman;
                    }
                    else 
                    {
                        Array.Resize(ref women, women.Length + 1);
                        women[women.Length - 1] = sportsman;
                    }
                }
            }

            public void Shuffle()
            {
                if (_sportsmen == null) return;
                Sort(); //отсортировали всех спорстменов группы
                Sportsman[] men, women; //объявили 
                Split(out men, out women); // разделили на мужчин и женщин

                int menIndex = 0, womenIndex = 0, index =0;

                if (men[0].Time <= women[0].Time) //если мужчина быстрее 
                {
                    while (menIndex < men.Length || womenIndex < women.Length)
                    {
                        if (menIndex < men.Length & womenIndex < women.Length)
                        {
                            _sportsmen[index] = men[menIndex];
                            index++;
                            menIndex++;
                            _sportsmen[index] = women[womenIndex];
                            index++;
                            womenIndex++;
                        }
                        else if (menIndex < men.Length)
                        {
                            _sportsmen[index] = men[menIndex];
                            index++;
                            menIndex++;
                        }
                        else
                        {
                            _sportsmen[index] = women[womenIndex];
                            index++;
                            womenIndex++;
                        }

                    }
                }
                else
                {
                    while (menIndex < men.Length || womenIndex < women.Length)
                    {
                        if (menIndex < men.Length & womenIndex < women.Length)
                        {
                            _sportsmen[index] = women[womenIndex];
                            index++;
                            womenIndex++;
                            _sportsmen[index] = men[menIndex];
                            index++;
                            menIndex++;
                        }
                        else if (menIndex < men.Length)
                        {
                            _sportsmen[index] = men[menIndex];
                            index++;
                            menIndex++;
                        }
                        else
                        {
                            _sportsmen[index] = women[womenIndex];
                            index++;
                            womenIndex++;
                        }

                    }
                }
                

            }


        }
    }
}
