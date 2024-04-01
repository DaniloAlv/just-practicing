using System.Text;

static void Agrupar()
{
    IList<Employee> employees = new List<Employee>
    {
        new Employee { Name = "Danilo", Company = "Google", Age = 26 },
        new Employee { Name = "Gustavo", Company = "IBM", Age = 25 },
        new Employee { Name = "Larissa", Company = "Amazon", Age = 23 },
        new Employee { Name = "Vlauber", Company = "Amazon", Age = 23 },
        new Employee { Name = "Guilherme", Company = "IBM", Age = 32 },
        new Employee { Name = "Fernanda", Company = "Amazon", Age = 45 },
        new Employee { Name = "Augusto", Company = "Google", Age = 29 },
        new Employee { Name = "Renata", Company = "Amazon", Age = 37 },
        new Employee { Name = "Cristina", Company = "IBM", Age = 28 }
    };

    var t = employees
        .GroupBy(emp => emp.Company, (key, emps) => new 
        {
            Company = key, 
            AverageAgeCompany = Math.Round(emps.Average(e => e.Age))
        });
    
    Console.WriteLine("--- Usando diretamente o GroupBy ---");
    foreach (var emp in t)
        Console.WriteLine($"Média de idade na {emp.Company} é {emp.AverageAgeCompany}");

    var groupByCompany = employees
        .Select(emp => new 
        {
            Company = emp.Company, 
            Age = emp.Age
        })
        .GroupBy(emp => emp.Company, (a, b) => new
        {
            Company = a, 
            AverageAge = Math.Round(b.Average(e => e.Age))
        })
        .ToList();

    Console.WriteLine("--- Usando Select com GroupBy ---");
    foreach(var item in groupByCompany)
        Console.WriteLine($"A média de idade na {item.Company} é de {item.AverageAge}");
}

Agrupar();
public class Employee
{
    public string Name { get; set; }
    public string Company { get; set; }
    public int Age { get; set; }
}


static bool IsPalindrome(string word)
{
    if (string.IsNullOrEmpty(word))
    {
        Console.WriteLine("Informe uma String válida!");
        return false;
    }

    if (word.Contains(" ") && !word.StartsWith(" ") && !word.EndsWith(" "))
        word = word.Replace(" ", "");

    var reversedCharacters = word.Reverse();
    string reversedWord = string.Join("", reversedCharacters);

    return word.Equals(reversedWord);
}

if (IsPalindrome("meticuloso")) Console.WriteLine("É Palíndromo!");
else Console.WriteLine("Não é Palíndromo!");


static int[] BubbleSort(params int[] numeros)
{
    for(int i = 1; i < numeros.Length; i++)
    {
        for (int j = 0; j < numeros.Length - i; j++)
        {
            int current = numeros[j+1];
            int previous = numeros[j];

            if (current < previous)
            {
                numeros[j] = current;
                numeros[j+1] = previous;
            }            
        }
    }

    return numeros;
}

var nums = BubbleSort(4, 5, 8, 9, 2, 11, 6);
foreach(int n in nums) Console.Write($" {n}");


static IEnumerable<int> OrdenarArvore(Node node, ref IList<int> numerosOrdenados)
{
    if (node.Left is null && node.Right is null)
        numerosOrdenados.Add(node.Value);
    else if (node.Left is not null && node.Right is not null)
    {
        OrdenarArvore(node.Left, ref numerosOrdenados);
        numerosOrdenados.Add(node.Value);
        OrdenarArvore(node.Right, ref numerosOrdenados);
    }
    else if (node.Left is not null)
    {
        OrdenarArvore(node.Left, ref numerosOrdenados);        
        numerosOrdenados.Add(node.Value);
    }
    else
    {
        numerosOrdenados.Add(node.Value);
        OrdenarArvore(node.Right, ref numerosOrdenados);
    }

    return numerosOrdenados;
}

// Colocar a seguinte árvore com os seus valores em ordem crescente

//      4 
//     / \
//    2   5
//   / \   \
//  1   3   7
//           \
//            9

Node node = new Node
{
    Value = 4, 
    Left = new Node { Value = 2, Left = new Node{ Value = 1 }, Right = new Node { Value = 3 }}, 
    Right = new Node { Value = 5, Right = new Node { Value = 7, Right = new Node { Value = 9 }} }
};

IList<int> numerosArvoreOrdenados = new List<int>();
Console.WriteLine($"Valores da árvore em ordem crescente: {string.Join(" ", OrdenarArvore(node, ref numerosArvoreOrdenados))}");


class Node 
{
    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
}
