using System.Reflection;

namespace WebAPI.Models;

public static class SupplierWorkPermitData
{
    public static SupplierWorkPermitModel GetWorkPermitData()
    {
        return new SupplierWorkPermitModel
        {
            Title = "Work Permit Detail",
            Checkbox = GetCheckboxesData(),
            Radios = GetRadiosData(),
            Textboxes = GetTextboxesData(),
            WorkPermitData = GenerateRandomWokPermitItem(),
            SignatureBoxes = GenerateSignatureData()
        };
    }

    private static List<SignatureSection> GenerateSignatureData()
    {
        return new List<SignatureSection> {
            new SignatureSection
            {
                Title = "Signatures",
                SignatureItems = GenerateSignatureItemsData()
            }
        };
    }

    private static List<SignatureItem> GenerateSignatureItemsData()
    {
        return new List<SignatureItem>
        {
            new SignatureItem
            {
                RequestedBy = new Item { Key = "Requested by", Value = "Sachin" },
                SignedBy = new Item { Key = "Signed by", Value = "Riller" },
                SignedAt = new Item { Key = "Date and Time", Value = "30/12/2023, 10:15" },
                Signature = new Item { Key = "Signature", Value = "Signed by email" },
                SignatureBytes = GetSignatureSampleImage("WebAPI.wwwroot.images.ram.png")
            },
            new SignatureItem
            {
                RequestedBy = new Item { Key = "Requested by", Value = "Marta" },
                SignedBy = new Item { Key = "Signed by", Value = "Devin" },
                SignedAt = new Item { Key = "Date and Time", Value = "04/12/2023, 11:00" },
                Signature = new Item { Key = "Signature", Value = "Signed by email" },
            },
        };
    }

    private static byte[] GetSignatureSampleImage(string path)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream stream = assembly.GetManifestResourceStream(path);
        using MemoryStream ms = new();
        stream.CopyTo(ms);
        return ms.ToArray();
    }

    private static List<TextboxSection> GetTextboxesData()
    {
        return new List<TextboxSection>
        {
            new TextboxSection
            {
                Title= "Title",
                Answer = "Yes",
                Answeredby = "Marta",
            },
            new TextboxSection
            {
                Title= "Title 1",
                Answer = "No",
                Answeredby = "Sunil",
            },
        };
    }

    private static List<RadioSection> GetRadiosData()
    {
        return new List<RadioSection>
        { new RadioSection
            {
                Title= "Seacurity measures during work",
                RadioItems = GetRadiosItemsData(),
        },
            new RadioSection
            {
                Title= "Required Documents",
                 RadioItems = GetRadiosItemsData(),
            },
        };
    }

    private static CheckboxSection GetCheckboxesData()
    {
        return new CheckboxSection
        {
            Title = "Risk identification",
            CheckboxItems = GetCheckboxItemsData(),
            Images = SupplierWorkPermitImages.GetCheckBoxImagesData(),
            Answeredby = new Item { Key = "Answered by", Value = "Sachin" },
            Comments = new Item { Key = "Comments", Value = "The additional instructions detail specific steps that may not be included in the main instructions but are essential for achieving optimal results. By providing this additional information, the goal is to ensure that each stage of the process is understood and executed correctly." },
        };


    }

    private static List<Item> GetCheckboxItemsData()
    {
        return new List<Item> {
          new Item { Key = "Dangerous Substances/Mixtures", Value = "true" },
          new Item { Key = "Hazardous Substances", Value = "false" }

        };
    }

    private static List<RadioItem> GetRadiosItemsData()
    {
        return new List<RadioItem>
        {
            new RadioItem
            {
                Images = SupplierWorkPermitImages.GetRadiosImagesData(),
                Answer  =   new Item{ Key= "Answer" ,Value="Yes" },
                Answeredby = new Item{ Key= "Answered by" ,Value="Marta" },
                 QuestionAnswer = GetRadioQuestionAnswerData(),
                Comments = new Item{ Key= "Comments" ,Value="The additional instructions detail specific steps that may not be included in the main instructions but are essential for achieving optimal results. By providing this additional information, the goal is to ensure that each stage of the process is understood and executed correctly." },
            },
            new RadioItem
            {
                Images = null ,
                 Answer  =   new Item{ Key= "Answer" ,Value="No" },
                Answeredby = new Item{ Key= "Answered by" ,Value="Sunil" },
                 QuestionAnswer = GetRadioQuestionAnswerData2(),
                Comments = new Item{ Key= "Comments" ,Value="The additional instructions detail specific steps that may not be included in the main instructions but are essential for achieving optimal results. By providing this additional information, the goal is to ensure that each stage of the process is understood and executed correctly." },
            },
        };
    }

    private static Item GetRadioQuestionAnswerData()
    {
        return new Item { Key = "Item's name", Value = "Product residues present" };
    }
    private static Item GetRadioQuestionAnswerData2()
    {
        return new Item { Key = "Item's name", Value = "Helmet (PPE)" };
    }
    private static Item GetRadioQuestionAnswerData3()
    {
        return new Item { Key = "Item's name", Value = "Goggles (PPE)" };
    }

    private static Item GetCheckboxQuestionAnswerData()
    {
        return new Item { Key = "Dangerous Substances/Mixtures", Value = "true" };
    }
    private static Item GetCheckboxQuestionAnswerData1()
    {
        return new Item { Key = "Hazardous Substances", Value = "false" };
    }

    private static List<Item> GenerateRandomWokPermitItem()
    {
        return new List<Item>
                {
                    new Item{ Key ="Status", Value="APPROVED" },
                    new Item{ Key ="Form", Value="Quick Risk Assessment and Safety Measures" },
                    new Item{ Key ="Company name", Value="Climatizaciones Hermanos Herrera - SN-5678" },
                    new Item{ Key ="Trade", Value="AV2-9419" },

                    new Item{ Key ="Site and activity", Value="EcoTech Innovations Hub: Logística" },
                    new Item{ Key ="Employees", Value="Laura López, Sara Pérez" },
                    new Item{ Key ="Applicant", Value="Teresa Morales" },
                    new Item{ Key ="Start date", Value="05 / 06 / 2023 10:30" },

                    new Item{ Key ="End date", Value="10 / 06 / 2023 10:30" },
                    new Item{ Key ="Additional information", Value="-" },

                };
    }
}
