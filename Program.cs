using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Erreur : Vous devez entrer une expression logique.");
            Console.WriteLine("Usage : truth-table \"(expression)\"");
            return;
        }

        string expression = args[0];

        try
        {
            ValidateExpression(expression);
            var variables = ExtractVariables(expression);
            int numVars = variables.Count;

            Console.WriteLine($"\n# Expression: {expression}\n");
            PrintHeader(variables);

            for (int i = 0; i < (1 << numVars); i++)
            {
                var values = GenerateValues(variables, i);
                bool result = EvaluateExpression(expression, values);
                PrintRow(values, result);
            }
            PrintFooter(variables.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
    }

    static void PrintHeader(List<char> vars)
    {
        string header = "| " + string.Join(" | ", vars.Select(v => $" {v} ")) + " |  Result  |";
        string separator = "+" + string.Concat(Enumerable.Repeat("----+", vars.Count)) + "----------+";

        Console.WriteLine(separator);
        Console.WriteLine(header);
        Console.WriteLine(separator);
    }

    static void PrintRow(Dictionary<char, bool> values, bool result)
    {
        string row = "| " + string.Join(" | ", values.Values.Select(b => b ? " 1 " : " 0 ")) + " |    " + (result ? "1" : "0") + "     |";
        Console.WriteLine(row);
    }

    static void PrintFooter(int varCount)
    {
        string separator = "+" + string.Concat(Enumerable.Repeat("----+", varCount)) + "----------+";
        Console.WriteLine(separator);
    }

    static void ValidateExpression(string expr)
    {
        if (string.IsNullOrWhiteSpace(expr))
        {
            throw new ArgumentException("L'expression ne peut pas être vide.");
        }

        int openParens = 0;
        bool lastWasOperator = true;
        List<char> validOperators = new List<char> { '~', '&', '|', '^', '(', ')' };

        for (int i = 0; i < expr.Length; i++)
        {
            char c = expr[i];

            if (char.IsLetter(c))
            {
                lastWasOperator = false;
            }
            else if (c == '(')
            {
                openParens++;
                lastWasOperator = true;
            }
            else if (c == ')')
            {
                openParens--;
                if (openParens < 0)
                    throw new ArgumentException("Parenthèses mal équilibrées.");
                lastWasOperator = false;
            }
            else if (validOperators.Contains(c))
            {
                if (lastWasOperator && c != '~' && c != '(')
                    throw new ArgumentException("Opérateur mal placé.");
                lastWasOperator = true;
            }
            else if (c == '-' && i + 1 < expr.Length && expr[i + 1] == '>')
            {
                i++;
                lastWasOperator = true;
            }
            else if (c == '=' && i + 1 < expr.Length && expr[i + 1] == '=')
            {
                i++;
                lastWasOperator = true;
            }
            else if (!char.IsWhiteSpace(c))
            {
                throw new ArgumentException($"Caractère invalide détecté : '{c}'");
            }
        }

        if (openParens != 0)
        {
            throw new ArgumentException("Parenthèses non équilibrées.");
        }

        if (lastWasOperator)
        {
            throw new ArgumentException("Expression incomplète (se termine par un opérateur).");
        }
    }

    static List<char> ExtractVariables(string expr)
    {
        return expr.Where(char.IsLetter).Distinct().OrderBy(c => c).ToList();
    }

    static Dictionary<char, bool> GenerateValues(List<char> vars, int index)
    {
        var values = new Dictionary<char, bool>();
        for (int i = 0; i < vars.Count; i++)
        {
            values[vars[i]] = (index & (1 << (vars.Count - 1 - i))) != 0;
        }
        return values;
    }

    static bool EvaluateExpression(string expr, Dictionary<char, bool> values)
    {
        string replaced = expr;
        foreach (var kvp in values)
        {
            replaced = replaced.Replace(kvp.Key.ToString(), kvp.Value ? "1" : "0");
        }
        return Evaluate(replaced);
    }

    static bool Evaluate(string expr)
    {
        expr = expr.Replace(" ", "");

        Stack<bool> values = new Stack<bool>();
        Stack<char> ops = new Stack<char>();

        for (int i = 0; i < expr.Length; i++)
        {
            char c = expr[i];

            if (c == '0' || c == '1')
            {
                values.Push(c == '1');
            }
            else if (c == '(')
            {
                ops.Push(c);
            }
            else if (c == ')')
            {
                while (ops.Count > 0 && ops.Peek() != '(')
                {
                    ApplyOperation(values, ops.Pop());
                }
                ops.Pop();
            }
            else if (c == '~' || c == '&' || c == '|' || c == '^' || c == '=' || c == '-')
            {
                if (c == '-' && i + 1 < expr.Length && expr[i + 1] == '>')
                {
                    c = '>';
                    i++;
                }
                else if (c == '=' && i + 1 < expr.Length && expr[i + 1] == '=')
                {
                    c = '=';
                    i++;
                }

                while (ops.Count > 0 && GetPrecedence(ops.Peek()) >= GetPrecedence(c))
                {
                    ApplyOperation(values, ops.Pop());
                }

                ops.Push(c);
            }
        }

        while (ops.Count > 0)
        {
            ApplyOperation(values, ops.Pop());
        }

        return values.Pop();
    }

    static int GetPrecedence(char op)
    {
        return op switch
        {
            '~' => 4,
            '&' => 3,
            '^' => 2,
            '|' => 1,
            '>' => 0,
            '=' => 0,
            _ => -1
        };
    }

    static void ApplyOperation(Stack<bool> values, char op)
    {
        if (op == '~')
        {
            bool a = values.Pop();
            values.Push(!a);
        }
        else
        {
            bool b = values.Pop();
            bool a = values.Pop();

            switch (op)
            {
                case '&': values.Push(a && b); break;
                case '|': values.Push(a || b); break;
                case '^': values.Push(a ^ b); break;
                case '>': values.Push(!a || b); break;
                case '=': values.Push(a == b); break;
            }
        }
    }
}
