using System.Windows.Markup;

namespace Lists.Classes;

public class LinkedList
{
    public int Length { get; private set; }

    public int this[int index]
    {
        get
        {
            Node current = _root;
            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }
        set
        {
            Node current = _root;
            for (int i = 1; i <=index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }
    }
    private Node _root;
    private Node _tail;

    public LinkedList()
    {
        Length = 0;
        _root = null;
        _tail = null;
    }
    //здесь нода из 1го элемента, поэтому tail = root; В итоге и tail и root будут ссылаться на одну и ту же ноду.
    public LinkedList(int value)
    {
        Length = 1;
        _root = new Node(value);
        _tail = _root;
    }

    public LinkedList(int[] values)
    {
        Length = values.Length;
        if (values.Length != 0)
        {
            _root = new Node(values[0]);
            _tail = _root;
            for (int i = 1; i < values.Length; i++)
            {
                //в поле, где у хвоста есть следующий элемент, кладем новую ноду.
                _tail.Next = new Node(values[i]);
                _tail = _tail.Next;
            }
        }
        else //если длина массива равна 0, создаем пустой список
        {
            _root = null;
            _tail = null;
        }
    }
   

    public void Add(int value)
    {
        //увеличиваем длину на 1
        Length++;
        if (_root == null)
        {
            _root = new Node(value);
        }
        //обращаемся к концу, к полю нэкст, и создаем новую ноду со значением value
        _tail.Next = new Node(value);
        //пишем, что конец теперь - это последний элемент(переходим с бывшего конечного к следующему)
        _tail = _tail.Next;
    }
    public void AddFirst(int value)
    {
        Length++;
        Node tmp = new Node(value);
        tmp.Next = _root;
        _root = tmp;
    }
    public void AddByIndex(int value, int index)
    {
        if (index > this.Length)
        {
            for (int i = this.Length; i < index; i++)
            {
                Add(0);
            }
        }

        if (index < 0)
        {
            throw new IndexOutOfRangeException("Вы ввели отрицательный индекс, ошибка");
        }
        Node current = _root;
        for (int i = 1; i < index; i++)
        {
            current = current.Next;
        }
        Node tmp = new Node(value);
        tmp.Next = current.Next;
        current.Next = tmp;
        Length++;
    }
    public void RemoveFirst()
    {
        _root = _root.Next;
        Length--;
    }
    public void RemoveLast()
    {
        Node current = _root;
        for (int i = 1; i < this.Length; i++)
        {
            current = current.Next;
        }

        _tail = current;
        Length--;
    }
    public void RemoveByIndex(int index)
    {
        Node current = _root;

        for (int i = 1; i < index; i++)
        {
            current = current.Next;
        }

        current.Next = current.Next.Next;

        Length--;
    }

    public void RemoveFewElementFromStart(int value)
    {
        Node current = _root;
        for (int i = 1; i < value; i++)
        {
            current = current.Next;
        }

        _root = current.Next;
        Length = Length - value;

    }
    public void RemoveFewElementsFromEnd(int value)
    {
        Node current = _root;
        int end = Length - value;
        for (int i = 1; i < end; i++)
        {
            current = current.Next;
        }

        _tail=current;
        Length = Length - value;
    }

    public void RemoveFewElementsByIndex(int index, int value)
    {
        Node current = _root;
        for (int i = 1; i < index; i++)
        {
            current = current.Next;
        }
        Node tmp = current.Next;
        for (int i = index; i < index+value-1; i++)
        {
            tmp = tmp.Next;
        }

        current.Next = tmp.Next;
        Length = Length - value;
    }

    public int ReturnFirstIndexByValue(int value)
    {
        int tmp = -1;
        if (_root.Value == value)
        {
            tmp = 0;
        } else if (_tail.Value == value)
        {
            tmp = this.Length;
        }
        Node current = _root;
        for (int i = 1; i < Length; i++)
        {
            current = current.Next;
            if (current.Value == value)
            {
                tmp = i;
            }
        }

        return tmp;
    }

    public void ListReverse()
    {
        Node start = _root, n = null;
        while (start != null) {
            Node tmp = start.Next;
            start.Next = n;
            n = start;
            start = tmp;
        }
        _root = n;
        
        // Node tmp = _root;
        // Node current = _tail;
        // for (int i = 1; i < this.Length; i++)
        // {
        //     tmp = tmp.Next;
        //     for (int j = this.Length - 1; j > 0; j--)
        //     {
        //         current.Next = tmp;
        //     }
        // }
        
        
    }

    public int FindMaxValue()
    {
        Node current = _root;
        int tmp = _root.Value;
        for (int i = 1; i < this.Length ;i++)
        {
            current = current.Next;
            if (current.Value > tmp)
            {
                tmp = current.Value;
            }
        }

        return tmp;
    }
    public int FindMinValue()
    {
        Node current = _root;
        int tmp = _root.Value;
        for (int i = 1; i < this.Length ;i++)
        {
            current = current.Next;
            if (current.Value < tmp)
            {
                tmp = current.Value;
            }
        }
        return tmp;
    }
    public int FindIndexOfMaxValue()
    {
        Node current = _root;
        int tmp = _root.Value;
        int index = 0;
        for (int i = 1; i < this.Length ;i++)
        {
            current = current.Next;
            if (current.Value > tmp)
            {
                tmp = current.Value;
                index = i;
            }
        }

        return index;
    }
    public int FindIndexOfMinValue()
    {
        Node current = _root;
        int tmp = _root.Value;
        int index = 0;
        for (int i = 1; i < this.Length ;i++)
        {
            current = current.Next;
            if (current.Value < tmp)
            {
                tmp = current.Value;
                index = i;
            }
        }

        return index;
    }

    public void SortToMin()
    {
        Node current = _root;
        int[] arr = new int[this.Length];
        int tmp;
        for (int i = 1; i < this.Length; i++)
        {
            tmp = current.Value;
            arr[i-1] = tmp;
            current = current.Next;
        }
        arr[Length-1] = _tail.Value;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    tmp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = tmp;
                }
            }
        }

        current = _root;
        for (int i = 1; i < this.Length; i++)
        {
            current.Value = arr[i-1];
            current = current.Next;
        }

        _tail.Value = arr[Length-1];
    }
    
    public void SortToMax()
    {
        Node current = _root;
        int[] arr = new int[this.Length];
        int tmp;
        for (int i = 1; i < this.Length; i++)
        {
            tmp = current.Value;
            arr[i-1] = tmp;
            current = current.Next;
        }
        arr[Length-1] = _tail.Value;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[i] < arr[j])
                {
                    tmp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = tmp;
                }
            }
        }

        current = _root;
        for (int i = 1; i < this.Length; i++)
        {
            current.Value = arr[i-1];
            current = current.Next;
        }

        _tail.Value = arr[Length-1];
    }

    public int DeleteByValueReturnIndex(int value)
    {
        Node current = _root;
        int index = -1;
        Node tmp;
        if (_root.Value == value)
        {
            _root = _root.Next;
            Length--;
            return index = 0;
        }
        
        for (int i = 0; i < Length; i++)
        {
            tmp = current;
            current = current.Next;
            if (current == null)
            {
                break;
            }
            if (current.Value == value)
            {
                index = i;
                tmp.Next = tmp.Next.Next;
                Length--;
                break;
            }
        }
        
        return index;
    }
    public int DeleteByValuesReturnCount(int value)
    {
        int oldLength = Length;
        int i = 0;
        while (i < oldLength)
        {
            i++;
            DeleteByValueReturnIndex(value);
        }

        int newLength = Length;
        int count = oldLength - newLength;
        return count;
    }

    public void PrintList()
    {
        
        for (int i = 0; i < this.Length; i++)
        {
            Console.WriteLine(this[i]);
        }
    }
    private int GetNodeByIndex(int index)
    {
        Node current = _root;
        for (int i = 1; i <= index; i++)
        {
            current = current.Next;
        }

        return current.Value;
    }
    public override string ToString()
    {
        if (Length != 0)
        {
            Node current = _root;
            string s = current.Value + " ";

            while (!(current.Next is null))
            {
                current = current.Next;
                s += current.Value + " ";
            }
            return s;
        }
        else
        {
            return String.Empty;
        }

    }

    public override bool Equals(object? obj)
    {
        LinkedList list = (LinkedList)obj;
        if (this.Length!=list.Length)
        {
            return false;
        }

        Node currentThis = _root;
        Node currentList = list._root;

        do
        {
            if (currentThis.Value != currentList.Value)
            {
                return false;
            }
            //это тот лист который нам передали
            currentList = currentList.Next;
            //это наш лист
            currentThis = currentThis.Next;
        }
        while (!(currentThis.Next is null));

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}