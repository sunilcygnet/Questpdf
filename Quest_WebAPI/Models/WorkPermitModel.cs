namespace WebAPI.Models
{
    public class Item
    {
        public string Key { get; set; } = "";
        public string Value { get; set; } = "";
    }

    public class WorkPermitModel
    {
        public WorkPermit WorkPermit { get; set; }
        public SecurityMeasure SecurityMeasure { get; set; }
        public AdditionalInstruction AdditionalInstruction { get; set; }
        public Firmas Firms { get; set; }
        public RiskIdentification RiskIdentification { get; set; }
        public List<Item> Items { get; set; }
        public List<string> ImagesItems { get; set; }

    }

    public class WorkPermit
    {
        public string Titles { get; set; } = "";
        public List<Item> WorkPermitItems { get; set; }
    }

    public class SecurityMeasure
    {
        public string Titles { get; set; } = "";
        public List<Item> SecurityMeasureItems { get; set; }
    }

    public class AdditionalInstruction
    {
        public string Titles { get; set; } = "";
        public List<Item> AdditionalInstructionItems { get; set; }
    }

    public class Firmas
    {
        public string Titles { get; set; } = "";
        public List<Item> FirmasItems { get; set; }
    }

    public class RiskIdentification
    {
        public string Titles { get; set; } = "";
        public List<Item> RiskIdentificationItems { get; set; }
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
}




