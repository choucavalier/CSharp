using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Expressions Lambda

        List<int> list = new List<int>{5,7,6,4,2,9,7,58,7,14,1,6,4,9,1,2,45,65,87,1,5,4,5,55,1,8,9,2,1},
                    list2 = new List<int>{78,44,12,54,98,7,45,98,7,4,78,12,35,65,774,84,54,54,661,3,31,1,84,84,1};

        var list3 = list.Where(x => x%2 == 0);
        var list4 = list.Zip(list2, (x, y) => (x + y)/2);
        int count = list.Count(x => x%3 != 0);

        // Fonctions Anonymes

        list = new List<int> { 5, 7, 6, 4, 2, 9, 7, 58, 7, 14, 1, 6, 4, 9, 1, 2, 45, 65, 87, 1, 5, 4, 5, 55, 1, 8, 9, 2, 1 };
        list2 = new List<int> { 78, 44, 12, 54, 98, 7, 45, 98, 7, 4, 78, 12, 35, 65, 774, 84, 54, 54, 661, 3, 31, 1, 84, 84, 1 };

        list3 = list.Where(delegate(int x) { return x % 2 == 0; });
        list4 = list.Zip(list2, delegate(int x, int y) { return (x + y)/2; });
        count = list.Count(delegate(int x) { return x%3 == 0; });
    }
}
