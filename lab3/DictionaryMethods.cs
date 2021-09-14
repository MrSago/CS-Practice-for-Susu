
using System;
using System.Collections.Generic;

namespace lab3
{
    class DictionaryMethods<KeyType>
    {
        private readonly Dictionary<KeyType, Action> _methods;

        public DictionaryMethods(Dictionary<KeyType, Action> methods)
        {
            _methods = methods;
        }

        public bool Invoke(KeyType key)
        {
            try
            {
                _methods[key]?.Invoke();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

