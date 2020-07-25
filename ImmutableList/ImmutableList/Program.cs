using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace ImmList
{
    class Program
    {
        //Write an immutable function that merges the following inputs into a single list. (Feel free to use the space below or submit a link to your work.)
        //Inputs
        //- Original list of strings
        //- List of strings to be added
        //- List of strings to be removed
        //Return
        //- List shall only contain unique values
        //- List shall be ordered as follows
        //--- Most character count to least character count
        //--- In the event of a tie, reverse alphabetical
        //Other Notes
        //- You can use any programming language you like
        //- The function you submit shall be runnable
        //For example:
        //Original List = ['one', 'two', 'three',]
        //Add List = ['one', 'two', 'five', 'six]
        //Delete List = ['two', 'five']
        //Result List = ['three', 'six', 'one']
        static void Main(string[] args)
        {
            var org = ImmutableList.Create(new string[] { "one", "two", "three" });
            var add = ImmutableList.Create(new string[] { "one", "two", "five", "six" });
            var del = ImmutableList.Create(new string[] { "two", "five" });
            var res = ImmutableList.Create(new string[] { "three", "six", "one" });

            var result = ChangeList(org, add, del);

            if (result.Count != res.Count)
            {
                throw new Exception("Lengths don't match!");
            }
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] != res[i])
                {
                    throw new Exception("The items at position {0} don't match!");
                }
            }
        }

        private static ImmutableList<string> ChangeList(ImmutableList<string> original, ImmutableList<string> add, ImmutableList<string> remove)
        {
            List <string> temp = new List<string>(original);

            // ADD
            temp.AddRange(add);
            // REMOVE
            var rm = new HashSet<string>(remove);
            temp.RemoveAll(str => rm.Contains(str));
            // SORT
            temp.Sort(CompareItems);
            // UNIQUE
            for (int i = temp.Count-2; i >= 0; i--)
            {
                if (temp[i+1] == temp[i])
                {
                    temp.RemoveAt(i + 1);
                }
            }

            return ImmutableList.Create(temp.ToArray());
        }


        /// <summary>
        /// Make a method for comparing the list items based on the specified rules.
        /// - List shall be ordered as follows
        /// --- Most character count to least character count
        /// --- In the event of a tie, reverse alphabetical
        /// </summary>
        private static int CompareItems(string item1, string item2)
        {
            // If other is not a valid object reference, this instance is greater.
            if (item2 == null)
            {
                if (item1 == null)
                    return 1;
                else 
                    return 1;
            }

            //- List shall be ordered as follows
            //--- Most character count to least character count
            //--- In the event of a tie, reverse alphabetical
            if (item1.Length == item2.Length)
            {
                return item1.CompareTo(item2) * -1; //swap to reverse order by multiplying by neg 1
            }
            else
            {
                return item1.Length.CompareTo(item2.Length) * -1; // reverse order
            }
        }

    }
}
