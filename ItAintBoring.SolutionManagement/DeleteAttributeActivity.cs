using System;
using System.Activities;
using System.Linq;
using System.Text;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk.Messages;

namespace ItAintBoring.SolutionManagement.Workflow.Activities
{
    /*
   public sealed class DeleteAttributeActivity : CodeActivity
   {

       /// <summary>
       /// Executes the workflow activity.
       /// </summary>
       /// <param name="executionContext">The execution context.</param>
       protected override void Execute(CodeActivityContext executionContext)
       {
           ITracingService tracingService = executionContext.GetExtension<ITracingService>();
           IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
           IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
           IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

           var entity = (string)executionContext.GetValue(Entity);
           var attribute = (string)executionContext.GetValue(Attribute);

           Entity ent = new Entity("ita_solutionaction");
           ent.Id = new Guid("d7eea101-b796-457a-8c2a-4ad8fca48cc3");

           bool updated = false;
           while (!updated)
           {
               try
               {
                   service.Update(ent);
                   updated = true;
               }
               catch (Exception ex)
               {
                   service.Create(ent);
               }
           }

           ent = new Entity(context.PrimaryEntityName);
           ent.Id = context.PrimaryEntityId;
           try
           {

               DeleteAttributeRequest dar = new DeleteAttributeRequest();
               dar.EntityLogicalName = entity;
               dar.LogicalName = attribute;
               service.Execute(dar);
               ent["statuscode"] = new OptionSetValue(455000000);
           }
           catch(Exception ex)
           {
               ent["ita_details"] = ex.Message;
               ent["statuscode"] = new OptionSetValue(455000001);
           }
           if (context.PrimaryEntityName.ToUpper() == "ITA_SOLUTIONACTION")//Can be used on a different entity
           {
               service.Update(ent);
           }
       }

       [Input("Entity")]
       public InArgument<string> Entity { get; set; }

       [Input("Attribute")]
       public InArgument<string> Attribute { get; set; }
   }
   */
}
