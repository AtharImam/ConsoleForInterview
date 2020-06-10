using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleForInterview
{
    public class EnumeratorExample
    {
        public static void Execute()
        {
            Spectrum spectrum = new Spectrum();
            foreach (string color in spectrum)
                Console.WriteLine(color);
        }

        public static void Execute1()
        {
            StoreData list = new StoreData();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            foreach (var item in list)
            {
                Console.WriteLine(item);
                if (item != null && Convert.ToInt32(item) == 2)
                {
                    break;
                }
            }

            Console.WriteLine("*****************************");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            IEnumerator enumerator = list.GetEnumerator();

            Console.WriteLine("*****************************");
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
                if (Convert.ToInt32(enumerator.Current) == 3)
                {
                    break;
                }
            }

            Console.WriteLine("*****************************");
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            Console.ReadLine();
        }

        class ColorEnumerator : IEnumerator
        {
            string[] _colors;
            int _position = -1;
            public ColorEnumerator(string[] theColors) // Constructor
            {
                _colors = new string[theColors.Length];
                for (int i = 0; i < theColors.Length; i++)
                    _colors[i] = theColors[i];
            }
            public object Current // Implement Current.
            {
                get
                {
                    if (_position == -1)
                        throw new InvalidOperationException();
                    if (_position >= _colors.Length)
                        throw new InvalidOperationException();
                    return _colors[_position];
                }
            }
            public bool MoveNext() // Implement MoveNext.
            {
                if (_position < _colors.Length - 1)
                {
                    _position++;
                    return true;
                }
                else
                    return false;
            }
            public void Reset() // Implement Reset.
            {
                _position = -1;
            }
        }

        class Spectrum : IEnumerable
        {
            string[] Colors = { "violet", "blue", "cyan", "green", "yellow", "orange", "red" };
            public IEnumerator GetEnumerator()
            {
                return new ColorEnumerator(Colors);
            }
        }

        class StoreData : IEnumerable
        {
            LinkedList<int> items = new LinkedList<int>();
            public void Add(int i)
            {
                items.AddLast(i);
            }
            public IEnumerator GetEnumerator()
            {
                foreach (var item in items)
                {
                    yield return item;
                }
            }
        }
    }
}
