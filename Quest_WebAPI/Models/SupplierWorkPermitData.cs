
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using static QuestPDF.Helpers.Colors;

namespace WebAPI.Models;

public static class SupplierWorkPermitData
{
    public static SupplierWorkPermitModel GetWorkPermitData()
    {
        return new SupplierWorkPermitModel
        {
            Title = "Work Permit Detail",
            Checkboxes = GetCheckboxesData(),
            Radios = GetRadiosData(),
            Textboxes = GetTextboxesData(),
            WorkPermitData = GenerateRandomWokPermitItem()
        };
    }

    private static List<TextboxSection> GetTextboxesData()
    {
        return new List<TextboxSection>
        { new TextboxSection
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

    private static List<RadioItem> GetRadiosItemsData()
    {
        return new List<RadioItem>
        {
            new RadioItem
            {
                Images = GetImages.GetRadiosImagesData() ,
                Answer  =   "Yes",
                Answeredby = "Marta",
                 QuestionAnswer = GetRadioQuestionAnswerData(),
                Comments = "Radio comments 1",
            },
            new RadioItem
            {
                Images = null ,
                Answeredby = "Sunil",
                Answer  =   "No",
                QuestionAnswer = GetRadioQuestionAnswerData2(),
                Comments = "Radio comments 2",
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


    private static List<CheckboxSection> GetCheckboxesData()
    {
        return new List<CheckboxSection> {
            new CheckboxSection {
                Title= "Checkbox Section Title",
                Images = GetImages.GetRadiosImagesData() ,
                Answeredby = "Sachin",
                Questionanswer = GetCheckboxQuestionAnswerData(),
                Comments = "Checkbox Section comments 1",
            },
             new CheckboxSection {
                Title= "Checkbox Section Title 2 ",
                Images = GetImages.GetRadiosImagesData() ,
                Answeredby = "Sunil",
               Questionanswer = GetCheckboxQuestionAnswerData1(),
                Comments = "Checkbox Section comments 2",
            },
        };
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
