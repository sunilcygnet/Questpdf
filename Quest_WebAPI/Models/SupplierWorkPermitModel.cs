namespace WebAPI.Models;

public class SupplierWorkPermitModel
{
    public string Title { get; set; }
    public List<Item> WorkPermitData { get; set; }   
    public List<RadioSection> Radios { get; set; }
    public CheckboxSection Checkbox { get; set; }
    public List<TextboxSection> Textboxes { get; set; }
    public List<SignatureSection> SignatureBoxes { get; set; }
}

public class Item
{
    public string Key { get; set; } = "";
    public string Value { get; set; } = "";
}

public class RadioSection
{
    public string Title { get; set; }
    public List<RadioItem> RadioItems { get; set; }

}

public class RadioItem
{
    public Item QuestionAnswer { get; set; }
    public List<byte[]> Images { get; set; }
    public Item Comments { get; set; }
    public Item Answer { get; set; }
    public Item Answeredby { get; set; }
}

public class CheckboxSection
{
    public string Title { get; set; }
    //public List<CheckboxItem> CheckboxItems { get; set; }
    public List<Item> CheckboxItems { get; set; }
    public List<byte[]> Images { get; set; }
    public Item Comments { get; set; }
    public Item Answeredby { get; set; }
}


public class TextboxSection
{
    public string Title { get; set; }
    public string Answeredby { get; set; }
    public string Answer { get; set; }
}

public class SignatureSection
{
    public string Title { get; set; }
    public List<SignatureItem> SignatureItems { get; set; }
}

public class SignatureItem
{
    public Item RequestedBy { get; set; }
    public Item SignedBy { get; set; }
    public Item SignedAt { get; set; }
    public Item Signature { get; set; }
    public byte[] SignatureBytes { get; set; }
}
