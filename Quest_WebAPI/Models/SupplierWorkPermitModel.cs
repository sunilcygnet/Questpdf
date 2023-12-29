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
