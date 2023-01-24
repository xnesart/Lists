namespace Lists.Classes;

public class ArrayList
{
    public int Length { get; private set; }

    public int[] _array;

    public ArrayList()
    {
        Length = 0;
        _array = new int[10];
    }

    public void Add(int element)
    {
        if (Length == _array.Length)
        {
            UpSize();
        }
        _array[Length] = element;
        Length++;
    }
    public void AddToStart(int element)
    {
        if (Length == _array.Length)
        {
            UpSize();
        }
        int[] tmpArr = new int[_array.Length];
        tmpArr[0] = element;
        for (int i = 1; i < _array.Length; i++)
        {
            tmpArr[i] = _array[i-1];
            _array[i-1] = tmpArr[i-1];
        }
        Length++;
    }
    /// <summary>
    /// Добавляет значение по индексу
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void AddToIndex(int index, int value)
    {
        if (Length == _array.Length)
        {
            UpSize();
        }
        if (_array[index] >= _array.Length)
        {
            UpSize();
        }
        int[] tmpArr = new int[_array.Length];
        for (int i = 0; i <= _array[index]; i++)
        {
            tmpArr[i] = _array[i];
        }
        tmpArr[index] = value;
        for (int i = index + 1; i < _array.Length; i++)
        {
            tmpArr[i] = _array[i];
        }
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = tmpArr[i];
        }
        Length++;
    }
    /// <summary>
    /// Удаляет первый элемент массива
    /// </summary>
    public void RemoveFirstElement()
    {
        if (Length == _array.Length)
        {
            UpSize();
        }
        int[] tmpArr = new int[_array.Length];
        for (int i = 0; i < _array.Length-1; i++)
        {
            tmpArr[i] = _array[i+1];
        }

        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = tmpArr[i];
        }
    }
    /// <summary>
    /// Удаляет последний элемент массива
    /// </summary>
    public void RemoveLastElement()
    {
        // if (Length == _array.Length)
        // {
        //     UpSize();
        // }
        int[] tmpArr = new int[_array.Length-1];
        for (int i = 0; i < tmpArr.Length; i++)
        {
            tmpArr[i] = _array[i];
            _array[i] = tmpArr[i];
        } 
    }
    public void PrintArr()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            Console.WriteLine($"индекс{i}" + "=" +  _array[i]);
        }
    }

    private void UpSize()
    {
        int NewLength = (int)(_array.Length * 1.33d + 1);

        int[] tempArray = new int[NewLength];
        for (int i = 0; i < _array.Length; i++)
        {
            tempArray[i] = _array[i];
        }

        _array = tempArray;
    }
    

}

