namespace WebAPI.Models;

public class SupplierWorkPermitModel
{
    public string Title { get; set; }
    public List<Item> WorkPermitData { get; set; }

   
    public List<RadioSection> Radios { get; set; }
    public List<CheckboxSection> Checkboxes { get; set; }
    public List<TextboxSection> Textboxes { get; set; }
}
