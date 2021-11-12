using ODataPrototype.Models;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ODataPrototype.Infrastructure
{
    public class CustomODataOutputFormatter : ODataOutputFormatter
    {
        private readonly JsonSerializer _serializer;

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
            _serializer = new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver() };

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
            using (var writer = new StreamWriter(context.HttpContext.Response.Body))
            {
                //TODO: get finishing OData result
                object data = new object();

                var mainResponseModel = new MainResponseModel
                {
                    AccessToken = "test-access-token-stub",
                    Data = data
                };

                _serializer.Serialize(writer, mainResponseModel);
                await writer.FlushAsync();
            }
        }

        //NOTE: if you uncomment, it doesn't work!
        //
        //public override void WriteResponseHeaders(OutputFormatterWriteContext context)
        //{
        //    WriteResponseHeaders(context);
        //}
    }
}
