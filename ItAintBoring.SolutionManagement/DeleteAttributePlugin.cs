using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Messages;

namespace ItAintBoring.SolutionManagement
{
    public class DeleteAttributePlugin : IPlugin
    {

        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService =
                (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));

            var ent =(Entity)context.InputParameters["Target"];
            string entity = ent.Contains("ita_entity") ? (string)ent["ita_entity"] : null;
            string attribute = ent.Contains("ita_attribute") ? (string)ent["ita_attribute"] : null;
            if (entity != null && attribute != null)
            {
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                try
                {

                    DeleteAttributeRequest dar = new DeleteAttributeRequest();
                    dar.EntityLogicalName = entity;
                    dar.LogicalName = attribute;
                    service.Execute(dar);
                    ent["statuscode"] = new OptionSetValue(455000000);
                }
                catch (Exception ex)
                {
                    ent["ita_details"] = ex.Message;
                    ent["statuscode"] = new OptionSetValue(455000001);
                }

            }

        }
    }
}
