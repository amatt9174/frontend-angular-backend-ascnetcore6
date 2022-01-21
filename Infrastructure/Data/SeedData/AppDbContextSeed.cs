using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDBContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Members.Any())
                {
                    Member m1 = new Member
                    {
                        TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                        FirstName = "phillip",
                        MiddleInitial = "m",
                        LastName = "matteis",
                        DateOfBirth = DateTime.Parse("1948-04-26").ToUniversalTime(),
                        EMail = "phil@intellect.net",
                        DriversLicenseNumber = 11122233,
                        Status = "active",
                        DateCreated = DateTime.UtcNow,
                        LocalTimezoneCreated =
                            TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                            ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                        DateUpdated = DateTime.UtcNow,
                        LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                            ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                    };

                    Member m2 = new Member
                    {
                        TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                        FirstName = "anthony",
                        MiddleInitial = "c",
                        LastName = "matteis",
                        DateOfBirth = DateTime.Parse("1957-07-16").ToUniversalTime(),
                        EMail = "amatt9174@gmail.com",
                        DriversLicenseNumber = 14731317,
                        Status = "active",
                        DateCreated = DateTime.UtcNow,
                        LocalTimezoneCreated =
                            TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                            ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                        DateUpdated = DateTime.UtcNow,
                        LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                            ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                    };

                    Member[] seedMembers = { m1, m2 };
                    context.Members.AddRange(seedMembers);
                    await context.SaveChangesAsync();

                    Attachment[] seedAttachments = {
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "phillip").MId,
                            Status = "active",
                            AName = "ds00575-melanoma-pictures-for-self-examination.jpg",
                            AGroup = "General Melanoma",
                            ALoc = "https://www.mayoclinic.org/-/media/kcms/gbs/patient-consumer/images/2013/11/19/10/03/",
                            AType = "Asymetrical",
                            AFormat = "aformat 1",
                            ADesc = "Asymmetrical skin growths, in which one part is different from the other, may indicate melanoma. Here, the left side of the mole is dark and slightly raised, whereas the right side is lighter in color and flat.",
                            ACypher = "acypher 1",
                            Remarks = "remarks 1",
                            Usage = "usage 1",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "phillip").MId,
                            Status = "active",
                            AName = "ds00575-a-asymmetry.jpg",
                            AGroup = "General Melanoma",
                            ALoc = "https://www.mayoclinic.org/-/media/kcms/gbs/patient-consumer/images/2013/11/19/10/03/",
                            AType = "Border irregularity",
                            AFormat = "aformat 2",
                            ADesc = "Melanomas may have borders that are vaguely defined. Growths with irregular, notched or scalloped borders need to be examined by a doctor.",
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "phillip").MId,
                            Status = "active",
                            AName = "ds00575-b-border-irregularity.jpg",
                            AGroup = "General Melanoma",
                            ALoc = "https://www.mayoclinic.org/-/media/kcms/gbs/patient-consumer/images/2013/11/19/10/03/",
                            AType = "Color changes",
                            AFormat = "aformat 1",
                            ADesc = "Multiple colors or uneven distribution of color may indicate cancer.",
                            ACypher = "acypher 1",
                            Remarks = "remarks 1",
                            Usage = "usage 1",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "phillip").MId,
                            Status = "active",
                            AName = "ds00575-c-color-changes.jpg",
                            AGroup = "General Melanoma",
                            ALoc = "https://www.mayoclinic.org/-/media/kcms/gbs/patient-consumer/images/2013/11/19/10/03/",
                            AType = "Diameter",
                            AFormat = "aformat 2",
                            ADesc = "A skin growth's large size may be an indication of cancer. Have your doctor check out any growth larger than the diameter of a pencil eraser — about 1/4 inch (6 millimeters).",
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "phillip").MId,
                            Status = "active",
                            AName = "ds00575-e-evolving.jpg",
                            AGroup = "General Melanoma",
                            ALoc = "https://www.mayoclinic.org/-/media/kcms/gbs/patient-consumer/images/2013/11/19/10/03/",
                            AType = "Evolving",
                            AFormat = "aformat 2",
                            ADesc = "Melanoma — a serious form of skin cancer — is often curable if you find it early. These melanoma pictures can help you determine what to look for. The American Academy of Dermatology advises that you watch skin spots for these features: Asymmetry Border irregularity Color changes Diameter greater than 1/4 inch (about 6 millimeters) Evolving Follow this ABCDE guide to determine if an unusual mole or suspicious spot on your skin may be melanoma.",
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "phillip").MId,
                            Status = "active",
                            AName = "ds00575-melanoma-pictures-for-self-examination.jpg",
                            AGroup = "Melanoma pictures for self-examination",
                            ALoc = "https://www.mayoclinic.org/-/media/kcms/gbs/patient-consumer/images/2013/11/19/10/03/",
                            AType = "Examples",
                            AFormat = "aformat 2",
                            ADesc = "A skin growth's large size may be an indication of cancer. Have your doctor check out any growth larger than the diameter of a pencil eraser — about 1/4 inch (6 millimeters).",
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "anthony").MId,
                            Status = "active",
                            AName = "cq5dam.web.1280.1280.jpeg",
                            AGroup = "Basal Cell Carcinoma",
                            ALoc = "https://www.cancer.org/content/dam/cancer-org/images/galleries/skin-cancer-images/cancer-basal-cell-carcinoma-02-restricted.jpg/jcr:content/renditions/",
                            AType = "Raised",
                            AFormat = "aformat 2",
                            ADesc = "About 8 out of 10 of all skin cancers are basal cell carcinomas (also called basal cell cancers). These cancers usually develop on areas exposed to the sun. They can appear as raised areas (like this one), and can be pale, pink, or red. They may have one or more abnormal blood vessels.",
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "anthony").MId,
                            Status = "active",
                            AName = "cq5dam.web.1280.1280.jpeg",
                            AGroup = "Basal Cell Carcinoma",
                            ALoc = "https://www.cancer.org/content/dam/cancer-org/images/galleries/skin-cancer-images/cancer-basal-cell-carcinoma-02-restricted.jpg/jcr:content/renditions/",
                            AType = "Flat",
                            AFormat = "aformat 2",
                            ADesc = "Most basal cell carcinomas occur in places exposed to the sun, but they can also develop in other places. They can appear as flat, pale or pink areas, like this one. Larger basal cell carcinomas may have oozing or crusted areas.", 
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "anthony").MId,
                            Status = "active",
                            AName = "cq5dam.web.1280.1280.jpeg",
                            AGroup = "Basal Cell Carcinoma",
                            ALoc = "https://www.cancer.org/content/dam/cancer-org/images/galleries/skin-cancer-images/cancer-basal-cell-carcinoma-03-restricted.jpg/jcr:content/renditions/",
                            AType = "Raised",
                            AFormat = "aformat 2",
                            ADesc = "Some basal cell carcinomas may appear as raised, pink or red, translucent, shiny, pearly bumps that may bleed after a minor injury. They may have a lower area in their center, and blue, brown, or black areas.", 
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "anthony").MId,
                            Status = "active",
                            AName = "cq5dam.web.1280.1280.jpeg",
                            AGroup = "Basal Cell Carcinoma",
                            ALoc = "https://www.cancer.org/content/dam/cancer-org/images/galleries/skin-cancer-images/cancer-basal-cell-carcinoma-04-restricted.jpg/jcr:content/renditions/",
                            AType = "Slow Growing",
                            AFormat = "aformat 2",
                            ADesc = "Basal cell carcinomas tend to grow slowly. It’s very rare for a basal cell cancer to spread to other parts of the body. But if a basal cell cancer is left untreated, it can grow into nearby areas and invade the bone or other tissues beneath the skin.", 
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "anthony").MId,
                            Status = "active",
                            AName = "cq5dam.thumbnail.600.600.jpeg",
                            AGroup = "Kaposi Sarcoma",
                            ALoc = "https://www.cancer.org/content/dam/cancer-org/images/galleries/skin-cancer-images/cancer-kaposi-sarcoma-01-restricted.jpg/jcr:content/renditions/",
                            AType = "Skin Tumor",
                            AFormat = "aformat 2",
                            ADesc = "Kaposi sarcoma (KS) is a cancer that develops from cells that line lymph or blood vessels. It usually appears as tumors on the skin or on mucosal surfaces such as inside the mouth, but these tumors can also start in other parts of the body.", 
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "anthony").MId,
                            Status = "active",
                            AName = "cq5dam.thumbnail.600.600.jpeg",
                            AGroup = "Kaposi Sarcoma",
                            ALoc = "https://www.cancer.org/content/dam/cancer-org/images/galleries/skin-cancer-images/cancer-kaposi-sarcoma-03-restricted.jpg/jcr:content/renditions/",
                            AType = "(KSHV) Herpies Kaposi",
                            AFormat = "aformat 2",
                            ADesc = "Kaposi sarcoma (KS) is caused by infection with Kaposi sarcoma-associated herpesvirus (KSHV), also known as human herpesvirus 8 (HHV-8).", 
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "anthony").MId,
                            Status = "active",
                            AName = "cq5dam.thumbnail.600.600.jpeg",
                            AGroup = "Kaposi Sarcoma",
                            ALoc = "https://www.cancer.org/content/dam/cancer-org/images/galleries/skin-cancer-images/cancer-kaposi-sarcoma-04-restricted.jpg/jcr:content/renditions/",
                            AType = "(HIV) Kaposi",
                            AFormat = "aformat 2",
                            ADesc = "People infected with HIV are much more likely to develop Kaposi sarcoma (KS), so many health experts recommend that people infected with HIV be examined regularly by a health care provider.", 
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                        new Attachment
                        {
                            TKey = new Guid("00000000-0000-0000-0000-000000000000"),
                            MId = seedMembers.Single(m => m.FirstName == "anthony").MId,
                            Status = "active",
                            AName = "cq5dam.thumbnail.600.600.jpeg",
                            AGroup = "Kaposi Sarcoma",
                            ALoc = "https://www.cancer.org/content/dam/cancer-org/images/galleries/skin-cancer-images/cancer-kaposi-sarcoma-05-restricted.jpg/jcr:content/renditions/",
                            AType = "Swelling Kaposi",
                            AFormat = "aformat 2",
                            ADesc = "The skin lesions of Kaposi sarcoma (KS) most often appear on the legs or face. Some lesions on the legs or in the groin area may cause the legs and feet to swell painfully.", 
                            ACypher = "acypher 2",
                            Remarks = "remarks 2",
                            Usage = "usage 2",
                            DateCreated = DateTime.UtcNow,
                            LocalTimezoneCreated =
                                TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName,
                            DateUpdated = DateTime.UtcNow,
                            LocalTimezoneUpdated = TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName
                        },
                    };

                    context.Attachments.AddRange(seedAttachments);
                    await context.SaveChangesAsync();
                }

                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(path + @"/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText(path + @"/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText(path + @"/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText(path + @"/Data/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);
                    foreach (var item in methods)
                    {
                        context.DeliveryMethods.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppDbContextSeed>();
                logger.LogError(ex.Message);
            }    
        }
    }
}