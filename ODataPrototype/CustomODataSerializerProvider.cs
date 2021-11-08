using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Formatter.Serialization;
using Microsoft.OData;
using Microsoft.OData.Edm;
using System;

namespace ODataPrototype
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
	}


	public class AnnotatingEntitySerializer : ODataResourceSerializer
	{
		public AnnotatingEntitySerializer(ODataSerializerProvider serializerProvider)
			: base(serializerProvider)
		{
		}

		public override ODataProperty CreateStructuralProperty(IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
		{
            ODataProperty property = base.CreateStructuralProperty(structuralProperty, resourceContext);

			// some logic here

			return property;
		}

		public override void AppendDynamicProperties(ODataResource resource, SelectExpandNode selectExpandNode, ResourceContext resourceContext)
		{
			base.AppendDynamicProperties(resource, selectExpandNode, resourceContext);
		}
	}
}
