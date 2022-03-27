int[] QuickSort(int[] array)
{
    if (array.Length < 2)
        return array;

    var pivot = array[0];

    var less = array[1..].Where(x => x <= pivot).ToArray();
    var greater = array[1..].Where(x => x > pivot).ToArray();

    return QuickSort(less).Concat(new[] {pivot}).Concat(QuickSort(greater)).ToArray();
}

foreach (var i in QuickSort(new []{10, 5, 2, 2, 3}))
{
    Console.Write(i + " ");
}