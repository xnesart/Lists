using Lists.Classes;
namespace Lists.Tests;

public class ArrayListTests
{
    [TestCase(new int[] {1,2,3,1,2,6,1,80,9,10,3,0,0,0} ,3)]
    [TestCase(new int[] {1,2,3,1,2,6,1,80,9,10,4,0,0,0} ,4)]
    [TestCase(new int[] {1,2,3,1,2,6,1,80,9,10,77,0,0,0} ,77)]
    // [TestCase(3,new int[] {0,0,0,0})]
    public void ArrayListAddTests(int[] expected, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.Add(value);
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {0,1,2,3,1,2,6,1,80,9,10} ,1)]
    [TestCase(new int[] {0,0,0,0,1,2,3,1,2,6,1,80,9,10} ,4)]
    [TestCase(new int[] {0,0,1,2,3,1,2,6,1,80,9,10} ,2)]
    // [TestCase(3,new int[] {0,0,0,0})]
    public void MoveOnXOnRigthTests(int[] expected, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.MoveOnXOnRigth(value);
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {2,3,1,2,6,1,80,9,10} ,1)]
    [TestCase(new int[] {2,6,1,80,9,10} ,4)]
    [TestCase(new int[] {3,1,2,6,1,80,9,10} ,2)]
    // [TestCase(3,new int[] {0,0,0,0})]
    public void MoveOnXOnLeftTests(int[] expected, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.MoveOnXOnLeft(value);
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {1,1,2,3,1,2,6,1,80,9,10,0, 0, 0} ,1)]
    [TestCase(new int[] {4,1,2,3,1,2,6,1,80,9,10,0, 0, 0} ,4)]
    [TestCase(new int[] {2,1,2,3,1,2,6,1,80,9,10,0, 0, 0} ,2)]
    // [TestCase(3,new int[] {0,0,0,0})]
    public void AddToStartTests(int[] expected, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.AddToStart(value);
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {1,4,2,3,1,2,6,1,80,9,10,0,0,0,0} ,1,4)]
    [TestCase(new int[] {1,2,3,1,66,2,6,1,80,9,10,0,0,0,0} ,4,66)]
    [TestCase(new int[] {1,2,23,3,1,2,6,1,80,9,10,0, 0,0,0} ,2,23)]
    // [TestCase(3,new int[] {0,0,0,0})]
    public void AddToIndexTests(int[] expected, int index, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.AddToIndex(index,value);
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {2,3,1,2,6,1,80,9,10})]
    // [TestCase(3,new int[] {0,0,0,0})]
    public void RemoveFirstElementTest(int[] expected)
    {
        ArrayList arrays = new ArrayList();
        arrays.RemoveFirstElement();
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {1,2,3,1,2,6,1,80,9})]
    public void RemoveLastElementTest(int[] expected)
    {
        ArrayList arrays = new ArrayList();
        arrays.RemoveLastElement();
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {1,3,1,2,6,1,80,9,10} ,1)]
    [TestCase(new int[] {1,2,3,1,6,1,80,9,10} ,4)]
    [TestCase(new int[] {1,2,3,1,2,6,1,9,10} ,7)]

    // [TestCase(3,new int[] {0,0,0,0})]
    public void RemoveAtIndexTests(int[] expected, int index)
    {
        ArrayList arrays = new ArrayList();
        arrays.RemoveAtIndex(index);
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {1,2,3,1,2,6,1,80} ,2)]
    [TestCase(new int[] {1,2,3,1,2,6} ,4)]
    [TestCase(new int[] {1,2} ,8)]
    [TestCase(new int[] {1} ,9)]
    public void RemoveLastFewElementsTests(int[] expected, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.RemoveLastFewElements(value);
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {3,1,2,6,1,80,9,10} ,2)]
    [TestCase(new int[] {6,1,80,9,10} ,5)]
    [TestCase(new int[] {2,6,1,80,9,10} ,4)]

    public void RemoveFirstFewElementsTests(int[] expected, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.RemoveFirstFewElements(value);
        int[] actual = arrays._array;

        Assert.AreEqual(expected, actual);
    }
    [TestCase(new int[] {1,2,1,80,9,10} ,2,4)]
    [TestCase(new int[] {1,2,3,1,2,9,10} ,5,3)]
    [TestCase(new int[] {1,2} ,2,8)]
    
    public void RemoveFewElementsByIndexTests(int[] expected,int index, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.RemoveFewElementsByIndex(index,value);
        int[] actual = arrays._array;
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(1,2)]
    [TestCase(7 ,80)]
    [TestCase(9 ,10)]
    
    public void GetFirstIndexFromValueTests(int expected, int value)
    {
        ArrayList arrays = new ArrayList();
        // arrays.GetFirstIndexFromValue(value);
        int actual = arrays.GetFirstIndexFromValue(value);
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(new int[] {10,9,80,1,6,2,1,3,2,1})]
    public void ArrayReverseTests(int[] expected)
    {
        ArrayList arrays = new ArrayList();
        arrays.ArrayReverse();
        int[] actual = arrays._array;
    
        Assert.AreEqual(expected, actual);
    }
    
    
    [TestCase(80)]
    public void FindMaxValueOfArrayTests(int expected)
    {
        ArrayList arrays = new ArrayList();
        int actual = arrays.FindMaxValueOfArray();
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(1)]
    public void FindMinValueOfArrayTests(int expected)
    {
        ArrayList arrays = new ArrayList();
        int actual = arrays.FindMinValueOfArray();
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(7)]
    public void FindIndexofMaxValueOfArrayTests(int expected)
    {
        ArrayList arrays = new ArrayList();
        int actual = arrays.FindIndexofMaxValueOfArray();
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(0)]
    public void FindIndexofMinValueOfArrayTests(int expected)
    {
        ArrayList arrays = new ArrayList();
        int actual = arrays.FindIndexofMinValueOfArray();
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(new int[] {80,10,9,6,3,2,2,1,1,1})]
    public void SortToMinTests(int[] expected)
    {
        ArrayList arrays = new ArrayList();
        arrays.SortToMin();
        int[] actual = arrays._array;
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(new int[] {1,1,1,2,2,3,6,9,10,80})]
    public void SortToMaxTests(int[] expected)
    {
        ArrayList arrays = new ArrayList();
        arrays.SortToMax();
        int[] actual = arrays._array;
    
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(new int[] {1,2,1,2,6,1,80,9,10} ,3)]
    [TestCase(new int[] {1,3,1,2,6,1,80,9,10} ,2)]
    [TestCase(new int[] {1,2,3,1,2,6,1,80,9,10} ,0)]
    public void DeleteByValueTests(int[] expected, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.DeleteByValue(value);
        int[] actual = arrays._array;
    
        Assert.AreEqual(expected, actual);
    }

    [TestCase(new int[] {1,2,1,2,6,1,80,9,10} ,3)]
    [TestCase(new int[] {1,3,1,6,1,80,9,10} ,2)]
    [TestCase(new int[] {2,3,2,6,80,9,10} ,1)]
    public void DeleteByValuesTests(int[] expected, int value)
    {
        ArrayList arrays = new ArrayList();
        arrays.DeleteByValues(value);
        int[] actual = arrays._array;
    
        Assert.AreEqual(expected, actual);
    }
}