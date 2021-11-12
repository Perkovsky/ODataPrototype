using ODataPrototype.Models;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace ODataPrototype.Infrastructure
{
    public class CustomODataOutputFormatter : ODataOutputFormatter
    {
        public CustomODataOutputFormatter()
            : base(new[]
            { 
                //ODataPayloadKind.Asynchronous,
                //ODataPayloadKind.Batch,
                //ODataPayloadKind.BinaryValue,
                //ODataPayloadKind.Collection,
                //ODataPayloadKind.Delta,
                //ODataPayloadKind.EntityReferenceLink,
                //ODataPayloadKind.EntityReferenceLinks,
                //ODataPayloadKind.Error,
                //ODataPayloadKind.IndividualProperty,
                //ODataPayloadKind.MetadataDocument,
                //ODataPayloadKind.Parameter,
                //ODataPayloadKind.Property,
                //ODataPayloadKind.Resource,
                ODataPayloadKind.ResourceSet,
                //ODataPayloadKind.ServiceDocument,
                //ODataPayloadKind.Unsupported,
                //ODataPayloadKind.Value,
            })
        {
            SupportedMediaTypes.Add("application/json");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return base.CanWriteResult(context);
        }

        public override IReadOnlyList<string> GetSupportedContentTypes(string contentType, Type objectType)
        {
            return base.GetSupportedContentTypes(contentType, objectType);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var originalBody = context.HttpContext.Response.Body;

            await using (var ms = new MemoryStream())
            {
                context.HttpContext.Response.Body = ms;
                await base.WriteResponseBodyAsync(context, selectedEncoding);
                ms.Position = 0;

                // prefix
                var prefix = selectedEncoding.GetBytes(GetMainResponseModelPrefix());
                await originalBody.WriteAsync(prefix, 0, prefix.Length);
                
                // OData final result
                await ms.CopyToAsync(originalBody);

                // suffix
                var suffix = selectedEncoding.GetBytes("}");
                await originalBody.WriteAsync(suffix, 0, suffix.Length);
            }

            context.HttpContext.Response.Body = originalBody;
        }

        private static string GetMainResponseModelPrefix()
        {
            var mainResponseModelWithoutData = new MainResponseModel
            {
                AccessToken = "test-access-token-stub",
                Data = null
            };

            var jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var strMainResponseModelWithoutData = JsonConvert.SerializeObject(mainResponseModelWithoutData, jsonSettings);
            var result = strMainResponseModelWithoutData.Replace("null}", string.Empty);
            return result;
        }
    }
}
