// Scripture.cs
using System;
using System.Collections.Generic;
using System.Linq; // For .Where() and .All() extensions

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            string[] rawWords = text.Split(
                new char[] { ' ', '.', ',', ';', ':', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries
            );

            foreach (string wordText in rawWords)
            {
                _words.Add(new Word(wordText));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            List<Word> availableWordsToHide = _words.Where(w => !w.IsHidden()).ToList();

            if (numberToHide > availableWordsToHide.Count)
            {
                numberToHide = availableWordsToHide.Count;
            }

            for (int i = 0; i < numberToHide; i++)
            {
                if (availableWordsToHide.Count == 0)
                {
                    break;
                }

                int indexToHide = _random.Next(availableWordsToHide.Count);
                availableWordsToHide[indexToHide].Hide();
                availableWordsToHide.RemoveAt(indexToHide); // Prevent re-selection in same turn
            }
        }

        public string GetDisplayText()
        {
            string displayText = _reference.GetDisplayText();

            foreach (Word word in _words)
            {
                displayText += " " + word.GetDisplayText();
            }
            return displayText;
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(word => word.IsHidden());
        }
    }
}