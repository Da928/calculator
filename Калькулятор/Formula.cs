using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Compute
{
    class Formula
    {
        static private byte getPrioritet (char p)
        {
            switch (p)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: return 3;
            }
        }
        //"Входной" метод класса
        static public string Calculatetext(string input)
        {
            ArrayList output = postfiksForm(input); //Преобразовываем выражение в постфиксную запись
           // double result = Counting(output);
            //string resultstring = Convert.ToString(result);//Решаем полученное выражение
            string stroka = Convert.ToString(output);
            return stroka; //Возвращаем результат
        } 

        static private ArrayList postfiksForm(string input)
        {
            ArrayList output = new ArrayList();
            Stack<string> openStack = new Stack<string>();
            ArrayList list = new ArrayList(input.Split(' '));

            foreach (string element in list)
            {
                char e = element[0];

                if (e > 1 || e >= '0' && e <= '9')
                {
                    output.Add(element);
                }
                else if (e == '(') 
                {
                    openStack.Push(element);
                }
                else if (e == ')')
                {
                    string s = openStack.Pop();

                    while (s[0] != '(')
                    {
                        output.Add(s);
                        s = openStack.Pop();
                    }
                }
                if (e == '+' || e == '-' || e == '*' || e == '/') 
                {
                    if (openStack.Count == 0)
                    {
                        openStack.Push(element);
                    }
                    else if (getPrioritet(e) <= getPrioritet(openStack.Peek()[0]))
                    {
                        output.Add(openStack.Pop()); //там вот есть условие что мы  выталкиваем верхний элемент стека в выходную строку, я так понял это должны быть операторы. 
                        // Но я не найду в коде, как они вообще попадают в стек  

                    }
                }

            }

            while (openStack.Count > 0)
                output.Add(openStack.Pop());
            
            return output;
        }

    }
}
