using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public static class StaticticOperation
    {
        public static int findSum(this Set set)
        {
            return set._elements.Sum();
        }
        public static int findRaznostb(this Set set)
        {
            return (set._elements.Max() - set._elements.Min());
        }
        public static int countElements(this Set set)
        {
            return set._elements.Count();
        }
        public static string Encrypt (this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            int shift = 3;
            StringBuilder encrypted = new StringBuilder();
            foreach (char c in input)
            {
                // Проверка, является ли символ буквой
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char encryptedChar = (char)((c + shift - offset) % 26 + offset);
                    encrypted.Append(encryptedChar);
                }
                else
                {
                    // Если символ не буква, добавляем его без изменений
                    encrypted.Append(c);
                }
            }
            return encrypted.ToString();
        }
        public static bool pepepppeppeep(this Set set)
        {
            if (set._elements.Count < 2)
                return true; // Пустой список или список из одного элемента считается упорядоченным

            for (int i = 1; i < set._elements.Count; i++)
            {
                if (set._elements[i] <= set._elements[i - 1])
                    return false; 
            }
            return true;
        }

    }
}
