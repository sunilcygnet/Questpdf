using QuestPDF.Helpers;

namespace WebAPI.Models;

public static class WPDocumentDataSource
{
    //private static List<string> GetImagesNumbers()
    //{
    //    return new List<string>(new string[] { "\\images\\1.png", "\\images\\2.png", "\\images\\3.png", "\\images\\4.png", "\\images\\5.png", "\\images\\6.png", "\\images\\7.png", });
    //}

    ////////////////////////////// NEw 
    ///

    public static WorkPermitModel GetWPDetails()
    {
        return new WorkPermitModel
        {

            Items = GenerateRandomItem(),
            WorkPermit = GenerateRandomWokPermitItem(),
            SecurityMeasure = GenerateRandomSecurityMeasureItem(),
            ImagesItems = GetImages(),
            AdditionalInstruction = GenerateRandomAdditionalInstructionItem(),
            Firms = GenerateRandomFirmasItem(),
            RiskIdentification = GenerateRandomRiskIdentificationItem(),
        };
    }

    private static List<string> GetImages()
    {
        return new List<string>(new string[] { "\\images\\security-image-1.png", "\\images/security-image-2.png", "\\images\\image-1.png", "\\images\\image-2.png", "\\images\\image-3.png", "\\images\\image.png", });
    }

    private static List<Item> GenerateRandomItem()
    {
        var items = new List<Item>
            {
                new Item{ Key ="Status", Value="APPROVED" },
                new Item{ Key ="Form", Value="Quick Risk Assessment and Safety Measures" },
                new Item{ Key ="Company name", Value="Climatizaciones Hermanos Herrera - SN-5678" },
                new Item{ Key ="Trade", Value="AV2-9419" },
            };
        return items;

    }

    private static List<Item> GenerateImageCollections()
    {
        var items = new List<Item>
            {
                new Item{ Key ="Images", Value="security-image-1.png" },
                new Item{ Key ="Images", Value="image-2.png" },
            };
        return items;

    }
    private static WorkPermit GenerateRandomWokPermitItem()
    {
        WorkPermit workPermit = new WorkPermit();
        workPermit.WorkPermitItems = new List<Item>
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
        workPermit.Titles = "Work Permit details:";
        return workPermit;
    }
    private static SecurityMeasure GenerateRandomSecurityMeasureItem()
    {
        SecurityMeasure _securityMeasure = new SecurityMeasure();
        _securityMeasure.SecurityMeasureItems = new List<Item>
                {
                    new Item{ Key ="Item's name", Value="Product residues present" },
                    new Item{ Key ="Answer", Value="No" },
                    new Item{ Key ="Comment", Value="No Product residues present" },
                    new Item{ Key ="Respondent", Value="Marta Vilena" },

                    new Item{ Key ="Item's name", Value="Goggles (PPE)" },
                    new Item{ Key ="Answer", Value="Yes" },
                    new Item{ Key ="Comment", Value="" },
                    new Item{ Key ="Answered by", Value="Marta Vilena" },

                    new Item{ Key ="Item's name", Value="Safety Shoes" },
                    new Item{ Key ="Answer", Value="Yes" },
                    new Item{ Key ="Comment", Value="" },
                    new Item{ Key ="Answered by", Value="Marta Vilena" },

                    new Item{ Key ="Item's name", Value="Flame-resitance and antistatic clothig (PPE)" },
                    new Item{ Key ="Answer", Value="Yes" },
                    new Item{ Key ="Comment", Value="" },
                    new Item{ Key ="Answered by", Value="Marta Vilena" },

                    //new Item{ Key ="Images", Value="security-image-1.png" },
                    //new Item{ Key ="Images", Value="security-image-2.png" },

                };
        _securityMeasure.Titles = "Seacurity measures during work";
        return _securityMeasure;
    }

    private static AdditionalInstruction GenerateRandomAdditionalInstructionItem()
    {
        AdditionalInstruction _additionalInstruction = new AdditionalInstruction();
        _additionalInstruction.AdditionalInstructionItems = new List<Item>
                {
                    new Item{ Key ="Comment", Value="The additional instructions detail specific steps that may not be included in the main instructions but are essential for achieving optimal results. By providing this additional information, the goal is to ensure that each stage of the process is understood and executed correctly." },
                    new Item{ Key ="Answered by", Value="Marta Villena" },


                };
        _additionalInstruction.Titles = "Additional instructions or precautions to be followed by the executor";
        return _additionalInstruction;
    }

    private static Firmas GenerateRandomFirmasItem()
    {
        Firmas _firmas = new Firmas();
        _firmas.FirmasItems = new List<Item>
                {
                    new Item{ Key ="Requested by", Value="Lucía Freitas" },
                    new Item{ Key ="Signed by", Value="Marcus Rodriguez - 36729421A" },
                    new Item{ Key ="Date and time", Value="30/11/2023, 10:00" },
                    new Item{ Key ="Signature", Value="Marta Vilena" },

                    new Item{ Key ="Item's name", Value="Helmet (PPE)" },
                    new Item{ Key ="Answer", Value="No" },
                    new Item{ Key ="Comment", Value="No helmet" },
                    new Item{ Key ="Answered by", Value="Marta Vilena" },

                    new Item{ Key ="Item's name", Value="Full-face eye protection (goggles) (PPE)" },
                    new Item{ Key ="Answer", Value="Yes" },
                    new Item{ Key ="Comment", Value="" },
                    new Item{ Key ="Answered by", Value="Marta Vilena" },


                };
        _firmas.Titles = "Firmas";
        return _firmas;
    }

    private static RiskIdentification GenerateRandomRiskIdentificationItem()
    {
        RiskIdentification _riskIdentification = new RiskIdentification();
        _riskIdentification.RiskIdentificationItems = new List<Item>
                {
                    new Item{ Key ="Checked", Value="Dangerous Substances/Mixtures" },
                    new Item{ Key ="Unchecked", Value="Hazardous Substances" },
                    new Item{ Key ="Unchecked", Value="Risks Due to Equipment/Facilities" },
                    new Item{ Key ="Checked", Value="Work on Control Elements (Levels, Relief Valves, Refrigerators, etc.)" },
                    new Item{ Key ="Unchecked", Value="Fire Permit Required" },

                    //new Item{ Key ="Comment", Value="Dangerous Substances/Mixtures and Work on Control Elements (Levels, Relief Valves, Refrigerators, etc.)" },
                    //new Item{ Key ="Answered by", Value="Marta Villena" },

                    //new Item{ Key ="Requested by", Value="Lucía Freitas" },
                    //new Item{ Key ="Signed by", Value="Olivia Campell - 36729421A" },
                    //new Item{ Key ="Date and time", Value="30/11/2023, 12:45" },
                    //new Item{ Key ="Signature", Value="Marta Vilena" },

                    //new Item{ Key ="Requested by", Value="Lucía Freitas" },
                    //new Item{ Key ="Signed by", Value="Sara Pérez - 36729421A" },
                    //new Item{ Key ="Date and time", Value="02/11/2023, 10:00" },
                    //new Item{ Key ="Signature", Value="Signed by email" },


                };
        _riskIdentification.Titles = "Risk identification";
        return _riskIdentification;
    }
}


