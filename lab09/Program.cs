using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            POCollection<PO> poCollection1 = new POCollection<PO>();
            PO po = new PO("clash royale", 2019, "ksayron");
            PO po1 = new PO("6пи2jump", 2023, "sakuraskip");
            PO po2 = new PO("genshin impact", 2020, "plesend");

            poCollection1.Add(po);
            poCollection1.Add(po1);
            poCollection1.Add(po2);

            foreach (var pos in poCollection1)
            {
                Console.WriteLine(pos.ToString());
            }

            poCollection1.Remove(2);

            foreach (var pos in poCollection1)
            {
                Console.WriteLine(pos.ToString());
            }
            Console.WriteLine();
            List<PO> list = new List<PO>();
            list.Add(po);
            list.Add(po1);
            list.Add(po2);
            foreach (var pos in list)
            {
                Console.WriteLine(pos.ToString());
            }

            Console.WriteLine(list[0].ToString());

            ObservableCollection<PO> list2 = new ObservableCollection<PO>();
            void ObserveListChanged(object? sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add: // если добавление
                        if (e.NewItems?[0] is PO po)
                            Console.WriteLine($"Добавлен новый объект: {po.name}");
                        break;
                    case NotifyCollectionChangedAction.Remove: // если удаление
                        if (e.OldItems?[0] is PO oldPo)
                            Console.WriteLine($"Удален объект: {oldPo.name}");
                        break;
                    case NotifyCollectionChangedAction.Replace: // если замена
                        if ((e.NewItems?[0] is PO replacingPO) &&
                            (e.OldItems?[0] is PO replacedPO))
                            Console.WriteLine($"Объект {replacedPO.name} заменен объектом {replacingPO.name}");
                        break;
                }
            }
            list2.CollectionChanged += ObserveListChanged;

            list2.Add(po2);

        }
    }
    }