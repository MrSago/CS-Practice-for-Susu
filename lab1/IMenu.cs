﻿
namespace lab1
{
    interface IMenu<T>
    {
        DictionaryMethods<T> Method { get; }
        bool ContinueMenu { get; }
    }
}

