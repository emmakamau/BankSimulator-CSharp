// See https://aka.ms/new-console-template for more information
var Balances = new Dictionary<string,decimal>()
{
    {"Wanjiru",0 },
    {"Juma",0 },
    {"Linda",0 }
};

// Read the file and display it line by line.
var accountLogs = new List<List<string>>();
foreach (string line in System.IO.File.ReadLines(@"C:\Users\EmmaculateKamau\OneDrive - 637 Capital\Desktop\Projects\BankSimulator\BankSimulator\Input Text.txt"))
{
    var log = new List<string>();
    string[] result = line.Split(':');
    foreach (string str in result) { log.Add(str); continue; };
    
    accountLogs.Add(log);
   
}

foreach (var account in accountLogs)
{
    if (account[0] == "DEPOSIT" && Balances.ContainsKey(account[1]))
    {
        //DEPOSIT:Wanjiru:152.00
        var depositAmt = Convert.ToDecimal(account[2]);
        decimal amount = Balances[account[1]] + depositAmt;
        Balances[account[1]] = amount;
    }
    else if (account[0] == "WITHDRAW" && Balances.ContainsKey(account[1])) 
    {
        //WITHDRAW:Wanjiru:166.00
        decimal withdrawalAmt = Convert.ToDecimal(account[2]);
        if (Balances[account[1]] > withdrawalAmt) 
        {
            decimal amount = Balances[account[1]] - withdrawalAmt;
            Balances[account[1]] = amount;
        }
        else
        {
            Console.WriteLine("Insufficient Balance");
        };       
    }
    else if (account[0] == "TRANSFER" && Balances.ContainsKey(account[1]) && Balances.ContainsKey(account[2]))
        {
            //TRANSFER:Wanjiru:Juma:300.00
            decimal transferAmt = Convert.ToDecimal(account[3]);
        if (Balances[account[1]] > transferAmt)
        {
            Balances[account[1]] = Balances[account[1]] - transferAmt;
            Balances[account[2]] = Balances[account[2]] + transferAmt;
        }
        else
        {
            Console.WriteLine("Not enough money in your acc");
        };
    };
}       

foreach (var item in Balances)
    Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);



