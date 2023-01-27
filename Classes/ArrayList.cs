using System.Security.Cryptography.X509Certificates;

namespace Lists.Classes;

public class ArrayList
{
    public int Length { get; private set; }

    public int[] _array;

    public ArrayList()
    {
        Length = 10;
        _array = new int[]{1,2,3,1,2,6,1,80,9,10};
    }
    /// <summary>
    /// добавляет элемент в конец массива
    /// </summary>
    /// <param name="element"></param>
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
    /// <summary>
    /// Смещает массив вправо на X элементов
    /// </summary>
    /// <param name="moveOn"></param>
    public void MoveOnXOnRigth(int moveOn)
    {
        // int a = moveTo;
        int[] tmpArr = new int[_array.Length+moveOn];
        for (int i = 0; i < _array.Length; i++)
        {
            tmpArr[moveOn] = _array[i];
            moveOn++;
        }

        Length = Length + moveOn;
        _array = tmpArr;
    }
    /// <summary>
    /// смещает массив влево на X элементов
    /// </summary>
    /// <param name="moveOn"></param>
    public void MoveOnXOnLeft(int moveOn)
    {
        int[] tmpArr = new int[_array.Length-moveOn];
        for (int i = 0; i < tmpArr.Length; i++)
        {
            tmpArr[i] = _array[moveOn];
            moveOn++;
        }

        Length = Length - moveOn;
        _array = tmpArr;
    }
    /// <summary>
    /// добавляет элемент в начало массива, со сдвигом
    /// </summary>
    /// <param name="element"></param>
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
        _array = tmpArr;
        Length++;
    }
    /// <summary>
    /// Добавляет значение по индексу
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void AddToIndex(int index, int value)
    {
        int tmpLength = Length;
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
        if (index <= tmpLength)
        {
            Length = Length;
        }
        else
        {
            Length = index;
        }
    }
    /// <summary>
    /// Удаляет первый элемент массива
    /// </summary>
    public void RemoveFirstElement()
    {
        MoveOnXOnLeft(1);
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
    /// <summary>
    ///     Удаляет элемент с указанным индексом
    /// </summary>
    /// <param name="index"></param>
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
    /// <summary>
    /// удаляет несколько последних элементов массива
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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
    /// <summary>
    /// удаляет первые несколько элементов массива
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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
        MoveOnXOnLeft(value);
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
    /// <summary>
    /// удаляет несколько элементов начиная с индекса
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void RemoveFewElementsByIndex(int index,int value)
    {
        if (value > _array.Length || index+value > _array.Length)
        {
            throw new ArgumentOutOfRangeException("Вы пытаетесь удалить больше элементов, чем есть в массиве. Ошибка");
        }
        int tmp = index + value;
        int[] tmpArr = new int[_array.Length - value];
        for (int i = 0; i < index; i++)
        {
            tmpArr[i] = _array[i];
        }
        int a = index;
        for (int i = tmp; i < _array.Length; i++)
        {
            tmpArr[a] = _array[i];
            a++;
        }
        _array = tmpArr;
        Length = Length - value;
    }
    /// <summary>
    /// возвращает длину массива
    /// </summary>
    /// <returns>Length</returns>
    public int ReturnLengthOfArray()
    {
        return Length;
    }
    /// <summary>
    /// выводит значение введенного индекса
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public int GetByIndex(int index)
    {
        int value = _array[index];
        if (value > Length)
        {
            throw new IndexOutOfRangeException("Вы ввели индекс, превышающий длину массива, ошибка");
        }
        return value;
    }
    /// <summary>
    /// меняет значение числа введенного индекса
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public int ChangeByIndex(int index, int value)
    {
        _array[index] = value;
        if (index > Length || index < 0)
        {
            throw new IndexOutOfRangeException("Вы ввели индекс, превышающий длину массива или меньше 0, ошибка");
        }
        return _array[index];
    }
    /// <summary>
    /// находит первый индекс введенного числа
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int GetFirstIndexFromValue(int value)
    {
        int desuredIndex = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (_array[i] == value)
            {
                desuredIndex = i;
                break;
            }

            if (_array[i] != value)
            {
                desuredIndex = -1;
            }
        }
        return desuredIndex;
    }
    /// <summary>
    /// переворачивает массив
    /// </summary>
    public void ArrayReverse()
    {
        int[] tmpArr = new int[Length+1];
        int a = 0;
        for (int i = Length; i >=0; i--)
        {
            tmpArr[a] = _array[i];
            a++;
        }
        _array = tmpArr;
    }
    /// <summary>
    /// находит максимальное значение в массиве и возвращает его
    /// </summary>
    /// <returns></returns>
    public int FindMaxValueOfArray()
    {
        int max = _array[0];
        for (int i = 0; i < Length; i++)
        {
            if (_array[i] > max)
            {
                max = _array[i];
            }
        }

        return max;
    }
    /// <summary>
    /// находит минимальное значение в массиве и возвращает его
    /// </summary>
    /// <returns></returns>
    public int FindMinValueOfArray()
    {
        int min = _array[0];
        for (int i = 0; i < Length; i++)
        {
            if (_array[i] < min)
            {
                min = _array[i];
            }
        }

        return min;
    }
    /// <summary>
    /// находит индекс максимального числа в массиве и возвращает его
    /// </summary>
    /// <returns></returns>
    public int FindIndexofMaxValueOfArray()
    {
        int max = _array[0];
        int index = 0;
        for (int i = 0; i < Length; i++)
        {
            if (_array[i] > max)
            {
                max = _array[i];
                index = i;
            }
        }

        return index;
    }
    /// <summary>
    /// находит индекс минимального числа в массиве и возвращает его
    /// </summary>
    /// <returns></returns>
    public int FindIndexofMinValueOfArray()
    {
        int min = _array[0];
        int index = 0;
        for (int i = 0; i < Length; i++)
        {
            if (_array[i] < min)
            {
                min = _array[i];
                index = i;
            }
        }

        return index;
    }
    /// <summary>
    /// сортирует массив по убыванию
    /// </summary>
    public void SortToMin()
    {
        int tmp;
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = 0; j < _array.Length; j++)
            {
                if (_array[i] > _array[j])
                {
                    tmp = _array[j];
                    _array[j] = _array[i];
                    _array[i] = tmp;
                }
            }
        }
    }
    /// <summary>
    /// сортирует массив по возрастанию
    /// </summary>
    public void SortToMax()
    {
        int tmp;
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = 0; j < _array.Length; j++)
            {
                if (_array[i] < _array[j])
                {
                    tmp = _array[j];
                    _array[j] = _array[i];
                    _array[i] = tmp;
                }
            }
        }
    }
    /// <summary>
    /// удаляет первое введенное значение и возвращает его индекс
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int DeleteByValue(int value)
    {
        int index = -1;
        int[] tmpArr = new int[Length];
        int[] tmpArr2 = new int[Length - 1];
        for (int i = 0; i < Length; i++)
        {
            if (_array[i] == value)
            {
                index = i;
            }
        }
        if (index == -1)
        {
            return index;
        }
        for (int i = 0; i < index; i++)
        {
            tmpArr[i] = _array[i];
        }
        for (int i = index+1; i < Length; i++)
        {
            tmpArr[i-1] = _array[i];
        }
        for (int i = 0; i < Length-1; i++)
        {
            tmpArr2[i] = tmpArr[i];
        }
        _array = tmpArr2;
        Length--;
        return index;
    }
    /// <summary>
    /// удаляет введенное значение во всем массиве, возвращает их количество
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int DeleteByValues(int value)
    {
        int count = 0;
        for (int i = 0; i < Length; i++)
        {
            if (_array[i] == value)
            {   RemoveAtIndex(i);
                count++;
                Length++;
            }
        }
        return count;
    }
    /// <summary>
    /// выводит массив в консоль
    /// </summary>
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
    /// <summary>
    /// увеличивает размер массива на оптимальное значение
    /// </summary>
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

