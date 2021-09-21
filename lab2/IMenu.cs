
namespace lab2
{
    interface IMenu<T>
    {
        DictionaryMethods<T> Method { get; }
        bool ContinueMenu { get; }
    }
}

