// See https://aka.ms/new-console-template for more information
var Balances = new Dictionary<string,decimal>()
{
    {"Wanjiru",0 },
    {"Juma",0 },
    {"Linda",0 }
};

Console.WriteLine(Balances);
foreach (var item in Balances)
    Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);

