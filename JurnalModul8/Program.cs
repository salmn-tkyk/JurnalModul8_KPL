using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "bank_transfer_config.json";
        BanktransferConfig config;

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<BanktransferConfig>(jsonString);
        }
        else
        {
            config = new BanktransferConfig();
            string jsonString = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        if (config.lang == "en") Console.Write("Please insert the amount of money to transfer: ");
        else Console.Write("Masukkan jumlah uang yang akan di-transfer: ");

        int inputTf = int.Parse(Console.ReadLine());

        int biayaTf = inputTf <= int.Parse(config.transfer.threshold) ? int.Parse(config.transfer.low_fee) : int.Parse(config.transfer.high_fee);
        int total = inputTf + biayaTf;

        if (config.lang == "en") Console.WriteLine($"Transfer fee = {biayaTf} Total amount = {total}");
        else Console.WriteLine($"Biaya transfer = {biayaTf} Total biaya = {total}");

        if (config.lang == "en") Console.Write("Select transfer method: ");
        else Console.Write("Pilih metode transfer: ");

        for (int i = 0; i < config.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.methods[i]}");
        }
        string method = Console.ReadLine();

        string confirmToken = config.lang == "en" ? config.confirmation.en : config.confirmation.id;
        if (config.lang == "en") Console.WriteLine($"Please type {confirmToken} to confirm the transaction:");
        else Console.WriteLine($"Ketik {confirmToken} untuk mengkonfirmasi transaksi:");

        string inputConfirm = Console.ReadLine();

        if (inputConfirm == confirmToken)
        {
            Console.WriteLine(config.lang == "en" ? "The transfer is completed" : "Proses transfer berhasil");
        }
        else
        {
            Console.WriteLine(config.lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
        }
    }
}