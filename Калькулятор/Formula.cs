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
            double result = polishResult(output);
           /* string stroka = "";
            foreach (string item in output)
            {
                stroka += item;
            }*/
            return Convert.ToString(result); //Возвращаем результат
        } 

        static private ArrayList postfiksForm(string input)
        {
            ArrayList output = new ArrayList();
            Stack<string> openStack = new Stack<string>();
            ArrayList list = new ArrayList(input.Split(' '));
            ArrayList operant = new ArrayList(new char[] { '+', '-', '/', '*' });

            foreach (string element in list)
            {
                char e = element[0];

                if (e >= '0' && e <= '9')
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
                if (operant.Contains(e))//(e == '+' || e == '-' || e == '*' || e == '/') 
                {
                    while (openStack.Count != 0 && operant.Contains(openStack.Peek()[0]) && getPrioritet(e) <= getPrioritet(openStack.Peek()[0]))
                    {
                        output.Add(openStack.Pop());
                    }                                               
                    openStack.Push(element);
                }
            }

            while (openStack.Count > 0)
                output.Add(openStack.Pop());
            
            return output;
        }

        static private double polishResult (ArrayList output)
        {
         
            Stack<double> chislo = new Stack<double>();

            foreach (string znachenie in output)
            {
                char z = znachenie[0];
                
                if (z >= '0' && z <= '9')
                {
                    chislo.Push(Convert.ToDouble(znachenie));
                }
                else
                {
                    double b = chislo.Pop();
                    double a = chislo.Pop();
                    char operant = znachenie[0];
                        
                    double c = calcOperation(b, a, operant);

                    chislo.Push(c);                
                }
                

            }
            double result = chislo.Pop();

            return result;

        }

        static private double calcOperation(double b, double a, char operant)
        {
           
                switch (operant)
                {
                    case '+': return a + b;
                    case '-': return a - b;
                    case '*': return a * b;
                    case '/': return a / b;
                }
            
                throw new Exception("некорректное выражение");
            
            
            
        }
    }
}
