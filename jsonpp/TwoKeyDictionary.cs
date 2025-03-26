using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace jsonpp
{
    class ThreeValue<PK, SK, V>
    {
        public PK First { get; set; }
        public SK Second { get; set; }
        public V Value { get; set; }
    }

    class TwoKeyDictionary<PK, SK, V> : IEnumerable<ThreeValue<PK, SK, V>>, IDisposable
    {
        Dictionary<PK, Dictionary<SK, V>> dic_pk;

        public Dictionary<PK, Dictionary<SK, V>> Dictionary
        {
            get { return dic_pk; }
            set { dic_pk = value; }
        }

        public TwoKeyDictionary()
        {
            dic_pk = new Dictionary<PK, Dictionary<SK, V>>();
        }

        public bool ContainsPrimaryKey(PK pk)
        {
            return dic_pk.ContainsKey(pk);
        }

        public bool ContainsKey(PK pk, SK sk)
        {
            V v;
            bool haskey = TryGetValue(pk, sk, out v);
            return haskey;
        }

        public bool TryGetValue(PK pk, out IEnumerable<V> v)
        {
            if (pk == null)
            {
                v = default;
                return false;
            }

            Dictionary<SK, V> sk_dic;
            bool has_pk = dic_pk.TryGetValue(pk, out sk_dic);
            if (!has_pk)
            {
                v = default;
                return false;
            }

            v = sk_dic.Values;
            return true;
        }

        public bool TryGetValue(PK pk, SK sk, out V v)
        {
            if (pk == null || sk == null)
            {
                v = default;
                return false;
            }

            Dictionary<SK, V> sk_dic;
            bool has_pk = dic_pk.TryGetValue(pk, out sk_dic);
            if (!has_pk)
            {
                v = default;
                return false;
            }

            return sk_dic.TryGetValue(sk, out v);
        }

        public V GetValue(PK pk, SK sk)
        {
            V v;
            bool haskey = TryGetValue(pk, sk, out v);
            if (!haskey)
            {
                string msg = string.Format("(pk,sk) missing");
                throw new KeyNotFoundException(msg);
            }

            return v;
        }

        public void SetValue(PK pk, SK sk, V v)
        {
            Dictionary<SK, V> sk_dic;
            bool has_pk = dic_pk.TryGetValue(pk, out sk_dic);
            if (!has_pk)
            {
                sk_dic = new Dictionary<SK, V>();
                dic_pk[pk] = sk_dic;
            }

            sk_dic[sk] = v;
        }

        public V this[PK pk, SK sk]
        {
            get
            {
                return GetValue(pk, sk);
            }

            set
            {
                SetValue(pk, sk, value);
            }
        }

        public int Count
        {
            get
            {
                int n = 0;
                foreach (var i in dic_pk.Values)
                {
                    n += i.Count;
                }

                return n;
            }
        }

        public void Clear()
        {
            dic_pk.Clear();
        }

        public void Add(PK pk, SK sk, V v)
        {
            this[pk, sk] = v;
        }

        public void Remove(PK pk)
        {
            dic_pk.Remove(pk);
        }

        public bool Remove(PK first, SK second)
        {
            if (dic_pk.ContainsKey(first))
            {
                return dic_pk[first].Remove(second);
            }

            return false;
        }

        public void Move(PK first, PK second)
        {
            var tmp = dic_pk[first];
            dic_pk.Remove(first);
            dic_pk[second] = tmp;
        }

        public IEnumerable<Tuple<PK, IEnumerable<V>>> GetEnumerator2()
        {
            foreach (var d in Dictionary)
                yield return new Tuple<PK, IEnumerable<V>>(d.Key, d.Value.Select(x => x.Value));
        }

        public IEnumerable<ThreeValue<PK, SK, V>> GetEnumerator3()
        {
            foreach (var d in Dictionary)
            {
                foreach (var v in d.Value)
                {
                    yield return new ThreeValue<PK, SK, V>()
                    {
                        First = d.Key,
                        Second = v.Key,
                        Value = v.Value
                    };
                }
            }
        }

        public IEnumerable<V> GetValues()
        {
            foreach (var d in Dictionary)
                foreach (var v in d.Value)
                    yield return v.Value;
        }

        public IEnumerator GetEnumerator()
        {
            return dic_pk.GetEnumerator();
        }

        public TwoKeyDictionary<PK, SK, V> Clone()
        {
            var item = new TwoKeyDictionary<PK, SK, V>();
            foreach (var t in dic_pk)
            {
                foreach (var t2 in t.Value)
                {
                    item[t.Key, t2.Key] = t2.Value;
                }
            }
            return item;
        }

        IEnumerator<ThreeValue<PK, SK, V>> IEnumerable<ThreeValue<PK, SK, V>>.GetEnumerator()
        {
            return GetEnumerator3().GetEnumerator();
        }

        public void Dispose()
        {
            foreach (var item in dic_pk)
            {
                item.Value.Clear();
                item.Value.TrimExcess();
            }

            dic_pk.Clear();
            dic_pk.TrimExcess();
            dic_pk = null;
        }
    }
}
