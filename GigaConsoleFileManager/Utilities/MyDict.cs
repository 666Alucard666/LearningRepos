using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class MyDict<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private KeyValuePair<TKey, TValue>[] values;
        public int Count => values.Length;
        public MyDict()
        {
            values = Array.Empty<KeyValuePair<TKey, TValue>>();
        }
        public void Add(TKey newKey, TValue newValue)
        {
            if (newKey is null)
            { 
                throw new ArgumentNullException("Key can not be null");
            }
            if (Contains(newKey)) { throw new ArgumentException($"Key {newKey} already exists"); }
            values = values.Append(new KeyValuePair<TKey, TValue>(newKey, newValue)).ToArray();
        }
        public TValue Get(TKey newKey)
        {
            if (!Contains(newKey))
            {
                throw new KeyNotFoundException($"Key {newKey} does not exist.");
            }

            return values.Where(x => x.Key.Equals(newKey)).ToArray()[0].Value;

        }
        public bool Contains(TKey newKey)
        {
            return values.Where(x => x.Key.Equals(newKey)).Any();
        }
        public void Remove(TKey newKey)
        {
            if (!Contains(newKey))
            {
                throw new KeyNotFoundException($"Key {newKey} does not exist");
            }
            values = values.Where(x => !x.Key.Equals(newKey)).ToArray();
        }
        public TValue this[TKey key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Add(key, value);
            }
        }



        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return values.AsEnumerable().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override string ToString()
        {
            return string.Join(", ", values.Select(x => $"{x.Key}: {x.Value}"));
        }
    }
}