using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class CustomPool<T> where T : MonoBehaviour
    {
        private List<T> _prefabs;
        private List<T> _objects;
        private Transform _parentContainer;

        public CustomPool(List<T> prefabs, int prewarmObjects, Transform parentContainer)
        {
            _prefabs = prefabs;
            _objects = new List<T>();
            _parentContainer = parentContainer;
            if (_prefabs.Count == 0)
            {
                throw new Exception("Prefabs list is empty");
            }

            for (int i = 0; i < prewarmObjects; i++)
            {
                var obj = GameObject.Instantiate(_prefabs[Random.Range(0, _prefabs.Count)], parentContainer);
                obj.gameObject.SetActive(false);
                _objects.Add(obj);
            }
        }

        public T Get()
        {
            var allAvailableObj = _objects.FindAll(x => !x.isActiveAndEnabled);
            if (allAvailableObj.Count == 0)
            {
                var newObj = Create();
                newObj.gameObject.SetActive(true);
                return newObj;
            }

            var obj = allAvailableObj[Random.Range(0, allAvailableObj.Count)];
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        private T Create()
        {
            var obj = GameObject.Instantiate(_prefabs[Random.Range(0, _prefabs.Count)], _parentContainer);
            _objects.Add(obj);
            return obj;
        }
    }
}