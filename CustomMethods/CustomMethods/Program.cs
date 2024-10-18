namespace CustomMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Custom Split
            string testString = "apple,orange,banana";
            string[] splitResult = CustomSplit(testString, ',');
            Console.WriteLine(splitResult);

            // Custom Replace
            string replaceResult = CustomReplace(testString, ',', ';');
            Console.WriteLine(replaceResult);

            // Custom LastIndexOf
            int lastIndex = CustomLastIndexOf(testString, 'a');
            Console.WriteLine(lastIndex);
        }

        public static string[] CustomSplit(string input, char separator)
        {
            // Simvolun neçə dəfə təkrarlandığını taparaq array ölçüsünü təyin edirik
            int count = 1;
            foreach (char c in input)
            {
                if (c == separator)
                {
                    count++;
                }
            }

            string[] result = new string[count];
            int currentIndex = 0;
            string temp = string.Empty;

             foreach (char c in input)
             {
                 if (c == separator)
                 {
                     if (temp.Length != 0)
                     {
                         result[currentIndex] = temp;
                         currentIndex++;
                         temp = string.Empty;
                     }
                                  
                 }
                 else
                 {
                     temp += c;
                
            
                 }
             }

            // Sonuncu parçanı əlavə edirik:
            result[currentIndex] = temp;

            return result;
        }

        public static string CustomReplace(string input, char oldChar, char newChar)
        {
            // Input uzunluğunda yeni char array yaradılır
            char[] result = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == oldChar)
                {
                    result[i] = newChar;
                }
                else
                {
                    result[i] = input[i];
                }
            }

            // Char array'dən string yaradılır
            return new string(result);
        }

        public static int CustomLastIndexOf(string input, char value)
        {
            // Input array'dən sonuncu indeksdən başlayaraq simvolu axtarırıq
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == value)
                {
                    return i;
                }
            }

            return -1; // Simvol tapılmadısa
        }



    }
}
