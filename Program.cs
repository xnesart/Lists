﻿using Lists.Classes;

// ArrayList arrs = new ArrayList(new int[] {1,3,5,6,8});
ArrayList arrs = new ArrayList();
// arrs.PrintArr();
// arrs.Add(3);
// arrs.Add(4);
// arrs.AddToIndex(6,66);
// arrs.AddToIndex(12,50);
// arrs.AddToIndex(17,50);
// arrs.AddToIndex(22,50);
// arrs.AddToIndex(18,50);

// arrs.AddToStart(10);
// arrs.Add(12);
// arrs.Add(14);
// arrs.MoveOnXOnRigth(3);
// arrs.MoveOnXOnLeft(3);
// arrs.AddToIndex(2,61);
// arrs.AddToIndex(3,70);
// arrs.AddToIndex(4,80);
// arrs.AddToIndex(5,40);
// arrs.AddToIndex(20,39);
// arrs.AddToIndex(7,59);
// arrs.AddToIndex(8,29);
// arrs.AddToIndex(9,19);
// arrs.RemoveFirstElement();
// arrs.RemoveLastElement();
// arrs.RemoveAtIndex(6);
// arrs.RemoveAtIndex(0);
// arrs.RemoveAtIndex(3);
// arrs.RemoveAtIndex(3);
// arrs.RemoveLastFewElements(1);
// arrs.RemoveFirstFewElements(1);
// arrs.ChangeByIndex(5, 66);
// int desired = arrs.GetFirstIndexFromValue(2);
// Console.WriteLine(desired);
// arrs.ArrayReverse();
// int max = arrs.FindMaxValueOfArray();
// Console.WriteLine(max);
// int min = arrs.FindMinValueOfArray();
// Console.WriteLine(min);
// int indexOfMaxValue = arrs.FindIndexofMaxValueOfArray();
// Console.WriteLine(indexOfMaxValue);
// int indexOfMinValue = arrs.FindIndexofMinValueOfArray();
// Console.WriteLine(indexOfMinValue);
// arrs.SortToMin();
// arrs.SortToMax();
// int indexOfDeleted = arrs.DeleteByValue(3);
// Console.WriteLine(indexOfDeleted);
// arrs.DeleteByValue(2);
// arrs.DeleteByValues(1);
// arrs.RemoveFewElementsByIndex(0,2);
// Console.Write(arrs.Length);
// arrs.PrintArr();
// int q = arrs.ReturnLengthOfArray();
// Console.WriteLine(q);
// Console.WriteLine();
// arrs.PrintArr();

LinkedList linkedList = new LinkedList(new int[] {1,2,3,4,5});
//
// Console.WriteLine(linkedList[2]);
// linkedList[2] = 10;
// Console.WriteLine(linkedList[2]);
// linkedList.Add(2);
linkedList.AddFirst(2);
// linkedList.RemoveFirst();
// linkedList.AddByIndex(1,77);

// linkedList.RemoveLast();
linkedList.PrintList();
Console.Read();