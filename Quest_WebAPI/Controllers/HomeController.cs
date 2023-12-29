using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using SkiaSharp;
using WebAPI.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;

    private bool isShowFooter = true;
    private string strTitle = "Firmas";
    private SupplierWorkPermitModel Model;

    public HomeController(IWebHostEnvironment environment)
    {
        _environment = environment;
        Model = SupplierWorkPermitData.GetWorkPermitData();
    }

    [HttpGet]
    public IActionResult Index()
    {
        GeneratePDFSample();

        return Ok();
    }

    private void GeneratePDFSample()
    {
        var document = Document.Create(ComposeDocument);
        document.GeneratePdf("hello.pdf");
        // use the following invocation
        document.ShowInPreviewer();
    }

    private void ComposeImages(IContainer container)
    {
        if (Model.Radios[0].RadioItems != null)
        {
            double rowWidth = 523;
            int imageWidth = 250;
            int imageCount = Model.Radios[0].RadioItems.Count;
            int perRowImages = (int)(rowWidth / imageWidth);
            int requiredRow = (int)Math.Ceiling(Convert.ToDouble(imageCount / perRowImages));

            container.Column(c =>
            {
                for (int i = 0; i < requiredRow; i++)
                {
                    c.Item().Row(row =>
                    {
                        for (int j = 0; j < perRowImages; j++)
                        {
                            int imageNumber = i * perRowImages + j;

                            if (imageNumber < imageCount)
                                //row.AutoItem().Width(imageWidth).Padding(2).Image(_environment.WebRootPath + Model.Radios[0].RadioItems[imageNumber]);
                                row.AutoItem().Width(imageWidth).Padding(2).Image(Model.Radios[0].RadioItems[0].Images[imageNumber]);

                        }
                    });
                }
            });
        }
    }

    #region ComposeHeader
    private void ComposeHeader(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().MaxWidth(100).PaddingBottom(5, Unit.Millimetre).Image(Path.Combine(_environment.WebRootPath, "images/logo.png"));

            });
        });
    }
    #endregion

    #region ComposeDocument
    private void ComposeDocument(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.PageColor(Colors.White);
            page.Margin(36, Unit.Point);//36 points means .5 inch,  72 points means 1 inch

            page.Header().ShowOnce().Element(ComposeHeader);

            page.Content().Element(ComposeContent);

            page.Footer().AlignRight()
                 .Text(x =>
                {
                    x.CurrentPageNumber();
                    x.Span(" of ");
                    x.TotalPages();
                });
        });
    }

    #endregion

    #region ComposeContent

    private void ComposeTitle(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(c =>
            {
                c.Item().Element(HeaderCellStyle).Text(strTitle);
            });
            static IContainer HeaderCellStyle(IContainer container)
            {
                return container.DefaultTextStyle(x => x.Bold()).PaddingBottom(5).BorderBottom(1).BorderColor(Colors.Black);
            }
        });
    }

    private void ComposeContent(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Element(ComposeWorkPermitTable);  // Work Permit Content

            column.Item().Element(ComposeRadioSection);// SecurityMeasure Content

            column.Item().Element(ComposeCheckboxSection); // Risk identification Content

            ///*column.Item().Element(ComposeImagesTable);*/  // Render images which will provided in list

            column.Item().Element(ComposeSignatureSection);


            #region Methods
            //void ComposeTableSecurityMeasure(IContainer container)
            //{
            //    container.Column(column =>
            //    {
            //        //Title 
            //        strTitle = Model.SecurityMeasure.Titles;
            //        column.Item().Element(ComposeTitle);

            //        // Table
            //        column.Item().Table(table =>
            //        {

            //            table.ColumnsDefinition(columns =>
            //            {
            //                columns.ConstantColumn(190);
            //                columns.RelativeColumn();
            //            });

            //            table.Footer(header =>
            //            {
            //                header.Cell().Element(HeaderCellStyle).Text("");
            //                header.Cell().Element(HeaderCellStyle).Text("");

            //                static IContainer HeaderCellStyle(IContainer container)
            //                {
            //                    return container.DefaultTextStyle(x => x.Bold()).PaddingBottom(1).BorderBottom(1).BorderColor(Colors.Black);
            //                }
            //            });

            //            if (Model.SecurityMeasure.SecurityMeasureItems != null)
            //            {

            //                for (int i = 0; i < Model.SecurityMeasure.SecurityMeasureItems.Count; i++)
            //                {
            //                    var item = Model.SecurityMeasure.SecurityMeasureItems[i];

            //                    if (i % 2 == 0)
            //                    {
            //                        table.Cell().Element(GrayCellStyle).Text(item.Key).Bold(); table.Cell().Element(GrayCellStyle).Text(item.Value);
            //                    }
            //                    else
            //                    {
            //                        table.Cell().Element(TransparentCellStyle).Text(item.Key).Bold(); table.Cell().Element(TransparentCellStyle).Text(item.Value);
            //                    }
            //                }

            //            }

            //            static IContainer GrayCellStyle(IContainer container)
            //            {
            //                return container.Background("#F5F5F5").PaddingVertical(5);
            //                //return container.BorderBottom(1).BorderColor(Colors.Grey.Medium).PaddingVertical(5);
            //            }
            //            static IContainer TransparentCellStyle(IContainer container)
            //            {
            //                return container.BorderBottom(1).BorderColor(Colors.Transparent).PaddingVertical(5);
            //            }
            //        });
            //    });

            //}

            //void ComposeWorkPermitTable(IContainer container)
            //{
            //    container.Column(column =>
            //    {
            //        // Table
            //        column.Item().Table(table =>
            //        {
            //            table.ColumnsDefinition(columns =>
            //            {
            //                columns.ConstantColumn(170);
            //                columns.RelativeColumn();
            //            });

            //            if (Model.WorkPermit != null)
            //            {
            //                for (int i = 0; i < Model.WorkPermit.WorkPermitItems.Count; i++)
            //                {
            //                    var item = Model.WorkPermit.WorkPermitItems[i];
            //                    if (item.Key.Contains("Status"))
            //                    {
            //                        table.Cell().Element(FieldCellStyle).Text(item.Key).Bold();
            //                        table.Cell().Element(ComposeStatus);
            //                    }
            //                    else
            //                    {
            //                        table.Cell().Element(FieldCellStyle).Text(item.Key).Bold();
            //                        table.Cell().Element(CellStyle).Text(item.Value);
            //                    }
            //                }
            //            }

            //            static IContainer CellStyle(IContainer container)
            //            {
            //                return container.BorderBottom(1).BorderColor(Colors.Transparent).PaddingVertical(5);
            //            }

            //            static IContainer FieldCellStyle(IContainer container)
            //            {
            //                return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(1).BorderBottom(0).BorderColor(Colors.Transparent);
            //            }
            //        });

            //    });
            //}

            ////void ComposeImagesTable(IContainer container)
            ////{
            ////    container.Table(table =>
            ////    {
            ////        table.ColumnsDefinition(columns =>
            ////        {
            ////            columns.RelativeColumn();

            ////        });

            ////        if (Model.ImagesItems != null)
            ////        {
            ////            for (int i = 0; i < Model.ImagesItems.Count; i++)
            ////            {
            ////                var item = Model.ImagesItems[i];
            ////                table.Cell().MaxWidth(250).Padding(5).Image(_environment.WebRootPath + item.Value);
            ////            }
            ////        }
            ////    });
            ////}

            //void ComposeCommentTable(IContainer container)
            //{
            //    container.Column(column =>
            //    {
            //        //Show Title 
            //        strTitle = Model.AdditionalInstruction.Titles;
            //        column.Item().Element(ComposeTitle);

            //        column.Item().Table(table =>
            //        {

            //            table.ColumnsDefinition(columns =>
            //            {
            //                columns.ConstantColumn(170);
            //                columns.RelativeColumn();
            //            });

            //            if (Model.AdditionalInstruction != null)
            //            {

            //                for (int i = 0; i < Model.AdditionalInstruction.AdditionalInstructionItems.Count; i++)
            //                {
            //                    var item = Model.AdditionalInstruction.AdditionalInstructionItems[i];
            //                    if (i % 2 == 0)
            //                    {
            //                        table.Cell().Element(GrayCellStyle).Text(item.Key).Bold(); table.Cell().Element(GrayCellStyle).Text(item.Value);
            //                    }
            //                    else
            //                    {
            //                        table.Cell().Element(TransparentCellStyle).Text(item.Key).Bold(); table.Cell().Element(TransparentCellStyle).Text(item.Value);
            //                    }
            //                }

            //            }

            //            table.Footer(header =>
            //            {
            //                header.Cell().Element(HeaderCellStyle).Text("");
            //                header.Cell().Element(HeaderCellStyle).Text("");

            //                static IContainer HeaderCellStyle(IContainer container)
            //                {
            //                    return container.DefaultTextStyle(x => x.Bold()).PaddingBottom(1).BorderBottom(1).BorderColor(Colors.Black);
            //                }
            //            });

            //            static IContainer GrayCellStyle(IContainer container)
            //            {
            //                return container.Background("#F5F5F5").PaddingVertical(5);
            //            }
            //            static IContainer TransparentCellStyle(IContainer container)
            //            {
            //                return container.BorderBottom(1).BorderColor(Colors.Transparent).PaddingVertical(5);
            //            }
            //        });
            //    });
            //}

            //void ComposeFirmsTable(IContainer container)
            //{
            //    container.Column(column =>
            //    {
            //        //Title 
            //        strTitle = Model.Firms.Titles;
            //        column.Item().Element(ComposeTitle);

            //        // Table
            //        column.Item().Table(table =>
            //        {

            //            table.ColumnsDefinition(columns =>
            //            {
            //                columns.ConstantColumn(190);
            //                columns.RelativeColumn();
            //            });
            //            if (Model.Firms != null)
            //            {

            //                for (int i = 0; i < Model.Firms.FirmasItems.Count; i++)
            //                {
            //                    var item = Model.Firms.FirmasItems[i];
            //                    if (i % 2 == 0)
            //                    {
            //                        table.Cell().Element(GrayCellStyle).Text(item.Key).Bold(); table.Cell().Element(GrayCellStyle).Text(item.Value);
            //                    }
            //                    else
            //                    {
            //                        table.Cell().Element(TransparentCellStyle).Text(item.Key).Bold(); table.Cell().Element(TransparentCellStyle).Text(item.Value);
            //                    }
            //                }

            //            }

            //            static IContainer GrayCellStyle(IContainer container)
            //            {
            //                return container.Background("#F5F5F5").PaddingVertical(5);
            //            }
            //            static IContainer TransparentCellStyle(IContainer container)
            //            {
            //                return container.BorderBottom(1).BorderColor(Colors.Transparent).PaddingVertical(5);
            //            }
            //        });
            //    });

            //}

            //void ComposeRiskIdentificationTable(IContainer container)
            //{
            //    container.Column(column =>
            //    {
            //        //Title 
            //        strTitle = Model.RiskIdentification.Titles;
            //        column.Item().Element(ComposeTitle);

            //        column.Item().Table(table =>
            //        {

            //            table.ColumnsDefinition(columns =>
            //            {
            //                columns.ConstantColumn(15);
            //                columns.RelativeColumn();
            //            });

            //            if (Model.RiskIdentification != null)
            //            {

            //                for (int i = 0; i < Model.RiskIdentification.RiskIdentificationItems.Count; i++)
            //                {
            //                    var item = Model.RiskIdentification.RiskIdentificationItems[i];
            //                    if (item.Key.Contains("Unchecked") || item.Key.Contains("Checked"))
            //                    {
            //                        table.Cell().Element(TransparentCellStyle).AlignLeft().MaxHeight(17).MaxWidth(17).Image(_environment.WebRootPath + "\\images\\checked.png");
            //                        table.Cell().Element(TransparentCellStyle).AlignLeft().PaddingLeft(4).Border(0).Text(item.Value).FontSize(10);  //font size change
            //                    }
            //                    //else
            //                    //{
            //                    //    if (i % 2 == 0)
            //                    //    {
            //                    //        table.Cell().Element(GrayCellStyle).MaxWidth(100).Text(item.Key).Bold(); table.Cell().Element(GrayCellStyle).Text(item.Value);
            //                    //    }
            //                    //    else
            //                    //    {
            //                    //        table.Cell().Element(TransparentCellStyle).Text(item.Key).Bold(); table.Cell().Element(TransparentCellStyle).Text(item.Value);
            //                    //    }
            //                    //}

            //                }

            //            }
            //            static IContainer GrayCellStyle(IContainer container)
            //            {
            //                return container.Background("#F5F5F5").PaddingVertical(5);
            //            }
            //            static IContainer TransparentCellStyle(IContainer container)
            //            {
            //                return container.BorderBottom(1).BorderColor(Colors.Transparent).PaddingVertical(5);
            //            }
            //        });
            //    });
            //}




            #endregion

        });
    }

    private void ComposeCheckboxSection(IContainer container)
    {
        container.Column(column =>
        {

            column.Item().Element(TitleCellStyle).Text(Model.Checkbox.Title);
            column.Item().PaddingTop(5).PaddingBottom(5).Row(r =>
            {
                r.RelativeItem().Border(1);
            });
            foreach (var checkboxItemValue in Model.Checkbox.CheckboxItems)
            {
              column.Item().Element(TransparentCellStyle).Row(r =>
                {
                    if (checkboxItemValue.Value == "true")
                    {
                        r.ConstantItem(25).AlignLeft().MaxHeight(25).MaxWidth(25).Padding(5).AlignLeft().Image(_environment.WebRootPath + "\\images\\checked.png");//(checkboxItemValue.Questionanswer.Value);
                    }
                    else
                    {
                        r.ConstantItem(25).AlignLeft().MaxHeight(25).MaxWidth(25).Padding(5).AlignLeft().Image(_environment.WebRootPath + "\\images\\unChecked.png");
                    }
                    r.ConstantItem(230).Padding(4).Text(checkboxItemValue.Key);
                });

            }

            column.Item().Element(GrayCellStyle).Row(r =>
            {
                r.ConstantItem(170).Padding(5).Text(Model.Checkbox.Comments.Key).Bold();
                r.RelativeItem().Padding(5).Text(Model.Checkbox.Comments.Value);
            });
            column.Item().Element(TransparentCellStyle).Row(r =>
            {
                r.ConstantItem(170).Padding(5).Text(Model.Checkbox.Answeredby.Key).Bold();
                r.RelativeItem().Padding(5).Text(Model.Checkbox.Answeredby.Value);
            });

            column.Item().PaddingTop(5).PaddingBottom(5).Element(ComposeImages);


        });
    }

    private void ComposeSignatureSection(IContainer container)
    {
        container.Column(column =>
        {
            foreach (var item in Model.SignatureBoxes)
            {
                column.Item().Element(TitleCellStyle).Text(item.Title);

                foreach (var signatureItem in item.SignatureItems)
                {
                    column.Item().PaddingTop(5).PaddingBottom(5).Row(r =>
                    {
                        r.RelativeItem().Border(1);
                    });

                    column.Item().Element(GrayCellStyle).Row(r =>
                    {
                        r.ConstantItem(170).Padding(5).Text(signatureItem.RequestedBy.Key).Bold();
                        r.RelativeItem().Padding(5).Text(signatureItem.RequestedBy.Value);
                    });
                    column.Item().Element(TransparentCellStyle).Row(r =>
                    {
                        r.ConstantItem(170).Padding(5).Text(signatureItem.SignedBy.Key).Bold();
                        r.RelativeItem().Padding(5).Text(signatureItem.SignedBy.Value);
                    });
                    column.Item().Element(GrayCellStyle).Row(r =>
                    {
                        r.ConstantItem(170).Padding(5).Text(signatureItem.SignedAt.Key).Bold();
                        r.RelativeItem().Padding(5).Text(signatureItem.SignedAt.Value);
                    });
                    column.Item().Element(TransparentCellStyle).Row(r =>
                    {
                        r.ConstantItem(170).Padding(5).Text(signatureItem.Signature.Key).Bold();
                        if (signatureItem.SignatureBytes?.Length > 0)
                        {
                            r.RelativeItem().Width(150).Border(1).Padding(5).Image(signatureItem.SignatureBytes);
                        }
                        else
                        {
                            r.RelativeItem().Padding(5).Text(signatureItem.Signature.Value);
                        }
                    });

                }
            }

        });
    }

    private void ComposeRadioSection(IContainer container)
    {
        container.Column(column =>
        {
            foreach (var item in Model.Radios)
            {
                column.Item().Element(TitleCellStyle).Text(item.Title);
                foreach (var radioItem in item.RadioItems)
                {
                    column.Item().PaddingTop(5).PaddingBottom(5).Row(r =>
                    {
                        r.RelativeItem().Border(1);
                    });

                    column.Item().Element(GrayCellStyle).Row(r =>
                    {
                        r.ConstantItem(170).Padding(5).Text(radioItem.QuestionAnswer.Key).Bold();
                        r.RelativeItem().Padding(5).Text(radioItem.QuestionAnswer.Value);
                    });
                    column.Item().Element(TransparentCellStyle).Row(r =>
                    {
                        r.ConstantItem(170).Padding(5).Text(radioItem.Answer.Key).Bold();
                        r.RelativeItem().Padding(5).Text(radioItem.Answer.Value);
                    });
                    column.Item().Element(GrayCellStyle).Row(r =>
                    {
                        r.ConstantItem(170).Padding(5).Text(radioItem.Comments.Key).Bold();
                        r.RelativeItem().Padding(5).Text(radioItem.Comments.Value);
                    });
                    column.Item().Element(TransparentCellStyle).Row(r =>
                    {
                        r.ConstantItem(170).Padding(5).Text(radioItem.Answeredby.Key).Bold();
                        r.RelativeItem().Padding(5).Text(radioItem.Answeredby.Value);
                    });

                    column.Item().PaddingTop(5).PaddingBottom(5).Element(ComposeImages);
                }

            }

        });
    }

    private void ComposeWorkPermitTable(IContainer container)
    {
        container.Column(column =>
        {
            column.Item().Element(TitleCellStyle).Text(Model.Title);
            // Table
            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(170);
                    columns.RelativeColumn();
                });

                if (Model.WorkPermitData != null)
                {
                    for (int i = 0; i < Model.WorkPermitData.Count; i++)
                    {
                        var item = Model.WorkPermitData[i];
                        if (item.Key.Contains("Status"))
                        {
                            table.Cell().Element(FieldCellStyle).Text(item.Key).Bold();
                            table.Cell().Element(ComposeStatus);
                        }
                        else
                        {
                            table.Cell().Element(FieldCellStyle).Text(item.Key).Bold();
                            table.Cell().Element(CellStyle).Text(item.Value);
                        }
                    }
                }

                static IContainer CellStyle(IContainer container)
                {
                    return container.BorderBottom(1).BorderColor(Colors.Transparent).PaddingVertical(5);
                }

                static IContainer FieldCellStyle(IContainer container)
                {
                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(1).BorderBottom(0).BorderColor(Colors.Transparent);
                }
            });


        });
    }

    private void ComposeStatus(IContainer container)
    {
        container.Layers(layers =>
        {

            layers.Layer().Canvas((canvas, size) =>
            {
                DrawRoundedRectangle("#F6FFED", false);
                DrawRoundedRectangle("#B7EB8F", true);

                void DrawRoundedRectangle(string color, bool isStroke)
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse(color),
                        IsStroke = isStroke,
                        StrokeWidth = 1,
                        IsAntialias = true
                    };

                    canvas.DrawRoundRect(0, 0, 52, size.Height, 15, 15, paint);
                }
            });

            layers
                .PrimaryLayer()
                .PaddingVertical(5)
                .PaddingHorizontal(5)
                .DefaultTextStyle(x => x.FontSize(8).FontColor("#52C41A"))
                .Text("APPROVED");

        });
    }

    private static IContainer TitleCellStyle(IContainer container)
    {
        return container.DefaultTextStyle(x => x.Bold().FontSize(15)).PaddingBottom(10).PaddingTop(10);
    }
    private static IContainer TitleBorderCellStyle(IContainer container)
    {
        return container.DefaultTextStyle(x => x.Bold()).PaddingBottom(5).BorderBottom(1).BorderColor(Colors.Black);
    }

    private static IContainer GrayCellStyle(IContainer container)
    {
        return container.Background("#F5F5F5").PaddingVertical(5);
    }
    private static IContainer TransparentCellStyle(IContainer container)
    {
        return container.BorderBottom(1).BorderColor(Colors.Transparent).PaddingVertical(5);
    }
    #endregion
}

