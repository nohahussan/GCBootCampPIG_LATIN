using System;

namespace ConverterToPigLatin
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!\n");
            Boolean repeat = true;
            do {
                Console.WriteLine("Enter a line to be translated:");
                string userInput = Console.ReadLine().ToLower();
                 string pigLatin  = ConverterToPigLatin(userInput);
                Console.WriteLine(pigLatin);

                repeat = Continue(repeat);//cheek if the user would like to continue
            } while (repeat);
        }
        public static string ConverterToPigLatin (string sentence)
        {
            string finalSentence = "";
            //if the sentence begins with white space trim it
            sentence = sentence.TrimStart(' ');
            string[] words  = sentence.Split(' ');//store word by word in the array
            for (int i = 0; i < words.Length; i++)
            {
                string firstLetter = words[i].Substring(0, 1);//first letter in each word
                //if a word starts with vowel add way to the end
                if (firstLetter == "a" || firstLetter == "e" || firstLetter == "i" || firstLetter == "o" || firstLetter == "u")
                {
                    words[i] += "way";
                }
                //if the word starts with consonant,move all of consonants that appear before the firstvowel to the end of the word,then add ay to the end
                else
                {
                    char[] chars = { 'a','e','i','o','u'};
                    int indexOfFirstVowel = words[i].IndexOfAny(chars,0);
                    string consonants = words[i].Substring(0, indexOfFirstVowel);//store first letters before first vowel appear
                    int lenAfterFirstVoewl = words[i].Length - consonants.Length;
                    words[i]= words[i].Substring( indexOfFirstVowel, lenAfterFirstVoewl) + consonants + "ay";
                }
            }
            for (int i =0; i <words.Length;i++)
            {
                finalSentence += words[i] + " ";
            }
            return finalSentence;
        }

        public static Boolean Continue(Boolean repeat)
        {
            Console.WriteLine("Translate another line?(y/n)");
            string userChoice = Console.ReadLine().ToLower();
            repeat = (userChoice == "y") ? true : false;
            return repeat;
        }
    }
}
