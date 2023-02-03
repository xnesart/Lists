using System.Windows.Markup;

namespace Lists.Classes;

public class Node
{
    public int Value { get; set; }
    //В классе Node одним из его свойств является Node. Она не ссылается сама на себя, класс это тип данных, а не конкретный объект
    public Node Next { get; set; }
    //Node не может быть пустой, поэтому при создании ей надо задавать Value
    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}