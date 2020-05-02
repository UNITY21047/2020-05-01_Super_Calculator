using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Super_Calculator
{
    public class run
    {
        private static string maths = "";
        static void Main()
        {
            
            Process yield1 = new Process();
            Process yield2 = new Process();

            Console.Write("Equation Please: ");

            maths = Console.ReadLine();

            while(maths.Contains("x"))
            {
                maths = check_for_Xs();
            }

            Console.WriteLine("");

            string path_one = @"arithmetic.cs";
            string path_two = @"arithmetic.bat";
            string input_one = "using System;\n\nclass arithmetic\n{\n\tstatic void Main()\n\t{\n\t\tdouble math = "+ maths + ";\n\t\tConsole.WriteLine(\"Output:\" + math);\n\t\tConsole.ReadLine();\n\t}\n}";
            string input_two = "csc -out:arithmetic.exe arithmetic.cs";

            try
            {
                StreamWriter output_file_one = new StreamWriter(path_one);
                output_file_one.WriteLine(input_one);
                output_file_one.Close();
                output_file_one.Dispose();

                StreamWriter output_file_two = new StreamWriter(path_two);
                output_file_two.WriteLine(input_two);
                output_file_two.Close();
                output_file_two.Dispose();

                yield1.StartInfo.FileName = "arithmetic.bat";
                yield1.Start();
                yield1.Close();
                yield1.Dispose();

                Thread.Sleep(2000);

                yield2.StartInfo.FileName = "arithmetic.exe";
                yield2.Start();
                yield2.WaitForExit();
                yield2.Close();
                yield2.Dispose();

                Main();
            }
            catch
            {
                Console.WriteLine("``\\:)/``" + " : Not a proper function!\n");
                Main();
            }
        }
        public static string check_for_Xs()
        {
            string copy_of_math = maths;
            string[] count_one = new string[copy_of_math.Length];
            int count_two = 0;

            for (int i = 0; i < copy_of_math.Length; i++)
            {
                count_one[i] = "" + copy_of_math[i];
            }

            while (Array.IndexOf(count_one, "x") != -1)
            {
                count_two = Array.IndexOf(count_one, "x");
                Console.Write("What is this number?: ");
                count_one[count_two] = Console.ReadLine();
            }

            copy_of_math = "";

            for (int i = 0; i < count_one.Length; i++)
            {
                copy_of_math += count_one[i];
            }

            return copy_of_math;
        }
    }
}