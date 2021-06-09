using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingChallenge
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("-- Coding Challenge --");

            Console.WriteLine("\n\nEnter sentence: ");
            string sentence = Console.ReadLine();

            string newLine = sentenceReplace(sentence);

            Console.WriteLine("\n\nResult: " + newLine);
            Console.Read();
        }

        private static string sentenceReplace(string sentenceToEdit)
        {
            string newSentence = "",editedSentence=sentenceToEdit;
            bool isCompleted = false;
            int strStart=0, strNewEnd=0;

            System.Diagnostics.Debug.WriteLine("Linea original - " + sentenceToEdit);

            while(isCompleted == false)
            {
                var regex = new Regex(@"[^a-zA-Z]|[\s]"); //|[0-9]
                var match = regex.Match(editedSentence);

                if(match.Index == 0)
                {
                    strStart = match.Index;

                    regex = new Regex("[0-9]");
                    match = regex.Match(editedSentence);

                    if (match.Index == 0)
                    {
                        newSentence += match;
                        editedSentence = editedSentence.Substring(strStart+1, editedSentence.Length - 1);
                    }
                    else
                    {
                        newSentence += editedSentence.Substring(strStart, strStart + 1) + editedSentence.Substring(strStart + 1, editedSentence.Length - 2).Length.ToString() +
                        editedSentence.Substring(editedSentence.Length - 1, 1) + match;

                        editedSentence = sentenceToEdit.Substring(strStart, sentenceToEdit.Length - strStart);
                    }                    

                    if(editedSentence.Length == sentenceToEdit.Length)
                    {
                        isCompleted = true;
                    }

                    System.Diagnostics.Debug.WriteLine("- " + newSentence);
                }
                else
                {
                    strNewEnd = match.Index;

                    newSentence += editedSentence.Substring(strStart, strStart+1) + editedSentence.Substring(strStart + 1, strNewEnd -2).Length.ToString() +
                        editedSentence.Substring(strNewEnd - 1, 1) + match;

                    strStart = match.Index+1;
                    
                    editedSentence = editedSentence.Substring(strStart, editedSentence.Length-strStart);

                    if(editedSentence == "")
                    {
                        isCompleted = true;
                    }

                    System.Diagnostics.Debug.WriteLine("- " + newSentence);
                }

                
            }
            
            return newSentence;
        }
    }
}
