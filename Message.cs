using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Work
{
    public class Message
    {
        public static string letters_ru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public static string letters_RU = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public static Dictionary<char, int> keyValues_ru = new Dictionary<char, int>();
        public static Dictionary<char, int> keyValues_RU = new Dictionary<char, int>();
        public string Text { get; set; }
        public string Key { get; set; }
        public Message(string text, string key)
        {
            Text = text;
            Key = key;
        }
        public static void FillDictionary(Dictionary<char, int> dictionary, string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                dictionary.Add(s[i], i);
            }
        }
        public string Decode()
        {
            string decoded_message = "";
            int shiftCount = 0;
            int shift;
            foreach (char c in Text)
            {
                if (letters_ru.Contains(c))
                {
                    shift = keyValues_ru[c];
                    char letter = Key[shiftCount];
                    shift -= keyValues_ru[letter];
                    if (shift < 0) 
                    {
                        shift += 33; 
                    }
                    decoded_message += keyValues_ru.ElementAt(shift).Key;
                    shiftCount++;
                    if (shiftCount == Key.Length)
                    {
                        shiftCount = 0;
                    }
                }
                else if (letters_RU.Contains(c))
                {
                    shift = keyValues_RU[c];
                    shift -= keyValues_ru[Key[shiftCount]];
                    if (shift < 0)
                    {
                        shift += 33;
                    }
                    decoded_message += keyValues_RU.ElementAt(shift).Key;
                    shiftCount++;
                    if (shiftCount == Key.Length)
                    {
                        shiftCount = 0;
                    }
                }
                else
                {
                    decoded_message += c;
                }
            }

            return decoded_message;
        }
        public string Encode()
        {
            string encoded_message = "";
            int shiftCount = 0;
            int shift;
            foreach (char c in Text)
            {
                if (letters_ru.Contains(c))
                {
                    shift = keyValues_ru[c];
                    char letter = Key[shiftCount];
                    shift += keyValues_ru[letter];
                    if (shift > 32)
                    {
                        shift -= 33;
                    }
                    encoded_message += keyValues_ru.ElementAt(shift).Key;
                    shiftCount++;
                    if (shiftCount == Key.Length)
                    {
                        shiftCount = 0;
                    }
                }
                else if (letters_RU.Contains(c))
                {
                    shift = keyValues_RU[c];
                    shift += keyValues_ru[Key[shiftCount]];
                    if (shift < 0)
                    {
                        shift -= 33;
                    }
                    encoded_message += keyValues_RU.ElementAt(shift).Key;
                    shiftCount++;
                    if (shiftCount == Key.Length)
                    {
                        shiftCount = 0;
                    }
                }
                else
                {
                    encoded_message += c;
                }
            }
            return encoded_message;
        }
    }
}
