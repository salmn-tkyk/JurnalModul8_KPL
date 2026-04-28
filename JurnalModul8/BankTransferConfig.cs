using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Timers;

public class BanktransferConfig
{
    public string lang { get; set; }
    public TransferConfig transfer { get; set; }
    public List<string> methods { get; set; }
    public ConfirmationConfig confirmation { get; set; }

    public BanktransferConfig()
    {
        lang = "en";
        transfer = new TransferConfig(25000000, 6500, 15000);
        confirmation = new ConfirmationConfig("yes", "ya");
        methods = new List<string> { "RTO(real - time)", "SKN", "RTGS", "BI FAST" };
    }
}

public class TransferConfig
{
    public string threshold { get; set; }
    public string low_fee { get; set; }
    public string high_fee { get; set; }

    [JsonConstructor]
    public TransferConfig() { }
    public TransferConfig(int threshold, int low_fee, int high_fee)
    {
        this.threshold = threshold.ToString();
        this.low_fee = low_fee.ToString();
        this.high_fee = high_fee.ToString();
    }
}

public class ConfirmationConfig
{
    public string en { get; set; }
    public string id { get; set; }

    [JsonConstructor]
    public ConfirmationConfig() { }
    public ConfirmationConfig(string en, string id)
    {
        this.en = en;
        this.id = id;
    }
}