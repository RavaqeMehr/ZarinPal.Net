namespace ZarinPalNet;

public class VerifyResult
{
    public int Code { get; set; }
    public string Message { get; set; } = default!;
    public string CardHash { get; set; } = default!;
    public string CardPan { get; set; } = default!;
    public int RefId { get; set; }
    public FeeType FeeType { get; set; }
    public int Fee { get; set; }

    public VerifyStatus GetStatus()
    {
        if (Code == 100)
            return VerifyStatus.Verified;
        else if (Code == 101)
            return VerifyStatus.VerifiedButDuplicated;
        else
            return VerifyStatus.NotVerified;
    }
}

public enum VerifyStatus
{
    Verified = 100,
    VerifiedButDuplicated = 101,
    NotVerified = -1
}
