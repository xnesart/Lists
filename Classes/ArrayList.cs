namespace Lists.Classes;

public class ArrayList
{
    public int Length { get; private set; }

    public int[] _array;

    public ArrayList()
    {
        Length = 10;
        _array = new int[]{1,2,3,4,5,6,7,8,9,10};
    }

    public void Add(int element)
    {
        if (Length == _array.Length)
        {
            UpSize();
        }
        if (_array.Length <= Length)
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
        if (index >= _array.Length)
        {
            while (_array.Length <= index)
            {
                UpSize();
            }
        }
        int[] tmpArr = new int[_array.Length+1];
        for (int i = 0; i < _array[index]; i++)
        {
            tmpArr[i] = _array[i];
        }
        tmpArr[index] = value;
        for (int i = index; i < _array.Length; i++)
        {
            tmpArr[i+1] = _array[i];
        }
        _array = tmpArr;
        RemoveLastElement();
        Length = _array.Length;
        Length++;
    }
    /// <summary>
    /// Удаляет первый элемент массива
    /// </summary>
    public void RemoveFirstElement()
    {
        int[] tmpArr = new int[_array.Length];
        for (int i = 0; i < _array.Length-1; i++)
        {
            tmpArr[i] = _array[i+1];
        }
        _array = tmpArr;
        Length--;
    }
    /// <summary>
    /// Удаляет последний элемент массива
    /// </summary>
    public void RemoveLastElement()
    {
        int[] tmpArr = new int[_array.Length-1];
        for (int i = 0; i < tmpArr.Length; i++)
        {
            tmpArr[i] = _array[i];
        }
        _array = tmpArr;
        Length--;
    }

    public void RemoveAtIndex(int index)
    {
        int[] tmpArr = new int[_array.Length];
        for (int i = 0; i < index; i++)
        {
            tmpArr[i] = _array[i];
        }

        for (int i = index+1; i < _array.Length; i++)
        {
            tmpArr[i-1] = _array[i];
        }

        _array = tmpArr;
        RemoveLastElement();
        Length--;
    }

    public void RemoveLastFewElements(int value)
    {
        if (value > _array.Length)
        {
            throw new ArgumentOutOfRangeException("Вы пытаетесь удалить больше элементов, чем есть в массиве. Ошибка");
        }
        int tmp = _array.Length - value;
        int[] tmpArr = new int[tmp];
        for (int i = 0; i < tmp; i++)
        {
            tmpArr[i] = _array[i];
        }

        _array = tmpArr;
        Length = Length - value;

    }
    public void RemoveFirstFewElements(int value)
    {
        if (value > _array.Length)
        {
            throw new ArgumentOutOfRangeException("Вы пытаетесь удалить больше элементов, чем есть в массиве. Ошибка");
        }
        int tmp = _array.Length - value;
        int a = 0;
        int[] tmpArr = new int[_array.Length];
        int[] tmpArr2 = new int[tmp];
        for (int i = _array.Length-1; i >= 0; i--)
        {
            tmpArr[a] = _array[i];
            a++;
        }

        a = 0;
        for (int i = tmp-1; i >=0; i--)
        {
            _array[i] = tmpArr[a];
            a++;
        }

        for (int i = tmp; i < _array.Length; i++)
        {
            _array[i] = 0;
        }

        for (int i = 0; i < tmp; i++)
        {
            tmpArr2[i] = _array[i];
        }

        tmpArr = tmpArr2;
        _array = tmpArr;
        
        Length = tmp;

    }
    public void PrintArr()
    {
        if (_array.Length == 0)
        {
            Console.Write("массив пустой");
        }
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

