using System.Text;

Console.WriteLine("Для окончания введите e");
Console.WriteLine("Введите текст:");

var lines = new List<string>();

while (true)
{
    var line = Console.ReadLine();

    lines.Add(line);

    if (line == "e")
        break;
}

Console.WriteLine("Вывод:");

for (int i = 0; i < lines.Count; i++)
{
    lines[i] = CapitalizeSentences(lines[i]);
    Console.WriteLine(lines[i]);
}

static string CapitalizeSentences(string input)
{
    if (string.IsNullOrEmpty(input))
        return input;

    StringBuilder result = new StringBuilder(input.Length);
    bool newSentence = true; // флаг, означающий начало нового предложения

    foreach (char c in input)
    {
        if (newSentence && char.IsLetter(c))
        {
            // первая буква предложения -> заглавная
            result.Append(char.ToUpper(c));
            newSentence = false;
        }
        else
        {
            // все остальные буквы -> строчные
            result.Append(char.ToLower(c));
            // если встретили один из знаков препинания, за которым идёт новое предложение,
            // устанавливаем флаг для следующей буквы
            if (c == '.' || c == '!' || c == '?')
            {
                newSentence = true;
            }
        }
    }

    return result.ToString();
}