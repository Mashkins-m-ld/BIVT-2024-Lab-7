using Lab_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Lab_6.Purple_4;
using static Lab_6.Purple_5;

namespace Lab_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //приведение типов 
            BaseClass objHiddenDerived = new DerivedClass("C", 4, "cat"); //так можно ("cat" - скроется ) объект типа baseclass 

            //DerivedClass obj1  = new BaseClass("A", 3); // ТАК НЕЛЬЗЯ

            //(objHiddenDerived as DerivedClass); //приведение типов

            //virtual - виртуальный метод в родительском классе virtual - override 
            // потом в наследуемом классе метод переопределяется с помощью override 
            // если new DerivedClass - то методы с override будут закреплены именно за этим объектом 
            // abtract метод - нет ничего в теле метода в базовом классе, поведение присваиваем ТОЛЬКО в детях. abstract - override

            //не можем вызывать конструктор абстрактного класса new 
            // но можем использовать конструктор ребенка и запихнуть в базовый 
            // если детей в родителей, то информация лишняя лишь скрывается 
            //is - является ли элемент типом каким-ниблкт 

            //
            //int[] a = new int[] { 3, 4, 1, 2, 1, 3, 1, 5, 3, 4, 3, 3, 3, 3, 2, 4, 1, 5, 6, 1, 2, 6, 4, 3, 2, 2, 1, 1, 3, 5, 4, 4, 5, 1, 4, 1, 6, 5, 2, 1, 4, 1, 6, 2, 4, 1, 2, 6, 5, 6, 5, 2, 2, 4, 3, 4, 1, 1, 3, 5, 5, 5, 2, 4, 1, 1, 2, 2, 2, 5, 5, 2, 3, 3, 2, 2, 3, 3, 1, 3, 4, 2, 4, 5, 3, 3, 5, 2, 1, 2, 4, 5, 5, 4, 2, 3, 2, 2, 6, 3, 1, 2, 2, 6, 6, 5, 1, 6, 6, 3, 2, 5, 4, 3, 5, 4, 5, 1, 1, 5, 3, 4, 2, 1, 1, 2, 2, 2, 4, 2, 6, 3, 4, 3, 2, 1, 3, 5, 1, 5, 6, 5, 5, 4, 2, 6, 4, 5, 4, 3, 2, 4, 6, 1, 1, 1, 3, 4, 4, 1, 6, 3, 1, 5, 1, 4, 3, 1, 4, 6, 1, 4, 5, 3, 4, 1, 2, 3, 1, 5, 4, 3, 3, 6, 2, 3, 1, 6, 3, 3, 3, 6, 6, 3, 6, 6, 6, 5, 3, 2, 6, 5, 3, 5, 4, 4, 2, 1, 2, 4, 4, 2, 2, 5, 1, 3, 1, 6, 5, 6, 1, 6, 3, 3, 3, 6, 3, 5, 4, 2, 3, 4, 6, 1, 4, 2, 1, 5, 1, 1, 3, 1, 3, 2, 6, 1, 4, 4, 6, 6, 2, 5, 3, 3, 1, 4, 5, 6, 2, 6, 4, 5, 4, 2, 3, 1, 3, 3, 4, 2, 2, 3, 6, 5, 1, 5, 5, 1, 3, 4 };
            //Console.Write("[");
            //for (int i = 0; i < a.Length; i++)
            //{
            //    if (i % 7 == 6)
            //    {
            //        Console.Write($" {a[i]},");
            //    }
            //}
            //Console.Write("]");

            //---1---
            //Purple_1.Judge[] judges = new Purple_1.Judge[] { new Purple_1.Judge("Судья1", new int[] { 3, 5, 2, 6, 3, 1, 6, 6, 1, 4, 5, 3, 3, 5, 6, 5, 4, 5, 2, 3, 6, 5, 1, 3, 4, 1, 3, 3, 6, 5, 4, 6, 3, 4, 1, 1, 3, 6, 3, 5 }),
            //new Purple_1.Judge("Судья2",new int []{ 4, 3, 4, 4, 5, 6, 2, 5, 1, 1, 2, 1, 3, 5, 3, 1, 3, 3, 2, 2, 5, 4, 1, 1, 6, 2, 6, 3, 5, 4, 2, 5, 6, 6, 1, 4, 3, 4, 3, 1 }),
            //new Purple_1.Judge("Судья3", new int []{ 1, 4, 1, 3, 4, 5, 4, 2, 3, 1, 3, 3, 5, 4, 1, 6, 5, 4, 4, 1, 5, 3, 3, 5, 1, 3, 2, 6, 3, 4, 2, 6, 3, 1, 3, 4, 1, 5, 4, 5 }),
            //new Purple_1.Judge("Судья4", new int[] {2, 3, 5, 2, 4, 2, 1, 2, 5, 2, 3, 4, 2, 2, 2, 6, 4, 2, 2, 3, 4, 2, 4, 1, 4, 1, 3, 6, 2, 2, 5, 1, 5, 4, 1, 6, 4, 4, 2, 5}),
            //new Purple_1.Judge("Судья5", new int[]{ 1, 3, 6, 2, 5, 1, 2, 4, 5, 2, 2, 2, 1, 3, 2, 3, 5, 1, 6, 5, 2, 4, 4, 4, 5, 5, 1, 3, 6, 1, 1, 6, 4, 2, 3, 6, 5, 2, 2, 1 }),
            //new Purple_1.Judge("Судья6", new int [] {3, 3, 1, 1, 1, 4, 6, 3, 5, 2, 2, 4, 2, 2, 6, 2, 1, 1, 3, 1, 6, 6, 1, 3, 3, 4, 6, 6, 5, 2, 3, 3, 2, 1, 2, 2, 6, 3, 3, 3 }),
            //new Purple_1.Judge("Судья7", new int []{ 1, 3, 2, 1, 4, 1, 5, 4, 2, 5, 3, 5, 4, 2, 6, 5, 1, 2, 4, 5, 4, 1, 6, 1, 4, 3, 3, 6, 3, 4, 1, 3, 3, 5, 6, 5, 2, 1, 6, 4}) };


            //Purple_1.Competition competition = new Purple_1.Competition(judges);
            //Purple_1.Participant[] participants = new Purple_1.Participant[] { new Purple_1.Participant("Дарья", "Тихонова"),
            //new Purple_1.Participant("Александр", "Козлов"),
            //new Purple_1.Participant("Никита", "Павлов"),
            //new Purple_1.Participant("Юрий", "Луговой"),
            //new Purple_1.Participant("Юрий", "Степанов"),
            //new Purple_1.Participant("Мария", "Луговая"),
            //new Purple_1.Participant("Виктор", "Жарков"),
            //new Purple_1.Participant("Марина", "Иванова"),
            //new Purple_1.Participant("Марина", "Полевая"),
            //new Purple_1.Participant("Максим", "Тихонов") };

            //for (int i = 0; i < participants.Length; i++)
            //{
            //    if (i == 0) participants[i].SetCriterias(new double[] { 2.58, 2.90, 3.04, 3.43 });
            //    else if (i == 1) participants[i].SetCriterias(new double[] { 2.95, 2.63, 3.16, 2.89 });
            //    else if (i == 2) participants[i].SetCriterias(new double[] { 2.56, 3.40, 2.91, 2.69 });
            //    else if (i == 3) participants[i].SetCriterias(new double[] { 2.86, 2.90, 3.19, 3.14 });
            //    else if (i == 4) participants[i].SetCriterias(new double[] { 2.81, 2.64, 2.76, 3.20 });
            //    else if (i == 5) participants[i].SetCriterias(new double[] { 2.74, 3.30, 2.94, 3.27 });
            //    else if (i == 6) participants[i].SetCriterias(new double[] { 2.57, 2.79, 2.71, 3.46 });
            //    else if (i == 7) participants[i].SetCriterias(new double[] { 3.09, 2.67, 2.90, 3.50 });
            //    else if (i == 8) participants[i].SetCriterias(new double[] { 2.65, 3.47, 3.11, 3.39 });
            //    else if (i == 9) participants[i].SetCriterias(new double[] { 3.14, 3.46, 2.96, 2.76 });
            //}

            //competition.Add(participants);
            //competition.Sort();

            //foreach (Purple_1.Participant participant in competition.Participants)
            //{
            //   participant.Print();
            //}

            //---2---
            //Purple_2.JuniorSkiJumping juniorSkiJumping = new Purple_2.JuniorSkiJumping();

            //Purple_2.Participant[] participants = new Purple_2.Participant[]
            //{
            //    new Purple_2.Participant("Оксана", "Сидорова"),
            //    new Purple_2.Participant("Полина", "Полевая"),
            //    new Purple_2.Participant("Дмитрий", "Полевой"),
            //    new Purple_2.Participant("Евгения", "Распутина"),
            //    new Purple_2.Participant("Савелий", "Луговой"),
            //    new Purple_2.Participant("Евгения", "Павлова"),
            //    new Purple_2.Participant("Егор", "Свиридов"),
            //    new Purple_2.Participant("Степан", "Свиридов"),
            //    new Purple_2.Participant("Анастасия", "Козлова"),
            //    new Purple_2.Participant("Светлана", "Свиридова")
            //};

            //juniorSkiJumping.Add(participants);

            //juniorSkiJumping.Jump(135, new int[] { 15, 1, 3, 9, 15 });
            //juniorSkiJumping.Jump(191, new int[] { 19, 14, 9, 11, 4 });
            //juniorSkiJumping.Jump(147, new int[] { 20, 9, 1, 13, 6 });
            //juniorSkiJumping.Jump(115, new int[] { 5, 20, 17, 9, 16 });
            //juniorSkiJumping.Jump(112, new int[] { 19, 8, 1, 6, 17 });
            //juniorSkiJumping.Jump(151, new int[] { 16, 12, 5, 20, 4 });
            //juniorSkiJumping.Jump(186, new int[] { 5, 20, 3, 19, 18 });
            //juniorSkiJumping.Jump(166, new int[] { 16, 12, 5, 4, 15 });
            //juniorSkiJumping.Jump(112, new int[] { 7, 4, 19, 11, 12 });
            //juniorSkiJumping.Jump(197, new int[] { 14, 3, 6, 17, 1 });

            //Purple_2.Participant.Sort(juniorSkiJumping.Participants);
            //juniorSkiJumping.Print();

            //--3--
            //Purple_3.Participant[] participants = new Purple_3.Participant[]
            //{
            //new Purple_3.Participant("Виктор", "Полевой"),
            //new Purple_3.Participant("Алиса", "Козлова"),
            //new Purple_3.Participant("Ярослав", "Зайцев"),
            //new Purple_3.Participant("Савелий", "Кристиан"),
            //new Purple_3.Participant("Алиса", "Козлова"),
            //new Purple_3.Participant("Алиса", "Луговая"),
            //new Purple_3.Participant("Александр", "Петров"),
            //new Purple_3.Participant("Мария", "Смирнова"),
            //new Purple_3.Participant("Полина", "Сидорова"),
            //new Purple_3.Participant("Татьяна", "Сидорова")};

            //Purple_3.FigureSkating figureSkating = new Purple_3.FigureSkating(new double[7]);
            //figureSkating.Add(participants);
            //for (int i = 0; i < participants.Length; i++)
            //{
            //    if (i == 0)
            //    {
            //        figureSkating.Evaluate(new double[] { 5.93, 5.44, 1.20, 0.28, 1.57, 1.86, 5.89 });
            //    }
            //    else if (i == 1)
            //    {
            //        figureSkating.Evaluate(new double[] { 1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79 });
            //    }
            //    else if (i == 2)
            //    {
            //        figureSkating.Evaluate(new double[] { 2.93, 3.10, 5.46, 4.88, 3.99, 4.79, 5.56 });
            //    }
            //    else if (i == 3)
            //    {
            //        figureSkating.Evaluate(new double[] { 4.20, 4.69, 3.90, 1.67, 1.13, 5.66, 5.40 });
            //    }
            //    else if (i == 4)
            //    {
            //        figureSkating.Evaluate(new double[] { 3.27, 2.43, 0.90, 5.61, 3.12, 3.76, 3.73 });
            //    }
            //    else if (i == 5)
            //    {
            //        figureSkating.Evaluate(new double[] { 0.75, 1.13, 5.43, 2.07, 2.68, 0.83, 3.68 });
            //    }
            //    else if (i == 6)
            //    {
            //        figureSkating.Evaluate(new double[] { 3.78, 3.42, 3.84, 2.19, 1.20, 2.51, 3.51 });
            //    }
            //    else if (i == 7)
            //    {
            //        figureSkating.Evaluate(new double[] { 1.35, 3.40, 1.85, 2.02, 2.78, 3.23, 3.03 });
            //    }
            //    else if (i == 8)
            //    {
            //        figureSkating.Evaluate(new double[] { 0.55, 5.93, 0.75, 5.15, 4.35, 1.51, 2.77 });
            //    }
            //    else if (i == 9)
            //    {
            //        figureSkating.Evaluate(new double[] { 3.86, 0.19, 0.46, 5.14, 5.37, 0.94, 0.84 });
            //    }
            //}

            //Purple_3.Participant.SetPlaces(figureSkating.Participants);
            //Purple_3.Participant.Sort(figureSkating.Participants);
            //foreach (Purple_3.Participant participant in figureSkating.Participants)
            //{
            //    participant.Print();
            //}

            //---4---
            // Создание объектов для 5 мужчин из таблицы
            //Purple_4.SkiMan Dmitriy_Ivanov = new Purple_4.SkiMan("Дмитрий", "Иванов", 294.32);
            //Purple_4.SkiMan Dmitriy_Polevoy = new Purple_4.SkiMan("Дмитрий", "Полевой", 79.26);
            //Purple_4.SkiMan Saveliy_Petrov = new Purple_4.SkiMan("Савелий", "Петров", 230.63);
            //Purple_4.SkiMan Stepan_Pavlov = new Purple_4.SkiMan("Степан", "Павлов", 292.38);
            //Purple_4.SkiMan Saveliy_Kozlov = new Purple_4.SkiMan("Савелий", "Козлов", 422.64);

            //5 женщин из таблицы
            //Purple_4.SkiWoman Polina_Lugovaya = new Purple_4.SkiWoman("Полина", "Луговая", 422.64);
            //Purple_4.SkiWoman Ekaterina_Zharkova = new Purple_4.SkiWoman("Екатерина", "Жаркова", 185.23);
            //Purple_4.SkiWoman Evgeniya_Raspuntina = new Purple_4.SkiWoman("Евгения", "Распутина", 35.16);
            //Purple_4.SkiWoman Ekaterina_Lugovaya_2 = new Purple_4.SkiWoman("Екатерина", "Луговая", 376.12);
            //Purple_4.SkiWoman Olga_Pavlova = new Purple_4.SkiWoman("Ольга", "Павлова", 467.60);


            //SkiWoman Polina_Lugovaya = new SkiWoman("Полина", "Луговая", 422.64);
            //SkiWoman Ekaterina_Zharkova = new SkiWoman("Екатерина", "Жаркова", 185.23);
            //SkiWoman Evgeniya_Raspuntina = new SkiWoman("Евгения", "Распутина", 35.16);

            //Создание экземпляров классов SkiMan
            //SkiMan Saveliy_Kozlov = new SkiMan("Савелий", "Козлов", 142.05);
            //SkiMan Dmitriy_Ivanov = new SkiMan("Дмитрий", "Иванов", 294.32);
            //SkiMan Dmitriy_Polevoy = new SkiMan("Дмитрий", "Полевой", 79.26);
            //SkiMan Saveliy_Petrov = new SkiMan("Савелий", "Петров", 230.63);
            //SkiMan Stepan_Pavlov = new SkiMan("Степан", "Павлов", 292.38);
            //SkiMan Eгор_Sviridov = new SkiMan("Егор", "Свиридов", 300.00);
            //SkiMan Aleksandr_Pavlov = new SkiMan("Александр", "Павлов", 472.11);
            //Purple_4.Group group = new Purple_4.Group("Общая группа спортсменов");
            //group.Add(new Purple_4.Sportsman[] {Stepan_Pavlov,Saveliy_Petrov,Dmitriy_Ivanov,Polina_Lugovaya,
            //    Dmitriy_Polevoy,Ekaterina_Zharkova, Evgeniya_Raspuntina,
            //    Eгор_Sviridov, Saveliy_Kozlov,Aleksandr_Pavlov });
            //group.Shuffle();
            //group.Print();

            //--4---

            Purple_5.Report report = new Purple_5.Report();
            report.MakeResearch();

            report.Researches[report.Researches.Length - 1].Add(new string[] { "Макака", null, "Манга" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Тануки", "Проницательность", "Манга" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Тануки", "Скромность", "Кимоно" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Кошка", "Внимательность", "Суши" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Сима_энага", "Дружелюбность", "Кимоно" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Макака", "Внимательность", "Самурай" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Панда", "Проницательность", "Манга" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Сима_энага", "Проницательность", "Суши" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Серау", "Внимательность", "Сакура" });

            report.MakeResearch();
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Панда", null, "Кимоно" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Сима_энага", "Дружелюбность", "Сакура" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Кошка", "Внимательность", "Кимоно" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Панда", null, "Сакура" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Кошка", "Уважительность", "Фудзияма" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Панда", "Целеустремленность", "Аниме" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Серау", "Дружелюбность", null });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Панда", null, "Манга" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Сима_энага", "Скромность", "Фудзияма" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Панда", "Проницательность", "Самурай" });
            report.Researches[report.Researches.Length - 1].Add(new string[] { "Кошка", "Внимательность", "Сакура" });

            (string, double)[] answer = report.GetGeneralReport(3);
            for (int i = 0; i < answer.Length; i++)
            {
                Console.Write($"{answer[i].Item1} {answer[i].Item2}");
                Console.WriteLine();
            }



        }
    }
}
