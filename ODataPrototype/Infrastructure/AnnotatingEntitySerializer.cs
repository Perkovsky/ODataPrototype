using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Formatter.Serialization;
using Microsoft.OData;
using Microsoft.OData.Edm;
using System;
using System.Threading.Tasks;

namespace ODataPrototype.Infrastructure
{
    public class AnnotatingEntitySerializer : ODataResourceSerializer
	{
		public AnnotatingEntitySerializer(ODataSerializerProvider serializerProvider)
			: base(serializerProvider)
		{
		}

		public override void AppendDynamicProperties(ODataResource resource, SelectExpandNode selectExpandNode, ResourceContext resourceContext)
		{
			base.AppendDynamicProperties(resource, selectExpandNode, resourceContext);
		}

		public override void AppendInstanceAnnotations(ODataResource resource, ResourceContext resourceContext)
		{
			base.AppendInstanceAnnotations(resource, resourceContext);
		}

		public override string CreateETag(ResourceContext resourceContext)
		{
			return base.CreateETag(resourceContext);
		}

		public override ODataNestedResourceInfo CreateNavigationLink(IEdmNavigationProperty navigationProperty, ResourceContext resourceContext)
		{
			return base.CreateNavigationLink(navigationProperty, resourceContext);
		}

		public override ODataAction CreateODataAction(IEdmAction action, ResourceContext resourceContext)
		{
			return base.CreateODataAction(action, resourceContext);
		}

		public override ODataFunction CreateODataFunction(IEdmFunction function, ResourceContext resourceContext)
		{
			return base.CreateODataFunction(function, resourceContext);
		}

		public override ODataValue CreateODataValue(object graph, IEdmTypeReference expectedType, ODataSerializerContext writeContext)
        {
			return base.CreateODataValue(graph, expectedType, writeContext);
		}

		public override ODataResource CreateResource(SelectExpandNode selectExpandNode, ResourceContext resourceContext)
		{
			return base.CreateResource(selectExpandNode, resourceContext);
		}

		public override SelectExpandNode CreateSelectExpandNode(ResourceContext resourceContext)
		{
			return base.CreateSelectExpandNode(resourceContext);
		}

		public override ODataProperty CreateStructuralProperty(IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
		{
			return base.CreateStructuralProperty(structuralProperty, resourceContext);
		}

		public override void WriteDeltaObjectInline(object graph, IEdmTypeReference expectedType, ODataWriter writer, ODataSerializerContext writeContext)
		{
			WriteDeltaObjectInline(graph, expectedType, writer, writeContext);
		}

		public override Task WriteDeltaObjectInlineAsync(object graph, IEdmTypeReference expectedType, ODataWriter writer, ODataSerializerContext writeContext)
		{
			return base.WriteDeltaObjectInlineAsync(graph, expectedType, writer, writeContext);
		}

		public override void WriteObject(object graph, Type type, ODataMessageWriter messageWriter, ODataSerializerContext writeContext)
		{
			base.WriteObject(graph, type, messageWriter, writeContext);
		}

		public override Task WriteObjectAsync(object graph, Type type, ODataMessageWriter messageWriter, ODataSerializerContext writeContext)
		{
			return base.WriteObjectAsync(graph, type, messageWriter, writeContext);
		}

		public override void WriteObjectInline(object graph, IEdmTypeReference expectedType, ODataWriter writer, ODataSerializerContext writeContext)
		{
			WriteObjectInline(graph, expectedType, writer, writeContext);
		}

		public override Task WriteObjectInlineAsync(object graph, IEdmTypeReference expectedType, ODataWriter writer, ODataSerializerContext writeContext)
		{
			return base.WriteObjectInlineAsync(graph, expectedType, writer, writeContext);
		}
	}
}
