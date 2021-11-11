using Microsoft.AspNet.OData.Formatter.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.OData.Edm;
using System;

namespace ODataPrototype.Infrastructure
{
    public class CustomODataSerializerProvider : DefaultODataSerializerProvider
    {
        private readonly AnnotatingEntitySerializer _annotatingEntitySerializer;

        public CustomODataSerializerProvider(IServiceProvider container)
            : base(container)
        {
            _annotatingEntitySerializer = new AnnotatingEntitySerializer(this);
        }

        public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            if (edmType.Definition.TypeKind == EdmTypeKind.Entity)
                return new AnnotatingEntitySerializer(this);

            return base.GetEdmTypeSerializer(edmType);
        }

        public override ODataSerializer GetODataPayloadSerializer(Type type, HttpRequest request)
        {
            return base.GetODataPayloadSerializer(type, request);
        }
    }
}
