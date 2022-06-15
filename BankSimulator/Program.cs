// See https://aka.ms/new-console-template for more information
var Balances = new Dictionary<string,decimal>()
{
    {"Wanjiru",0 },
    {"Juma",0 },
    {"Linda",0 }
};

//string text = System.IO.File.ReadAllText(@"C:\Users\EmmaculateKamau\OneDrive - 637 Capital\Desktop\Projects\BankSimulator\BankSimulator\Input Text.txt");
//Console.WriteLine(text);

// Read the file and display it line by line.

var accountLogs = new List<List<string>>();
var log = new List<string>();
foreach (string line in System.IO.File.ReadLines(@"C:\Users\EmmaculateKamau\OneDrive - 637 Capital\Desktop\Projects\BankSimulator\BankSimulator\Input Text.txt"))
{
    string[] result = line.Split(':');
    foreach (string str in result) { log.Add(str); };
    accountLogs.Add(log);
}

foreach (var account in accountLogs)
{
    Console.WriteLine(Balances.ContainsKey(account[1]));
    if (account[0] == "DEPOSIT" && Balances.ContainsKey(account[1]))
    {
        //DEPOSIT:Wanjiru:152.00
        var depositAmt = Convert.ToDecimal(account[2]);
        decimal amount = Balances[account[1]] + depositAmt;
        Balances[account[1]] = amount;
        Console.WriteLine("Deposit successful:");
    }
    else
    {
        if (account[0] == "WITHDRAW" && Balances.ContainsKey(account[0])) 
        {
            //TRANSFER:Wanjiru:Linda:218.25
            var transferAmt = Convert.ToDecimal(account[3]);
            if (Balances[account[1]] > transferAmt) 
            {
                decimal amount = Balances[account[1]]+transferAmt;
                Balances[account[1]] = amount;
                Console.WriteLine("Transfer successful:");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            };
            
        };
    }
      
}




