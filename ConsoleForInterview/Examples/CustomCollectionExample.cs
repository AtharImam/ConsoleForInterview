using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleForInterview.Examples
{
    public class CollectionEnumerator : IEnumerator
    {
        public List<string> StringList;
        public int Counter = -1;

        public CollectionEnumerator(string parameter)
        {
            StringList = parameter.Split(' ').ToList();
        }

        public bool MoveNext()
        {
            Counter++;
            Console.WriteLine("Inside MoveNext Method : " + Counter);
            return Counter != StringList.Count;
        }

        public void Reset()
        {
            Console.WriteLine("Inside Reset Method");
        }

        public object Current
        {
            get
            {
                Console.WriteLine("Inside Current Property : " + StringList[Counter]);
                return StringList[Counter];
            }
        }
    }
    public class CollectionClass : IEnumerable
    {
        private string _parameter;

        public CollectionClass(string parameter)
        {
            _parameter = parameter;
        }
        public IEnumerator GetEnumerator()
        {
            return new CollectionEnumerator(_parameter);
        }
    }
}
