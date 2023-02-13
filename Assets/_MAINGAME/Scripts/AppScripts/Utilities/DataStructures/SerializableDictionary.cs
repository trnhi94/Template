using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace APP.AppScripts.Utilities.DataStructures
{
    [System.Serializable]
    public struct PairData<K, V>
    {
        [field: SerializeField] public K Key { get; set; }
        [field: SerializeField] public V Value { get; set; }

        public PairData(K k, V v)
        {
            this.Key = k;
            this.Value = v;
        }
    }

    [System.Serializable]
    public class SerializableDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        [SerializeField] protected PairData<K, V>[] data;
        public IDictionary<K, V> Dict { get; private set; }
        public void Init()
        {
            Dict = new Dictionary<K, V>();
            foreach (var d in data)
                Dict.Add(d.Key, d.Value);
        }

        public V this[K key]
        {
            get => Dict[key];
            set => Dict[key] = value;
        }
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator() => Dict.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    [System.Serializable]
    public class NoKeySerializableDictionary<K, V> : IEnumerable<KeyValuePair<K, V>> where V : IIdentityElement<K>
    {
        [field: SerializeField] public V[] Data { get; set; }
        public IDictionary<K, V> Dict { get; private set; }
        public void Init()
        {
            Dict = new Dictionary<K, V>();
            foreach (var d in Data)
                Dict.Add(d.Id, d);
        }
        public ICollection<V> Values => Dict.Values;
        public ICollection<K> Keys => Dict.Keys;
        public bool TryGetValue(K k, out V v) => Dict.TryGetValue(k, out v);
        public V this[K key]
        {
            get => Dict[key];
            set => Dict[key] = value;
        }
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator() => Dict.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public interface IIdentityElement<out TK>
    {
        public TK Id { get; }
    }
}
