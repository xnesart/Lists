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
                _tail.Next = new Node(values[i]);
                _tail = _tail.Next;
            }
        }
        else
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
            _tail = _root;
        }
        else
        {
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }
    }
    public void AddFirst(int value)
    {
        Length++;
        Node tmp = new Node(value);
        tmp.Next = _root;
        _root = tmp;
        if (this.Length == 1)
        {
            _tail = _root;
        }
    }
    public void AddByIndex(int value, int index)
    {
        if (_root == null)
        {
            if (index == 0)
            {
                _root = new Node(value);
            }
            else
            {
                _root = new Node(0);
                Length++;
            }
        }
        if (index > this.Length)
        {
            for (int i = this.Length+1; i <= index; i++)
            {
                Add(0);
            }
            Node current = _root;
            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
            Length--;
        }
        if (index < 0)
        {
            throw new IndexOutOfRangeException("Вы ввели отрицательный индекс, ошибка");
        }
        if (index == 0 && Length > 0)
        {
            Node temp = _root;
            _root = new Node(value);
            _root.Next = temp;
        }
        else
        {
            Node current = _root;
            for (int i = 1; i < index; i++)
            {
                current = current.Next;
            }
            Node tmp = new Node(value);
            tmp.Next = current.Next;
            current.Next = tmp;
            _tail = current.Next;
        }

        if (_tail.Value != this[Length])
        {
            Node current = _root;
            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            _tail = current.Next;
        }
        Length++;
    }
    public void RemoveFirst()
    {
        if (_root.Next is null)
        {
            _root = new Node(0);
        }
        _root = _root.Next;
        Length--;
    }
    public void RemoveLast()
    {
        if (_root.Next is null)
        {
            _root = new Node(0);
        }
        Node current = _root;
        for (int i = 1; i < this.Length-1; i++)
        {
            current = current.Next;
        }
        current.Next = null;
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

    public void RemoveFewElementsFromStart(int value)
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
        Length = Length - value;
        for (int i = 1; i < this.Length; i++)
        {
            current = current.Next;
        }
        _tail=current;
        current.Next = null;
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
        _tail = _root;
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
                index = i+1;
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

        Console.WriteLine("длина списка = " +Length);
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
    public override bool Equals(object obj)
    {
        LinkedList list = (LinkedList)obj;
        if (list == null)
        {
            return false;
        }
        if (this.Length != list.Length)
        {
            return false;
        }
        if (this.Length == 0 && list.Length == 0)
        {
            return true;
        }
        if (this._tail.Value != list._tail.Value)
        {
            return false;
        }
        if (!(this._tail.Next is null) || !(list._tail.Next is null))
        {
            return false;
        }
        Node currentThis = this._root;
        Node currentList = list._root;
        do
        {
            if (currentThis.Value != currentList.Value)
            {
                return false;
            }
            currentList = currentList.Next;
            currentThis = currentThis.Next;
        }
        while (!(currentThis is null));
            
        return true;
    }
    // public override bool Equals(object? obj)
    // {
    //     LinkedList list = (LinkedList)obj;
    //     if (this.Length!=list.Length)
    //     {
    //         return false;
    //     }
    //
    //     Node currentThis = _root;
    //     Node currentList = list._root;
    //
    //     while (!(currentThis.Next is null))
    //     {
    //         if (currentThis.Value != currentList.Value)
    //         {
    //             return false;
    //         }
    //
    //         currentList = currentList.Next;
    //         currentThis = currentThis.Next;
    //     }
    //
    //     if (currentList.Value != currentThis.Value)
    //     {
    //         return false;
    //     }
    //
    //     return true;
    // }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}