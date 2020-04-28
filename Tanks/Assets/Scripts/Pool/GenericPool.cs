using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Pool
{
    public abstract class GenericPool<T> where T : Component
    {
        private Queue<T> objects;

        public void InitiatePool()
        {
            objects = new Queue<T>();
        }

        public bool IsPoolEmpty()
        {
           return objects.Count == 0 ? true: false;
        }

        public T GetInctance()
        {
            return objects.Dequeue();
        }

        public void SetInstance(T instance)
        {
            if (!objects.Contains(instance))
            {
                objects.Enqueue(instance);
            }
        }
    }
}